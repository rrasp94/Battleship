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
}
