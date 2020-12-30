using System;
using System.Collections.Generic;

namespace codeinCSharp
{
    class Node 
    {

        int value ;

        public int Value 
        {
            get {return this.value;}
        } 

        public Node (int value )
        {
            this.value = value ; 
        }
    }

    class Graph 
    {
        List <Node> nodes; 
        public Graph ()
        {
            nodes = new List <Node>(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
