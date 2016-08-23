using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_package
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = GetParameters(line);
                parameters.InitializeHeader();
                parameters.CorrectIPAdressesInHeader();
                parameters.CorrectChecksumInHeader();

                foreach (var octet in parameters.Header)
                {
                    if(octet.Length == 1)
                        Console.Write("0");
                    Console.Write(octet);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        static Parameters GetParameters(string line)
        {
            var lineArray = line.Split(' ');

            var parameters = new Parameters();
            parameters.SourceAddress = new IPAddress(lineArray[0]);
            parameters.DestinationAddress = new IPAddress(lineArray[1]);
            parameters.Package = new List<string>();
            parameters.Package.AddRange(lineArray.ToList().Skip(2));

            return parameters;
        }
    }

    class Parameters
    {
        public IPAddress SourceAddress { get; set; }
        public IPAddress DestinationAddress { get; set; }
        public List<string> Package { get; set; }
        public List<string> Header { get; set; }

        public void InitializeHeader()
        {
            Header = Package.Take(20).ToList();
        }

        public void CorrectIPAdressesInHeader()
        {
            CorrectSourceAddressInHeader();
            CorrectDestinationAddressInHeader();
        }

        private void CorrectSourceAddressInHeader()
        {
            var firstPart = Header.Take(12).ToList();
            var lastPart = Header.Skip(16).ToList();
            
            firstPart.AddRange(SourceAddress.HexOctets.ToList());
            firstPart.AddRange(lastPart);

            Header = firstPart;
        }
        private void CorrectDestinationAddressInHeader()
        {
            var firstPart = Header.Take(16).ToList();            
            
            firstPart.AddRange(DestinationAddress.HexOctets.ToList());

            Header = firstPart;
        }

        public void CorrectChecksumInHeader()
        {
            var checkSumArray = GetHexChecksum();
            
            var firstPart = Header.Take(10).ToList();
            var lastPart = Header.Skip(12).ToList();

            firstPart.Add(checkSumArray[0]);
            firstPart.Add(checkSumArray[1]);
            firstPart.AddRange(lastPart);
            Header = firstPart;
        }

        private string[] GetHexChecksum()
        { 
            int octetSum = SumAllOctets();
            string onesComplement = GetOnesComplement(octetSum);
            var hexCheckSum = GetHexNumberFromBinary(onesComplement);

            var hexArray = new string[2];
            if (hexCheckSum.Length == 1)
            {
                hexArray[0] = "0";
                hexArray[1] = hexCheckSum;
            }
            else if (hexCheckSum.Length == 2)
            {
                hexArray[0] = "0";
                hexArray[1] = hexCheckSum;
            }
            else if (hexCheckSum.Length > 2)
            {
                hexArray[0] = hexCheckSum.Substring(0, hexCheckSum.Length - 2);
                hexArray[1] = hexCheckSum.Substring(hexCheckSum.Length - 2);
            }

            return hexArray;            
        }
 
        private string GetHexNumberFromBinary(string onesComplement)
        {
            var number = Convert.ToInt32(onesComplement, 2);
            var outs = Convert.ToString(number, 16);
            return outs;
        }
 
        private string GetOnesComplement(int octetSum)
        {
            string binaryOctetSum = Convert.ToString(octetSum, 2);
            if (binaryOctetSum.Length < 16)
            {
                binaryOctetSum = AppendStartZeros(binaryOctetSum);
            }
            
            var binaryDigits = binaryOctetSum.ToCharArray();
            string onesComplement = "";
            foreach (char element in binaryDigits)
            {
                if (element == '0')
                    onesComplement += "1";
                else
                    onesComplement += "0";
            }
            return onesComplement;
        }
 
        private string AppendStartZeros(string binaryOctetSum)
        {
            var missingZeros = 16 - binaryOctetSum.Length;
            var correctedNumber = "";
            for (var i = 0; i < missingZeros; i++)
            {
                correctedNumber += "0";
            }
            binaryOctetSum = correctedNumber + binaryOctetSum;
            return binaryOctetSum;
        }
 
        private int SumAllOctets()
        {
            var checkSum = 0;
            for (var i = 0; i < Header.Count; i++)
            {
                if (i != 10 && i != 11)
                {
                    var currentVal = Convert.ToInt32(Header.ElementAt(i), 16);               
                    if (i % 2 == 0)
                    {
                        currentVal = currentVal << 8;
                    }
                    checkSum += currentVal;                   
                }
            }            
            checkSum = AddCarry(checkSum);
            
            return checkSum;
        }
 
        private int AddCarry(int checkSum)
        {
            while (checkSum > 65535)
            {
                var stringChecksum = Convert.ToString(checkSum, 2);
                var carryDigits = stringChecksum.Substring(0, stringChecksum.Length - 16);
                var endDigits = stringChecksum.Substring(stringChecksum.Length - 16);
                checkSum = Convert.ToInt32(carryDigits, 2) + Convert.ToInt32(endDigits, 2);
            }
            return checkSum;
        }
    }

    class IPAddress
    {
        public string AddressString { get; set; }
        public int[] DecimalOctets { get; set; }

        public string[] HexOctets { get; set; }

        public IPAddress(string address)
        {
            AddressString = address;
            InitializeDecimalOctets();
            InitializeHexOctets();
        }       

        private void InitializeDecimalOctets()
        {
            DecimalOctets = GetDecimalOctetsFromString(AddressString);
        }
         private static int[] GetDecimalOctetsFromString(string address)
        {
            var separatedAddress = address.Split('.');
            var octets = new int[separatedAddress.Length];
            for (var i = 0; i < octets.Length; i++)
            {
                octets[i] = Convert.ToInt32(separatedAddress[i]);
            }
            return octets;
        }

        private void InitializeHexOctets()
        {
            HexOctets = GetHexFromDecimalOctets(DecimalOctets);
        }

        private static string[] GetHexFromDecimalOctets(int[] decimalOctets)
        {
            var hexOctets = new string[decimalOctets.Length];
            for(var i=0; i< decimalOctets.Length; i++)
            {
                var hexOctet = Convert.ToString(decimalOctets[i], 16);
                hexOctets[i] = hexOctet;
            }
            return hexOctets;
        }
    }
}
