using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }
  
    public class SimpleGraph<T>
    {
        public Vertex<T> [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex<T> [size];
        }
	
        public void AddVertex(T value)
        {
            Vertex<T> v = new Vertex<T>(value);
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] is null)
                {
                    vertex[i] = v;
                    return;
                }
            }
        }

        public void RemoveVertex(int v)
        {
            vertex[v] = null;
            for (int i = 0; i < max_vertex; i++)
            {
                m_adjacency[i,v] = 0;
                m_adjacency[v,i] = 0;
            }
        }
	
        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1;
        }
	
        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }
	
        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }
        
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var val in vertex)
            {
                val.Hit = false;
            }
            
            stack.Push(VFrom);
            var current = VFrom;
            while (stack.Count != 0)
            {
                current = stack.Peek();
                vertex[current].Hit = true;

                bool foundAdj = false;
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[current, i] == 0 || vertex[i].Hit) continue;

                    foundAdj = true;
                    stack.Push(i);

                    if (i == VTo)
                    {
                        return StackToList(stack);
                    }
                    break;
                }

                if (!foundAdj)
                {
                    stack.Pop();
                }
            }

            return StackToList(stack);
        }

      

        private List<Vertex<T>> StackToList(Stack<int> stack)
        {
            List<Vertex<T>> res = new List<Vertex<T>>();

            foreach (var i in stack)
            {
                res.Add(vertex[i]);
            }

            res.Reverse();

            return res;
        }
    }
}