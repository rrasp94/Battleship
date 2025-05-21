using Model;

namespace ModelTests;

[TestClass]
public class FleetBuilderTests
{
    [TestMethod]
    public void CreateFleetBuildsFleetWithNumberOfShipsProvided()
    {
        int rows = 10;
        int columns = 10;
        int[] shipLengths = { 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };

        var builder = new FleetBuilder(rows, columns, shipLengths);
        var fleet = builder.CreateFleet();

        Assert.AreEqual(10, fleet.Ships.Count());
    }
    [TestMethod]
    public void CreateFleetBuildsFleetWithShipsOfLengthProvided()
    {
        int rows = 10;
        int columns = 10;
        int[] shipLengths = { 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };

        var builder = new FleetBuilder(rows, columns, shipLengths);
        var fleet = builder.CreateFleet();

        Assert.AreEqual(4, fleet.Ships.Count(s => s.Squares.Count() == 2));
    }
}
