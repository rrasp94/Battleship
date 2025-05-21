using Model;

namespace ModelTests;

[TestClass]
public class ShipTests
{
    [TestMethod]
    public void ConstructorCreatesShipWithSquaresProvided()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.IsTrue(ship.Contains(1, 4));
    }
}
