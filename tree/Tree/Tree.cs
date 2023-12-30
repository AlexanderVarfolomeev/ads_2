using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent; 
        public List<SimpleTreeNode<T>> Children; 
        public int Level;
        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }
	
    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; 

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
        
        public List<T> EvenTrees()
        {
            List<T> res = new List<T>();
            EvenTrees(Root, ref res);

            return res;
        }

        private int EvenTrees(SimpleTreeNode<T> node, ref List<T> list)
        {
            int count = 0;

            if (node.Children is null)
            {
                return 1;
            }
            
            foreach (var child in node.Children)
            {
                int subtreeCount = EvenTrees(child,ref  list);
                if (subtreeCount % 2 == 0)
                {
                    list.Add(node.NodeValue);
                    list.Add(child.NodeValue);
                    continue;
                }

                count += subtreeCount;
            }

            return count + 1;
        }
	
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode.Children is null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            }

            NewChild.Parent = ParentNode;
            ParentNode.Children.Add(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            var parent = NodeToDelete.Parent;
            NodeToDelete.Parent = null;
            parent.Children.Remove(NodeToDelete);
        }
        
        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            if (Root is null)
            {
                return new List<SimpleTreeNode<T>>();
            }
            
            return getAllNodes(Root);
        }
        
        private List<SimpleTreeNode<T>> getAllNodes(SimpleTreeNode<T> currentNode)
        {
            List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
            list.Add(currentNode);
            if (currentNode.Children is null)
            {
                return list;
            }
            
            foreach (var node in currentNode.Children)
            {
                list.AddRange(getAllNodes(node));
            }
            
            return list;
        }
	
        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if (Root is null)
            {
                return new List<SimpleTreeNode<T>>();
            }
            
            
            return findNodesByValue(Root, val);
        }
        
        public List<SimpleTreeNode<T>> findNodesByValue(SimpleTreeNode<T> currentNode, T val)
        {
            var list = new List<SimpleTreeNode<T>>();
            if (currentNode.NodeValue.Equals(val))
            {
                list.Add(currentNode);
            }

            if (currentNode.Children is null)
            {
                return list;
            }
            
            foreach (var node in currentNode.Children)
            {
                list.AddRange(findNodesByValue(node, val));
            }
            
            return list;
        }
   
        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }
   
        public int Count()
        {
            return  GetAllNodes().Count;;
        }

        public int LeafCount()
        {
            return Root is null ? 0 : leafCount(Root);
        }
        
        
        public int leafCount(SimpleTreeNode<T> currentNode)
        {
            if (currentNode.Children is null || currentNode.Children.Count == 0) 
            {
                return 1;
            }

            int count = 0;
            foreach (var node in currentNode.Children)
            {
                count += leafCount(node);
            }
            
            return count;
        }

        public void SetLevels()
        {
            setLevels(Root);
        }
        
        private void setLevels(SimpleTreeNode<T> currentNode)
        {
            if (currentNode == Root)
            {
                currentNode.Level = 1;
            }

            if (currentNode.Children is null)
            {
                return;
            }

            foreach (var node in currentNode.Children)
            {
                node.Level = currentNode.Level + 1;
                setLevels(node);
            }
        }
    }
 
}