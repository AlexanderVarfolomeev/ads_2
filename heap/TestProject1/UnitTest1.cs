using AlgorithmsDataStructures2;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        
        Heap h = new Heap();
        var arr = new int[] { 11, 9, 4,7,8 };
        h.MakeHeap(arr, 3);
        
        Assert.That(h.HeapArray[0], Is.EqualTo(11));
        Assert.That(h.HeapArray[1], Is.EqualTo(9));
        Assert.That(h.HeapArray[2], Is.EqualTo(4));
        Assert.That(h.HeapArray[3], Is.EqualTo(7));
        Assert.That(h.HeapArray[4], Is.EqualTo(8));
        
        var max = h.GetMax();
        Assert.That(max, Is.EqualTo(11));
        Assert.That(h.HeapArray[0], Is.EqualTo(9));
        Assert.That(h.HeapArray[1], Is.EqualTo(8));
        Assert.That(h.HeapArray[2], Is.EqualTo(4));
        Assert.That(h.HeapArray[3], Is.EqualTo(7));
    }
}