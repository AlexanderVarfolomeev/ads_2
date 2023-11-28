using AlgorithmsDataStructures2;

namespace TreeTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestGetAllNodes()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(5, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        var list = tree.GetAllNodes();
        Assert.That(list.Count, Is.EqualTo(5));
        Assert.Contains(node1, list);
        Assert.Contains(node2, list);
        Assert.Contains(node3, list);
        Assert.Contains(node4, list);
        Assert.Contains(node5, list);
    }
    
    [Test]
    public void TestDeleteNodes()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(5, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        tree.DeleteNode(node3);
        var list = tree.GetAllNodes();
        Assert.That(list.Count, Is.EqualTo(2));
        Assert.Contains(node1, list);
        Assert.Contains(node2, list);
    }
    
    [Test]
    public void TestMoveNode()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(5, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);
        
        tree.MoveNode(node2, node5);
        Assert.That(tree.GetAllNodes().Count, Is.EqualTo(5));
        Assert.That(tree.Root.Children.Count, Is.EqualTo(1));
        Assert.That(tree.Root.Children, Has.No.Member(node2));
        Assert.That(node5.Children, Has.Member(node2));
    }
    
    [Test]
    public void TestFindNodeByValue()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(2, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        var list = tree.FindNodesByValue(2);
        Assert.That(list.Count, Is.EqualTo(2));
        Assert.Contains(node2, list);
        Assert.Contains(node5, list);
    }
    
    [Test]
    public void TestFindNodeByValueNothingFound()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(2, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        var list = tree.FindNodesByValue(10);
        Assert.That(list.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void TestCount()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(2, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        var count = tree.Count();
        Assert.That(count, Is.EqualTo(5));
    }
    
    [Test]
    public void TestSetLevel()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(2, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);
        
        tree.SetLevels();

        Assert.That(node1.Level, Is.EqualTo(1));
        Assert.That(node2.Level, Is.EqualTo(2));
        Assert.That(node3.Level, Is.EqualTo(2));
        Assert.That(node4.Level, Is.EqualTo(3));
        Assert.That(node5.Level, Is.EqualTo(4));
        
        tree.MoveNode(node3, node2);
        tree.SetLevels();
        Assert.That(node1.Level, Is.EqualTo(1));
        Assert.That(node2.Level, Is.EqualTo(2));
        Assert.That(node3.Level, Is.EqualTo(3));
        Assert.That(node4.Level, Is.EqualTo(4));
        Assert.That(node5.Level, Is.EqualTo(5));
    }
    
    [Test]
    public void TestLeadCountAfterDelete()
    {
        var node1 = new SimpleTreeNode<int>(1, null);
        var node2 = new SimpleTreeNode<int>(2, null);
        var node3 = new SimpleTreeNode<int>(3, null);
        var node4 = new SimpleTreeNode<int>(4, null);
        var node5 = new SimpleTreeNode<int>(2, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);
        tree.AddChild(tree.Root, node2);
        tree.AddChild(tree.Root, node3);
        tree.AddChild(node3, node4);
        tree.AddChild(node4, node5);

        var count = tree.LeafCount();
        Assert.That(count, Is.EqualTo(2));
        
        tree.DeleteNode(node4);
        
        count = tree.LeafCount();
        Assert.That(count, Is.EqualTo(2));
    }
}