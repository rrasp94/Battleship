namespace Model;

public class Fleet
{
    private readonly List<Ship> ships = [];

    public IEnumerable<Ship> Ships { get { return ships; } }

    public void CreateShip(IEnumerable<Square> squares)
    {
        var ship = new Ship(squares);
        ships.Add(ship);
    }

    public HitResult Hit(int row, int column)
    {
        foreach (var ship in ships)
        {
            var result = ship.Hit(row, column);
            if (result != HitResult.Missed)
            {
                return result;
            }
        }
        return HitResult.Missed;
    }
}
