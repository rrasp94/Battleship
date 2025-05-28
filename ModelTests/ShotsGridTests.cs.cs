using Model;

namespace ModelTests;

[TestClass]
public class ShotsGridTests
{
    [TestMethod]
    public void GetSquaresInDirectionReturns3SquresAboveSquare3x3()
    {
        var grid = new ShotsGrid(10, 10);
        int row = 3;
        int column = 3;
        var squares = grid.GetSquaresInDirection(row, column, Direction.Upwards);
        Assert.AreEqual(3, squares.Count());
    }
    [TestMethod]
    public void GetSquaresInDirectionReturns4SquresRightFromSquare3x5()
    {
        var grid = new ShotsGrid(10, 10);
        int row = 3;
        int column = 5;
        var squares = grid.GetSquaresInDirection(row, column, Direction.Rightwards);
        Assert.AreEqual(4, squares.Count());
    }
    [TestMethod]
    public void GetSquaresInDirectionReturns2SquresBelowSquare7x5()
    {
        var grid = new ShotsGrid(10, 10);
        int row = 7;
        int column = 5;
        var squares = grid.GetSquaresInDirection(row, column, Direction.Downwards);
        Assert.AreEqual(2, squares.Count());
    }
    [TestMethod]
    public void GetSquaresInDirectionReturns1SqureLeftFromSquare7x1()
    {
        var grid = new ShotsGrid(10, 10);
        int row = 7;
        int column = 1;
        var squares = grid.GetSquaresInDirection(row, column, Direction.Leftwards);
        Assert.AreEqual(1, squares.Count());
    }
}
