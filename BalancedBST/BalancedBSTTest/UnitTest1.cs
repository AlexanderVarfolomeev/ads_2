using AlgorithmsDataStructures2;

namespace BalancedBSTTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        int[] a = new[] {4,16,1,9,11,7,5};

        BalancedBST tree = new BalancedBST();
        tree.GenerateTree(a);
        
        Assert.That(tree.Root.NodeKey, Is.EqualTo(7));
        Assert.That(tree.Root.LeftChild.NodeKey, Is.EqualTo(4));
        Assert.That(tree.Root.RightChild.NodeKey, Is.EqualTo(11));
        Assert.That(tree.Root.LeftChild.LeftChild.NodeKey, Is.EqualTo(1));
        Assert.That(tree.Root.LeftChild.RightChild.NodeKey, Is.EqualTo(5));
        Assert.That(tree.Root.RightChild.LeftChild.NodeKey, Is.EqualTo(9));
        Assert.That(tree.Root.RightChild.RightChild.NodeKey, Is.EqualTo(16));
        Assert.True(tree.IsBalanced(tree.Root));
    }
}