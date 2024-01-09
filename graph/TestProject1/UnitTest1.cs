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
    
    [Test]
    public void TestBFirstSearch_NoPathExists()
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
        var result = graph.BreadthFirstSearch(0, 4);

        // Assert
        Assert.IsEmpty(result);
    }
    
    
    [Test]
    public void TestBFirstSearch_MultiplePathsExist()
    {
        // Arrange
        var graph = new SimpleGraph<int>(6);
        graph.AddVertex(0); // Add vertices
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddVertex(5);

        // Creating a graph with multiple paths from vertex 0 to vertex 4
        graph.AddEdge(0, 1); // Add edges
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 4);
        graph.AddEdge(0, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(1, 5);
        graph.AddEdge(5, 4);

        // Act
        var result = graph.BreadthFirstSearch(0, 4);

        // Assert
        Assert.IsNotEmpty(result, "Result should not be empty as there are paths");

        // Check if the path starts at 0 and ends at 4
        Assert.That(result[0].Value, Is.EqualTo(0), "Path should start at vertex 0");
        Assert.That(result[^1].Value, Is.EqualTo(4), "Path should end at vertex 4");

        // Check if the path is valid (each consecutive pair of vertices should have an edge)
        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.IsTrue(graph.IsEdge(result[i].Value, result[i + 1].Value), 
                $"There should be an edge between vertex {result[i].Value} and vertex {result[i + 1].Value}");
        }
    }
    
    [Test]
    public void TestDepthFirstSearch_MultiplePathsExist()
    {
        // Arrange
        var graph = new SimpleGraph<int>(6);
        graph.AddVertex(0); // Add vertices
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddVertex(5);

        // Creating a graph with multiple paths from vertex 0 to vertex 4
        graph.AddEdge(0, 1); // Add edges
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 4);
        graph.AddEdge(0, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(1, 5);
        graph.AddEdge(5, 4);

        // Act
        var result = graph.DepthFirstSearch(0, 4);

        // Assert
        Assert.IsNotEmpty(result, "Result should not be empty as there are paths");

        // Check if the path starts at 0 and ends at 4
        Assert.That(result[0].Value, Is.EqualTo(0), "Path should start at vertex 0");
        Assert.That(result[^1].Value, Is.EqualTo(4), "Path should end at vertex 4");

        // Check if the path is valid (each consecutive pair of vertices should have an edge)
        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.IsTrue(graph.IsEdge(result[i].Value, result[i + 1].Value), 
                $"There should be an edge between vertex {result[i].Value} and vertex {result[i + 1].Value}");
        }
    }
}