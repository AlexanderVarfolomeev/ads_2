using AlgorithmsDataStructures2;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddNewVertex()
    {
        SimpleGraph g = new SimpleGraph(5);
        g.AddVertex(1);
        Assert.NotNull(g.vertex[0]);
    }
    
    [Test]
    public void AddNewEdge()
    {
        SimpleGraph g = new SimpleGraph(5);
        g.AddVertex(1);
        g.AddVertex(2);
        
        g.AddEdge(0, 1);
        Assert.True(g.IsEdge(0, 1));
        Assert.True(g.IsEdge(1, 0));
        
        g.RemoveEdge(1, 0);
        
        Assert.False(g.IsEdge(1,0));
        Assert.False(g.IsEdge(0,1));
        
    }
    
    [Test]
    public void DeleteVertex()
    {
        SimpleGraph g = new SimpleGraph(5);
        g.AddVertex(1);
        g.AddVertex(2);
        
        g.AddEdge(0, 1);
        Assert.True(g.IsEdge(0, 1));
        Assert.True(g.IsEdge(1, 0));
        
        g.RemoveVertex(1);
        
        Assert.False(g.IsEdge(1,0));
        Assert.False(g.IsEdge(0,1));
        
    }
}