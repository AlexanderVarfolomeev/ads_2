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
            var oldParent = OriginalNode.Parent;
            oldParent.Children.Remove(OriginalNode);

            OriginalNode.Parent = NewParent;
            if (NewParent.Children is null)
            {
                NewParent.Children = new List<SimpleTreeNode<T>>();
            }
            NewParent.Children.Add(OriginalNode);
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
            if (currentNode.Children is null)
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