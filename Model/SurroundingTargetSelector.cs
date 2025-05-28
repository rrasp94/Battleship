namespace Model;

public class SurroundingTargetSelector : ITargetSelector
{
    public SurroundingTargetSelector(ShotsGrid grid, Square firstHit, int shipLength)
    {
        this.grid = grid;
        this.firstHit = firstHit;
        this.shipLength = shipLength;
    }

    private readonly ShotsGrid grid;
    private readonly Square firstHit;
    private readonly int shipLength;
    private readonly Random random = new Random();
    public Square Next()
    {
        List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            var inDirection = grid.GetSquaresInDirection(firstHit.Row, firstHit.Column, direction);
            if (inDirection.Any())
            {
                squares.Add(inDirection);
            }
        }
        int index = random.Next(squares.Count);
        return squares[index].First();
    }
}
