using AlgorithmsDataStructures2;

namespace aBSTtree;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSize3()
    {
        aBST tree = InitTree();
        Assert.That(tree.Tree.Length, Is.EqualTo(7));
    }
    
    [Test]
    public void TestSize0()
    {
        aBST tree = new aBST(0);
        Assert.That(tree.Tree.Length, Is.EqualTo(1));
    }
    
    [Test]
    public void TestFindEmpty()
    {
        aBST tree = new aBST(8);
        var found = tree.FindKeyIndex(19);
        Assert.That(found, Is.EqualTo(0));
    }
    
    [Test]
    public void TestAddEmpty()
    {
        aBST tree = new aBST(8);
        var add = tree.AddKey(19);
        var found = tree.FindKeyIndex(19);
        Assert.That(found, Is.EqualTo(add));
    }
    
    [Test]
    public void TestFindNotExist()
    {
        aBST tree = InitTree();
        var found = tree.FindKeyIndex(19);
        Assert.Null(found);
    }
    
    private aBST InitTree()
    {
        aBST tree = new aBST(2);
        tree.AddKey(10);
        tree.AddKey(5);
        tree.AddKey(3);
        tree.AddKey(8);
        tree.AddKey(15);
        tree.AddKey(12);
        tree.AddKey(20);
        return tree;
    }
}