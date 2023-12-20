using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
	
        public int [] HeapArray; 
        public int size;    
        public Heap() { HeapArray = null; }
		
        public void MakeHeap(int[] a, int depth)
        {
            var len = Convert.ToInt32(Math.Pow(2, depth + 1) - 1);
            HeapArray = new int[len];
            foreach (var val in a)
            {
                Add(val);
            }
        }
		
        public int GetMax()
        {
            if (size == 0)
            {
                return -1;
            }

            if (size == 1)
            {
                size--;
                return HeapArray[0];
            }

            int max = HeapArray[0];
            HeapArray[0] = HeapArray[size - 1];
            size--;
            heapify(0);
            
            return max; 
        }

        private void heapify(int i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);

            int max = i;
            if (left < size && HeapArray[left] > HeapArray[max])
            {
                max = left;
            }

            if (right < size && HeapArray[right] > HeapArray[max])
            {
                max = right;
            }

            if (max != i)
            {
                (HeapArray[i], HeapArray[max]) = (HeapArray[max], HeapArray[i]);
                heapify(max);
            }
        }

        public bool Add(int key)
        {
            if (size == HeapArray.Length)
            {
                return false;
            }
            int i = size;
            HeapArray[i] = key;
            size++;

            while (i != 0 && HeapArray[Parent(i)] < HeapArray[i])
            {
                (HeapArray[i], HeapArray[Parent(i)]) = (HeapArray[Parent(i)],HeapArray[i]);
                i = Parent(i);
            }
            
            return true;
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }
        
        private int LeftChild(int i)
        {
            return (i * 2) + 1;
        }
        
        private int RightChild(int i)
        {
            return (i * 2) + 2;
        }
    }
}