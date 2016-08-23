using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Package_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                var parameters = new Parameters(line);
                var Package = new Package(parameters.MaxWeight);
                var maxPrice = 0.0;
                for (var i = 0; i < parameters.Items.Count; i++)
                {
                    Package.AddItem(parameters.Items.ElementAt(i));
                    while (!Package.IsValid)
                    {
                        Package.RemoveLastItem();
                    }
                    if (Package.ItemsPrice > maxPrice)
                    {
                        maxPrice = Package.ItemsPrice;
                    }

                }
            }
        }
    }

    class Parameters
    {
        public double MaxWeight { get; set; }
        public List<Item> Items { get; set; }

        public Parameters(string parameters)
        {
            var splitParameters = parameters.Split(' ');
            MaxWeight = Double.Parse(splitParameters[0]);
            Items = new List<Item>();
            for(var i = 2; i<splitParameters.Count(); i++)
            {
                Items.Add(new Item(splitParameters[i]));
            }
        }
    }

    class Package
    {
        public double MaxWeight { get; set; }
        public List<Item> Items { get; set; }
        public Package(double maxWeight)
        {
            MaxWeight = maxWeight;
            Items = new List<Item>();
        }
        public double ItemsWeight
        {
            get { return Items.Sum(item => item.Weight); }
        }

        public double ItemsPrice
        {
            get { return Items.Sum(item => item.Price); }   
        }

        public bool IsValid
        {
            get { return MaxWeight >= ItemsWeight; } 
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveLastItem()
        {
            Items.RemoveAt(Items.Count-1);
        }
    }
    class Item
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public Item(string itemString)
        {
            var splitItem = itemString.TrimStart('(').TrimEnd(')').Split(',');
            Id = Int32.Parse(splitItem[0]);
            Weight = Double.Parse(splitItem[1]);
            Weight = Double.Parse(splitItem[2]);
        }
    }
}
