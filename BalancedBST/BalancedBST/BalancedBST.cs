using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; 
        public BSTNode Parent; 
        public BSTNode LeftChild;
        public BSTNode RightChild; 
        public int     Level; 
	
        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }	


    public class BalancedBST
    {
        public BSTNode Root;
	
        public BalancedBST() 
        { 
            Root = null;
        }
		
        public void GenerateTree(int[] a)
        {
           Array.Sort(a);
           Root = GenerateTree(a, 0, a.Length - 1, null);
        }
        
        private BSTNode GenerateTree(int[] a, int l, int r, BSTNode parent)
        {
            if (l > r)
            {
                return null;
            }

            var middle = (l + r) / 2;
            BSTNode node = new BSTNode(a[middle], parent);
            node.Level = parent is null ? 0 : parent.Level + 1;
            node.LeftChild = GenerateTree(a, l, middle - 1, node);
            node.RightChild = GenerateTree(a, middle + 1, r, node);
            return node;
        }

        public bool IsBalanced(BSTNode root_node) 
        {
            if (root_node is null)
            {
                return true;
            }
            
            int rightHeight = Height(root_node.RightChild);
            int leftHeight = Height(root_node.LeftChild);

            if (IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild) &&
                Math.Abs(rightHeight - leftHeight) <= 1)
            {
                return true;
            }
            
            return false; 
        }

        private int Height(BSTNode node)
        {
            if (node is null)
            {
                return 0;
            }
            
            int rightHeight = Height(node.RightChild);
            int leftHeight = Height(node.LeftChild);

            return Math.Max(rightHeight, leftHeight) + 1; 
        }
    }
}   