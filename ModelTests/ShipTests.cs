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

    [TestMethod]
    public void HitMetodReturnsMissedIfSquareIsNotPartOfShip()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.AreEqual(HitResult.Missed, ship.Hit(2, 4));
    }

    [TestMethod]
    public void HitMetodReturnsHitIfSquareIsPartOfShip()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 3));
        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 5));
    }

    [TestMethod]
    public void HitMetodReturnsSunkenAfterLastSquareIsHit()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 3));
        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 5));

        Assert.AreEqual(HitResult.Sunken, ship.Hit(1, 4));
    }

    [TestMethod]
    public void HitMetodReturnsHitAfterSquareIsHitAgain()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 3));
        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 5));

        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 3));
    }

    [TestMethod]
    public void HitMetodReturnsSunkenAfterShipIsSunkenButSquareIsHitAgain()
    {
        var squares = new List<Square> { new Square(1, 3), new Square(1, 4), new Square(1, 5) };
        var ship = new Ship(squares);

        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 3));
        Assert.AreEqual(HitResult.Hit, ship.Hit(1, 5));

        Assert.AreEqual(HitResult.Sunken, ship.Hit(1, 4));
        Assert.AreEqual(HitResult.Sunken, ship.Hit(1, 5));
    }
}