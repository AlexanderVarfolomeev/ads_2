using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a) 
        {  
            Array.Sort(a);
            var bst = new int?[a.Length * 2];
            GenerateBBSTArray(a, bst, 0, a.Length - 1, 0);

            var res = new int[a.Length];
            int i = 0;
            foreach (var node in bst)
            {
                if (node is not null)
                {
                    res[i++] = node.Value;
                }
            }
            return res;
        }

        private static void GenerateBBSTArray(int[] a, int?[] bst, int left, int right, int i )
        {
            if (left > right)
            {
                return;
            }

            var middle = (left + right) / 2;

            bst[i] = a[middle];

            GenerateBBSTArray(a, bst, left, middle - 1, i * 2 + 1);
            GenerateBBSTArray(a, bst, middle + 1, right, i * 2 + 2);
        }
    }
}