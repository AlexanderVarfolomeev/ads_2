using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public abstract class BSTNode
    {
        public int NodeKey; 
    }
    
    public class BSTNode<T> : BSTNode
    {
        public T NodeValue; 
        public BSTNode<T> Parent; 
        public BSTNode<T> LeftChild; 
        public BSTNode<T> RightChild; 
	
        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;
	
        public bool NodeHasKey;
	
        public bool ToLeft;
	
        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root;
	
        public BST(BSTNode<T> node)
        {
            Root = node;
        }
	
        public BSTFind<T> FindNodeByKey(int key)
        {
            if (Root is null)
            {
                return new BSTFind<T>()
                {
                    Node = null,
                    NodeHasKey = false,
                    ToLeft = false
                };
            }
            
            return FindNodeByKey(key, Root);
        }
        
        private BSTFind<T> FindNodeByKey(int key, BSTNode<T> curNode)
        {
            if (curNode.NodeKey == key)
            {
                return new BSTFind<T>()
                {
                    Node = curNode,
                    NodeHasKey = true,
                    ToLeft = false,
                };
            }

            if ( key > curNode.NodeKey  && curNode.RightChild is null)
            {
                return new BSTFind<T>()
                {
                    Node = curNode, NodeHasKey = false, ToLeft = false,
                };
            } 
         
            if ( key < curNode.NodeKey && curNode.LeftChild is null)
            {
                return new BSTFind<T>()
                {
                    Node = curNode, NodeHasKey = false, ToLeft = true,
                };
            }
            
               
            if (key > curNode.NodeKey)
            {
                return FindNodeByKey(key, curNode.RightChild);
            } 

            
            return FindNodeByKey(key, curNode.LeftChild);
        }
        
        public bool AddKeyValue(int key, T val)
        {
            var found = FindNodeByKey(key);
            if (found.NodeHasKey)
            {
                return false;
            }

            if (found.Node is null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }

            if (found.ToLeft)
            {
                found.Node.LeftChild = new BSTNode<T>(key, val, found.Node);
            }
            else
            {
                found.Node.RightChild = new BSTNode<T>(key, val, found.Node);
            }
            
            return true;
        }
	
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FindMax && FromNode.RightChild is null)
            {
                return FromNode;
            }
            
            if (!FindMax && FromNode.LeftChild is null)
            {
                return FromNode;
            }
            
            if (FindMax)
            {
                return FinMinMax(FromNode.RightChild, FindMax);
            }
            
            return FinMinMax(FromNode.LeftChild, FindMax);
        }
	
        public bool DeleteNodeByKey(int key)
        {
            var found = FindNodeByKey(key); 
            if (found.NodeHasKey && IsLeaf(found.Node))
            {
                RemoveLeaf(found.Node);
                return true; 
            }

            if (found.NodeHasKey && found.Node.RightChild is null)
            {
                if (found.Node.Parent is null)
                {
                    Root = found.Node.LeftChild;
                    Root.Parent = null;
                    return true; 
                }
                
                if (found.Node.Parent.LeftChild == found.Node)
                {
                    found.Node.Parent.LeftChild = found.Node.LeftChild;
                    return true; 
                }

                if (found.Node.Parent.RightChild == found.Node)
                {
                    found.Node.Parent.RightChild = found.Node.LeftChild;
                }
                
                return true; 
            }
            
            if (found.NodeHasKey)
            {
                var candidate = FinMinMax(found.Node.RightChild, false);
                found.Node.NodeKey = candidate.NodeKey;
                if (IsLeaf(candidate))
                {
                    RemoveLeaf(candidate);
                }

                if (candidate.RightChild is not null)
                {
                    candidate.RightChild.Parent = candidate.Parent;

                    if (candidate.Parent.LeftChild == candidate)
                    {
                        candidate.Parent.LeftChild = candidate.RightChild;
                    }

                    if (candidate.Parent.RightChild == candidate)
                    {
                        candidate.Parent.RightChild = candidate.RightChild;
                    }
                }
                return true; 
            }
            
            return false; 
        }

        private void RemoveLeaf(BSTNode<T> node)
        {
            var parent = node.Parent;
            if (parent is null)
            {
                Root = null;
                return;
            }

            if (parent.LeftChild == node)
            {
                parent.LeftChild = null;
            }

            if (parent.RightChild == node)
            {
                parent.RightChild = null;
            }
        }

        private bool IsLeaf(BSTNode<T> node)
        {
            if (node.LeftChild is null && node.RightChild is null)
            {
                return true;
            }

            return false;
        }

        public int Count()
        {
            return Count(Root); 
        }

        private int Count(BSTNode<T> curNode)
        {
            if (curNode is null)
            {
                return 0;
            }

            return Count(curNode.LeftChild) + Count(curNode.RightChild) + 1;
        }
        
     
        
        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> list = new List<BSTNode>();
            if (Root is null)
            {
                return list;
            }

            BSTNode<T> current = Root;
            Queue<BSTNode<T>> q = new Queue<BSTNode<T>>();
            q.Enqueue(current);
            while (q.Count != 0)
            {
                current = q.Dequeue();
                list.Add(current);
                if (current.LeftChild != null)
                {
                    q.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    q.Enqueue(current.RightChild);
                }
            }

            return list;
        }

        public List<BSTNode> DeepAllNodes(int order)
        {
            List<BSTNode> res = new List<BSTNode>();
            switch (order)
            {
                case 0:
                    InOrder(Root, res);
                    break;
                case 1:
                    PostOrder(Root, res);
                    break;
                case 2:
                    PreOrder(Root, res);
                    break;
            }

            return res;
        }

        private void InOrder(BSTNode<T> node, List<BSTNode> res)
        {
            if (node is null)
            {
                return;
            }

            InOrder(node.LeftChild, res);
            res.Add(node);
            InOrder(node.RightChild, res);
        }
        
        private void PostOrder(BSTNode<T> node, List<BSTNode> res)
        {
            if (node is null)
            {
                return;
            }

            PostOrder(node.LeftChild, res);
            PostOrder(node.RightChild, res);
            res.Add(node);
        }
        
        private void PreOrder(BSTNode<T> node, List<BSTNode> res)
        {
            if (node is null)
            {
                return;
            }
            res.Add(node);
            PreOrder(node.LeftChild, res);
            PreOrder(node.RightChild, res);
        }
    }
}