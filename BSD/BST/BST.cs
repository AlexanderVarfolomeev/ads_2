using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	
	
        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;
	
        // true если узел найден
        public bool NodeHasKey;
	
        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;
	
        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null
	
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
                    Root = found.Node;
                }
                
                if (found.Node.Parent.LeftChild == found.Node)
                {
                    found.Node.Parent.LeftChild = found.Node.LeftChild;
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
	
    }
}