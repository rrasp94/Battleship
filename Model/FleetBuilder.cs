namespace Model;

public class FleetBuilder
{
    public FleetBuilder(int gridRows, int gridColumns, int[] shipLengths)
    {
        fleetGrid = new Grid(gridRows, gridColumns);
        this.shipLengths = new List<int>(shipLengths.OrderByDescending(length => length));
    }

    private readonly Grid fleetGrid;

    private readonly List<int> shipLengths;

    private readonly Random random;

    public Fleet CreateFleet()
    {
        var fleet = new Fleet();

        for (int i = 0; i < shipLengths.Count; ++i)
        {
            var candidates = fleetGrid.GetAvailablePlacements(shipLengths[i]);
            var selectedIndex = random.Next(candidates.Count());
            var selected = candidates.ElementAt(selectedIndex);

            fleet.CreateShip(selected);
        }

        return fleet;
    }
}
