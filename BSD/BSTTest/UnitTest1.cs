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
       Assert.Equals(find1.Node.Parent.NodeKey, 5);
       
       Assert.True(find2.NodeHasKey);
       Assert.Null(find2.Node.LeftChild);
       Assert.Null(find2.Node.RightChild);
       Assert.Equals(find2.Node.Parent.NodeKey, 8);
       
       Assert.True(findRoot.NodeHasKey);
       Assert.Equals(find2.Node.RightChild.NodeKey, 15);
       Assert.Equals(find2.Node.LeftChild.NodeKey, 8);
    }
    
    [Test]
    public void TestFindAdd()
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

        Assert.Equals(find1.Node.NodeKey, 15);
        Assert.Equals(find2.Node.NodeKey, 5);
        Assert.Equals(find3.Node.NodeKey, 7);
        
        Assert.False(find1.ToLeft);
        Assert.True(find2.ToLeft);
        Assert.False(find3.ToLeft);
    }
}