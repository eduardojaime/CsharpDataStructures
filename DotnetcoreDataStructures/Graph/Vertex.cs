using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetcoreDataStructures.Graph
{
    public class Vertex<T>
    {
        public bool isVisited;
        public T value;

        public Vertex(T value)
        {
            this.value = value;
            this.isVisited = false;
        }

        public void VisitVertex()
        {
            this.isVisited = true;
            Console.WriteLine(this.value.ToString());
        }
    }
}
