using AlgorithmsDataStructures2;

namespace BBSTArrayTest;

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
        var res = BalancedBST.GenerateBBSTArray(a);
        var expected = new List<int>(){7,4,11,1,5,9,16};
        for (int i = 0; i < res.Length; i++)
        {
            Assert.That(res[i], Is.EqualTo(expected[i]));
        }
    }
    
    [Test]
    public void Test2()
    {
        var a = new int[0];
        var res = BalancedBST.GenerateBBSTArray(a);
        Assert.That(res.Length, Is.EqualTo(0));
    }
    [Test]
    public void Test3()
    {
        int[] a = new[] {1, 2, 3};
        var res = BalancedBST.GenerateBBSTArray(a);
        var expected = new List<int>(){2, 1, 3};
        for (int i = 0; i < res.Length; i++)
        {
            Assert.That(res[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void Test4()
    {
        int[] a = new[] { 2, 1};
        var res = BalancedBST.GenerateBBSTArray(a);
        var expected = new List<int>(){1, 2};
        for (int i = 0; i < res.Length; i++)
        {
            Assert.That(res[i], Is.EqualTo(expected[i]));
        }
    }
}