using Model;

namespace ModelTests;

[TestClass]
public class SquareEliminatorTests
{
    [TestMethod]
    public void ForSquares4x3To4x6Returns18SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(18, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(3, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(5, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(3, 7)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(5, 7)));
    }


    [TestMethod]
    public void ForSquares0x3To0x4Returns8SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(0, 3), new Square(0, 4) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(8, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(0, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(1, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(0, 5)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(1, 5)));
    }

    [TestMethod]
    public void ForSquares3x9To4x9Returns8SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(3, 9), new Square(4, 9) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(8, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(2, 8)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(2, 9)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(5, 8)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(5, 9)));
    }

    [TestMethod]
    public void ForSquares7x5To9x5Returns12SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(7, 5), new Square(8, 5), new Square(9, 5) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(12, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(6, 4)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(6, 6)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(9, 4)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(9, 6)));
    }

    [TestMethod]
    public void ForSquares5x0To5x1Returns9SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(5, 0), new Square(5, 1) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(9, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(4, 0)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(4, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(6, 0)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(6, 2)));
    }

    [TestMethod]
    public void ForSquares0x0To0x1Returns6SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(0, 0), new Square(0, 1) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(6, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(0, 0)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(0, 2)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(1, 0)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(1, 2)));
    }

    [TestMethod]
    public void ForSquares8x9To9x9Returns6SquaresIncludingSurrondingSquares()
    {
        var eliminator = new SquareEliminator();

        var shipSquares = new List<Square> { new Square(8, 9), new Square(9, 9) };

        var toEliminate = eliminator.ToEliminate(shipSquares, 10, 10);
        Assert.AreEqual(6, toEliminate.Count());

        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(7, 8)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(7, 9)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(9, 8)));
        Assert.IsTrue(toEliminate.Contains(new SquareCoordinate(9, 9)));
    }
}