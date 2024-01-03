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
        var g = new SimpleGraph<int>(5);
        g.AddVertex(1);
        Assert.NotNull(g.vertex[0]);
    }
    
    [Test]
    public void AddNewEdge()
    {
        var g = new SimpleGraph<int>(5);
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
        var g = new SimpleGraph<int>(5);
        g.AddVertex(1);
        g.AddVertex(2);
        
        g.AddEdge(0, 1);
        Assert.True(g.IsEdge(0, 1));
        Assert.True(g.IsEdge(1, 0));
        
        g.RemoveVertex(1);
        
        Assert.False(g.IsEdge(1,0));
        Assert.False(g.IsEdge(0,1));
        
    }
    
    [Test]
    public void TestDepthFirstSearch_PathExists()
    {
        // Arrange
        var graph = new SimpleGraph<int>(5);
        graph.AddVertex(0); // Add vertices
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);

        graph.AddEdge(0, 1); // Add edges
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 4);

        // Act
        var result = graph.DepthFirstSearch(0, 4);

        // Assert
        var expectedPath = new List<int> { 0, 1, 2, 3, 4 };
        Assert.That(result.Count, Is.EqualTo(expectedPath.Count));
        for (int i = 0; i < expectedPath.Count; i++)
        {
            Assert.That(result[i].Value, Is.EqualTo(expectedPath[i]));
        }
    }

    [Test]
    public void TestDepthFirstSearch_NoPathExists()
    {
        // Arrange
        var graph = new SimpleGraph<int>(5);
        graph.AddVertex(0); // Add vertices
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);

        graph.AddEdge(0, 1); // Add edges
        graph.AddEdge(1, 2);

        // Act
        var result = graph.DepthFirstSearch(0, 4);

        // Assert
        Assert.IsEmpty(result);
    }
}