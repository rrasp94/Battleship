namespace Model;

public class Fleet
{
    private List<Ship> ships = new List<Ship>();
    public IEnumerable<Ship> Ships { get { return ships; } }
}
