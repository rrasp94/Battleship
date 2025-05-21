using Model;

namespace ModelTests;

[TestClass]
public class GridTests
{
    [TestMethod]
    public void ConstructorCreatesGridWith50SquaresFor5RowsAnd10Columns()
    {
        int rows = 5;
        int columns = 10;

        var grid = new Grid(rows, columns);

        Assert.AreEqual(50, grid.Squares.Count());
    }

    [TestMethod]
    public void GetAvailablePlacementsForGrid1x5Returns3PlacementsForShipWith3Squares()
    {
        int rows = 1;
        int columns = 5;
        int shipLength = 3;

        var grid = new Grid(rows, columns);

        Assert.AreEqual(3, grid.GetAvailablePlacements(shipLength).Count());
    }

    [TestMethod]
    public void GetAvailablePlacementsForGrid5x1Returns3PlacementsForShipWith3Squares()
    {
        int rows = 5;
        int columns = 1;
        int shipLength = 3;

        var grid = new Grid(rows, columns);

        Assert.AreEqual(3, grid.GetAvailablePlacements(shipLength).Count());
    }

    [TestMethod]
    public void GetAvailablePlacementsForGrid5x5Returns20PlacementsForShipWith4Squares()
    {
        int rows = 5;
        int cols = 5;
        int shipLength = 4;
        var grid = new Grid(rows, cols);

        Assert.AreEqual(20, grid.GetAvailablePlacements(shipLength).Count());
    }

    [TestMethod]
    public void GetAvailablePlacementsForGrid1x6Returns3PlacementsForShipWith2SquaresAfterSquareInColumn3IsEliminated()
    {
        int rows = 1;
        int cols = 6;
        int shipLength = 2;
        var grid = new Grid(rows, cols);
        grid.EleminateSquare(0, 3);

        Assert.AreEqual(3, grid.GetAvailablePlacements(shipLength).Count());
    }
    [TestMethod]
    public void GetAvailablePlacementsForGrid8x1Returns3PlacementsForShipWith2SquaresAfterSquaresInRows3And5AreEliminated()
    {
        int rows = 8;
        int cols = 1;
        int shipLength = 2;
        var grid = new Grid(rows, cols);
        grid.EleminateSquare(3, 0);
        grid.EleminateSquare(5, 0);

        Assert.AreEqual(3, grid.GetAvailablePlacements(shipLength).Count());
    }
}
