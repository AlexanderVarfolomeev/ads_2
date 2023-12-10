using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int? [] Tree; 
	
        public aBST(int depth)
        {
            int tree_size = Convert.ToInt32(Math.Pow(2, depth + 1)) - 1;
            Tree = new int?[ tree_size ];
            for(int i=0; i<tree_size; i++) Tree[i] = null;
        }
	
        public int? FindKeyIndex(int key)
        {
            int index = 0;
            while (index < Tree.Length)
            {
                if (Tree[index] == key)
                {
                    return index;
                }

                if (Tree[index] == null)
                {
                    return -index;
                }

                if (Tree[index] > key)
                {
                    index = index * 2 + 1;
                    continue;
                }

                if (Tree[index] < key)
                {
                    index = index * 2 + 2;
                }
            }
            return null;
        }

        public int AddKey(int key)
        {
            int? index = FindKeyIndex(key);
            if (index == null)
            {
                return -1;
            }
            
            if (index == 0)
            {
                Tree[index.Value] = key;
                return 0;
            }

            if (index < 0)
            {
                index = -index;
                Tree[index.Value] = key;
                return index.Value;
            }

            if (index > 0)
            {
                return index.Value;
            }
            
            return -1;
        }
    }
}