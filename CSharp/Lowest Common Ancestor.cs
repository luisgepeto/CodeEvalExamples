using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowest_Common_Ancestor
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNode = new Node(10);
            var secondNode = new Node(29);
            var firstTree = new Tree(firstNode, secondNode);

            var thirdNode = new Node(3);
            var fourthNode = new Node(20, firstTree);
            var secondTree = new Tree(thirdNode, fourthNode);

            var fifthNode = new Node(8, secondTree);
            var sixthNode = new Node(52);
            var thirdTree = new Tree(fifthNode, sixthNode);

            var seventhNode = new Node(30, thirdTree);
            var fourthTree = new Tree(seventhNode);

        }
    }
    class Tree
    {
        public List<Node> NodeList { get; set; }
        public Tree()
        {
            NodeList = new List<Node>();
        }
        public Tree(Node firstNode, Node secondNode) : this()
        {            
            NodeList.Add(firstNode);
            NodeList.Add(secondNode);
        }

        public Tree(Node firstNode) : this()
        {            
            NodeList.Add(firstNode);
        }
        public Tree SearchNode(int nodeValue)
        {
            var resultTree = new Tree();
        }
    }
    class Node
    {
        public int NodeValue { get; set; }
        public Tree SubTree { get; set; }
        public Node(int nodeValue)
        {
            NodeValue = nodeValue;
        }
        public Node(int nodeValue, Tree subTree)
        {
            NodeValue = nodeValue;
            SubTree = subTree;
        }
        
    }
}
