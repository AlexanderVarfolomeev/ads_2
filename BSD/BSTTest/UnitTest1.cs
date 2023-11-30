using AlgorithmsDataStructures2;

namespace BSDTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    
    [Test]
    public void TestFindFound()
    {
        BSTNode<int> rootNode = new BSTNode<int>(10, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(9, 8);
        Assert.True(exist);
        exist =tree.AddKeyValue(1, 12);
        Assert.True(exist);

       var find1 =  tree.FindNodeByKey(1);
       var find2 =  tree.FindNodeByKey(9);
       var findRoot =  tree.FindNodeByKey(10);
       
       Assert.True(find1.NodeHasKey);
       Assert.Null(find1.Node.LeftChild);
       Assert.Null(find1.Node.RightChild);
       Assert.That(find1.Node.Parent.NodeKey, Is.EqualTo(5));
       
       Assert.True(find2.NodeHasKey);
       Assert.Null(find2.Node.LeftChild);
       Assert.Null(find2.Node.RightChild);
       Assert.That(find2.Node.Parent.NodeKey, Is.EqualTo(8));
       
       Assert.True(findRoot.NodeHasKey);
       Assert.That(findRoot.Node.RightChild.NodeKey, Is.EqualTo(15));
       Assert.That(findRoot.Node.LeftChild.NodeKey, Is.EqualTo(8));
    }
    
    [Test]
    public void TestFindNotFound()
    {
        BSTNode<int> rootNode = new BSTNode<int>(10, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(7, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 12);
        Assert.True(exist);

        var find1 =  tree.FindNodeByKey(20);
        var find2 =  tree.FindNodeByKey(1);
        var find3 =  tree.FindNodeByKey(6);
        
        Assert.False(find1.NodeHasKey);
        Assert.False(find2.NodeHasKey);
        Assert.False(find3.NodeHasKey);

        Assert.That(find1.Node.NodeKey, Is.EqualTo(15));
        Assert.That(find2.Node.NodeKey, Is.EqualTo(5));
        Assert.That(find3.Node.NodeKey, Is.EqualTo(5));
        
        Assert.False(find1.ToLeft);
        Assert.True(find2.ToLeft);
        Assert.False(find3.ToLeft);
    }
    
    [Test]
    public void TestFindInEmptyTree()
    {
        BST<int> tree = new BST<int>(null);

        var find1 =  tree.FindNodeByKey(20);
        var find2 =  tree.FindNodeByKey(1);
        var find3 =  tree.FindNodeByKey(6);
        
        Assert.False(find1.NodeHasKey);
        Assert.False(find2.NodeHasKey);
        Assert.False(find3.NodeHasKey);
        
        Assert.Null(find1.Node);
        Assert.Null(find2.Node);
        Assert.Null(find3.Node);
    }
    
    [Test]
    public void TestAddNode()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        Assert.Null(rootNode.LeftChild);
        tree.AddKeyValue(10, 10);
        Assert.NotNull(rootNode.LeftChild);
        Assert.That(rootNode.LeftChild.NodeKey, Is.EqualTo(10));
        
        Assert.Null(rootNode.RightChild);
        tree.AddKeyValue(20, 20);
        Assert.NotNull(rootNode.RightChild);
        Assert.That(rootNode.RightChild.NodeKey, Is.EqualTo(20));
        
        Assert.Null(rootNode.LeftChild.LeftChild);
        tree.AddKeyValue(8, 8);
        Assert.NotNull(rootNode.LeftChild.LeftChild);
        Assert.That(rootNode.LeftChild.LeftChild.NodeKey, Is.EqualTo(8));
        
        Assert.Null(rootNode.RightChild.LeftChild);
        tree.AddKeyValue(17, 17);
        Assert.NotNull(rootNode.RightChild.LeftChild);
        Assert.That(rootNode.RightChild.LeftChild.NodeKey, Is.EqualTo(17));
        
        Assert.Null(rootNode.LeftChild.RightChild);
        tree.AddKeyValue(12, 12);
        Assert.NotNull(rootNode.LeftChild.RightChild);
        Assert.That(rootNode.LeftChild.RightChild.NodeKey, Is.EqualTo(12));
    }
    
    [Test]
    public void TestAddNodeInEmptyTree()
    {
        BST<int> tree = new BST<int>(null);
        var added = tree.AddKeyValue(10, 10);
        Assert.True(added);
        var found = tree.FindNodeByKey(10);
        
        Assert.True(found.NodeHasKey);
        Assert.Null(found.Node.Parent);
        Assert.Null(found.Node.RightChild);
        Assert.Null(found.Node.LeftChild);
    }
    
    [Test]
    public void TestAddNodeExist()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(18, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(7, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 12);
        Assert.True(exist);

        exist = tree.AddKeyValue(7, 11);
        Assert.False(exist);
    }
    
    [Test]
    public void TestAddNodeAfterDelete()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(18, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(7, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 12);
        Assert.True(exist);

        tree.DeleteNodeByKey(8);

        exist = tree.AddKeyValue(8, 0);
        Assert.True(exist);
        
        Assert.That(rootNode.LeftChild.RightChild.NodeKey, Is.EqualTo(8));
    }
    
    [Test]
    public void TestFindMaxFromRoot()
    {
        BSTNode<int> rootNode = new BSTNode<int>(18, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(7, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(51, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(41, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(102, 12);
        Assert.True(exist);
        
        var found = tree.FinMinMax(rootNode, true);
        Assert.That(found.NodeKey, Is.EqualTo(102));
    }
    
    [Test]
    public void TestFindMinFromRoot()
    {
        BSTNode<int> rootNode = new BSTNode<int>(18, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(7, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(5, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(51, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(41, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(102, 12);
        Assert.True(exist);
        
        var found = tree.FinMinMax(rootNode, false);
        Assert.That(found.NodeKey, Is.EqualTo(5));
    }
    
    [Test]
    public void TestFindMaxFromNotRoot()
    {
        BSTNode<int> rootNode = new BSTNode<int>(18, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(12, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(14, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(51, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(41, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(102, 12);
        Assert.True(exist);

        var nodeWith8Key = tree.FindNodeByKey(8);
        
        var found = tree.FinMinMax(nodeWith8Key.Node, true);
        Assert.That(found.NodeKey, Is.EqualTo(14));
    }
    
    [Test]
    public void TestFindMinFromNotRoot()
    {
        BSTNode<int> rootNode = new BSTNode<int>(18, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(12, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(14, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(51, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(41, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(102, 12);
        Assert.True(exist);

        var nodeWith51Key = tree.FindNodeByKey(51);
        
        var found = tree.FinMinMax(nodeWith51Key.Node, false);
        Assert.That(found.NodeKey, Is.EqualTo(41));
    }
    
    [Test]
    public void TestFindMinFromNull()
    {
        BSTNode<int> rootNode = new BSTNode<int>(18, 4, null);
        BST<int> tree = new BST<int>(rootNode);
        
        var exist = tree.AddKeyValue(15, 41);
        Assert.True(exist);
        exist = tree.AddKeyValue(8, 411);
        Assert.True(exist);
        exist =tree.AddKeyValue(12, 11);
        Assert.True(exist);
        exist =tree.AddKeyValue(14, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(51, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(41, 12);
        Assert.True(exist);
        exist =tree.AddKeyValue(102, 12);
        Assert.True(exist);

        Assert.Throws<ArgumentException>(() => tree.FinMinMax(null, false));
    }
    
    [Test]
    public void TestDeleteLeaf()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);

        tree.AddKeyValue(10, 0);
        tree.AddKeyValue(8, 0);
        tree.AddKeyValue(13, 0);
        tree.AddKeyValue(11, 0);
        tree.AddKeyValue(14, 0);
        tree.AddKeyValue(20, 0);
        tree.AddKeyValue(18, 0);
        tree.AddKeyValue(19, 0);
        tree.AddKeyValue(30, 0);
        tree.AddKeyValue(25, 0);
        tree.AddKeyValue(100, 0);
        tree.AddKeyValue(150, 0);

        var deleted = tree.DeleteNodeByKey(150);
        Assert.True(deleted);

        var found = tree.FindNodeByKey(150);
        Assert.False(found.NodeHasKey);
        Assert.That(found.Node.NodeKey, Is.EqualTo(100));
        
        found = tree.FindNodeByKey(100);
        Assert.Null(found.Node.RightChild);
    }
    
    [Test]
    public void TestDeleteRoot()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);

        tree.AddKeyValue(10, 0);
        tree.AddKeyValue(8, 0);
        tree.AddKeyValue(13, 0);
        tree.AddKeyValue(11, 0);
        tree.AddKeyValue(14, 0);
        tree.AddKeyValue(20, 0);
        tree.AddKeyValue(18, 0);
        tree.AddKeyValue(19, 0);
        tree.AddKeyValue(30, 0);
        tree.AddKeyValue(25, 0);
        tree.AddKeyValue(100, 0);
        tree.AddKeyValue(150, 0);

        var deleted = tree.DeleteNodeByKey(15);
        Assert.True(deleted);

        var found = tree.FindNodeByKey(15);
        Assert.False(found.NodeHasKey);
        Assert.That(found.Node.NodeKey, Is.EqualTo(14));
        
        found = tree.FindNodeByKey(18);
        Assert.Null(found.Node.Parent);
        
        found = tree.FindNodeByKey(20);
        Assert.NotNull(found.Node.LeftChild);
        Assert.That(found.Node.LeftChild.NodeKey, Is.EqualTo(19));
        deleted = tree.DeleteNodeByKey(18);
        Assert.True(deleted);

        found = tree.FindNodeByKey(18);
        Assert.False(found.NodeHasKey);
        Assert.That(found.Node.NodeKey, Is.EqualTo(14));
        
        found = tree.FindNodeByKey(19);
        Assert.Null(found.Node.Parent);
        
        found = tree.FindNodeByKey(20);
        Assert.Null(found.Node.LeftChild);
    }

    [Test]
    public void TestDeleteInRightSubTree()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);

        tree.AddKeyValue(10, 0);
        tree.AddKeyValue(8, 0);
        tree.AddKeyValue(13, 0);
        tree.AddKeyValue(11, 0);
        tree.AddKeyValue(14, 0);
        tree.AddKeyValue(20, 0);
        tree.AddKeyValue(18, 0);
        tree.AddKeyValue(19, 0);
        tree.AddKeyValue(30, 0);
        tree.AddKeyValue(25, 0);
        tree.AddKeyValue(100, 0);
        tree.AddKeyValue(150, 0);

        var deleted = tree.DeleteNodeByKey(30);
        Assert.True(deleted);

        var found = tree.FindNodeByKey(30);
        Assert.False(found.NodeHasKey);
        Assert.That(found.Node.NodeKey, Is.EqualTo(25));

        found = tree.FindNodeByKey(100);
        Assert.True(found.NodeHasKey);
        Assert.That(found.Node.LeftChild.NodeKey, Is.EqualTo(25));
        Assert.That(found.Node.RightChild.NodeKey, Is.EqualTo(150));
        Assert.That(found.Node.Parent.NodeKey, Is.EqualTo(20));
    }
    
    [Test]
    public void TestCountInEmptyTree()
    {
        BST<int> tree = new BST<int>(null);

        var count = tree.Count();
        Assert.That(count, Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountInNonEmptyTree()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);

        tree.AddKeyValue(10, 0);
        tree.AddKeyValue(8, 0);
        tree.AddKeyValue(13, 0);
        tree.AddKeyValue(11, 0);
        tree.AddKeyValue(14, 0);
        tree.AddKeyValue(20, 0);
        tree.AddKeyValue(18, 0);
        tree.AddKeyValue(19, 0);
        tree.AddKeyValue(30, 0);
        tree.AddKeyValue(25, 0);
        tree.AddKeyValue(100, 0);
        tree.AddKeyValue(150, 0);
        
        var count = tree.Count();
        Assert.That(count, Is.EqualTo(13));
    }
    
    [Test]
    public void TestCountAfterDelete()
    {
        BSTNode<int> rootNode = new BSTNode<int>(15, 4, null);
        BST<int> tree = new BST<int>(rootNode);

        tree.AddKeyValue(10, 0);
        tree.AddKeyValue(8, 0);
        tree.AddKeyValue(13, 0);
        tree.AddKeyValue(11, 0);
        tree.AddKeyValue(14, 0);
        tree.AddKeyValue(20, 0);
        tree.AddKeyValue(18, 0);
        tree.AddKeyValue(19, 0);
        tree.AddKeyValue(30, 0);
        tree.AddKeyValue(25, 0);
        tree.AddKeyValue(100, 0);
        tree.AddKeyValue(150, 0);

        tree.DeleteNodeByKey(20);
        tree.DeleteNodeByKey(15);
        tree.DeleteNodeByKey(11);
        var count = tree.Count();
        Assert.That(count, Is.EqualTo(10));
    }
}