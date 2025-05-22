using System;

namespace Model;

public class RandomTargetSelector : ITargetSelector
{

    public RandomTargetSelector(FleetGrid grid, int shipLength)
    {
        this.grid = grid;
        this.shipLength = shipLength;
    }
    public Square Next()
    {
        var placements = grid.GetAvailablePlacements(shipLength);
        var candidates = placements.SelectMany(s => s);
        var selectedIndex = random.Next(candidates.Count());
        return candidates.ElementAt(selectedIndex);
    }

    private readonly FleetGrid grid;
    private readonly int shipLength;
    private readonly Random random = new Random();
}
