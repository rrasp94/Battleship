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
}
