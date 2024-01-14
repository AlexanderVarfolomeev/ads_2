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
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size, size];
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
                m_adjacency[i, v] = 0;
                m_adjacency[v, i] = 0;
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

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            Queue<int> queue = new Queue<int>();
            List<int> path = new List<int>();
            foreach (var val in vertex)
            {
                val.Hit = false;
                path.Add(-1);
            }


            path.Add(VFrom);
            queue.Enqueue(VFrom);
            var current = VFrom;

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                vertex[current].Hit = true;

                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[current, i] == 0 || vertex[i].Hit) continue;

                    vertex[i].Hit = true;
                    queue.Enqueue(i);
                    path[i] = current;

                    if (i == VTo)
                    {
                        return PathToList(path, VTo);
                    }
                }
            }

            return new List<Vertex<T>>();
        }

        private List<Vertex<T>> PathToList(List<int> path, int VTo)
        {
            List<Vertex<T>> res = new List<Vertex<T>>();
            for (int v = VTo; v != -1; v = path[v])
            {
                res.Add(vertex[v]);
            }

            res.Reverse();
            return res;
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

        public List<Vertex<T>> WeakVertices()
        {
            HashSet<int> strongVertices = new HashSet<int>();

            for (int i = 0; i < max_vertex; i++)
            {
                if (strongVertices.Contains(i))
                    continue;
                FindTrianglesForVertex(i, strongVertices);
            }

            List<Vertex<T>> res = new List<Vertex<T>>();
            for (int i = 0; i < max_vertex; i++)
            {
                if (!strongVertices.Contains(i))
                {
                    res.Add(vertex[i]);
                }
            }

            return res;
        }
        
        private void FindTrianglesForVertex(int vertexIndex,  HashSet<int> strongVertices)
        {
            for (int j = 0; j < max_vertex; j++)
            {
                if (m_adjacency[vertexIndex, j] == 1 && j != vertexIndex)
                {
                    CheckAndAddTriangle(vertexIndex, j, strongVertices);
                }
            }
        }
        
        private void CheckAndAddTriangle(int firstVertex, int secondVertex, HashSet<int> strongVertices)
        {
            for (int k = 0; k < max_vertex; k++)
            {
                if (m_adjacency[secondVertex, k] == 1 && secondVertex != k && firstVertex != k)
                {
                    strongVertices.Add(firstVertex);
                    strongVertices.Add(secondVertex);
                    strongVertices.Add(k);
                }
            }
        }
    }
}