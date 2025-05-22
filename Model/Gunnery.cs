using System.Diagnostics;

namespace Model;

public enum ShootingTactics
{
    Random,
    Surrounding,
    Inline
}

public class Gunnery
{
    public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
    {
        recordGrid = new ShotsGrid(rows, columns);
        this.shipLengths = new List<int>(shipLengths.OrderDescending());
        targetSelector = new RandomTargetSelector(recordGrid, this.shipLengths[0]);
    }

    public Square Next()
    {
        target = targetSelector.Next();
        return target;
    }

    public void ProcessHitResult(HitResult hitResult)
    {
        RecordTargetResult(hitResult);
        switch (hitResult)
        {
            case HitResult.Missed:
                return;
            case HitResult.Hit:
                switch (ShootingTactics)
                {
                    case ShootingTactics.Random:
                        ChangeTacticsToSurrounding();
                        return;
                    case ShootingTactics.Surrounding:
                        ChangeTacticsToInline();
                        return;
                    case ShootingTactics.Inline:
                        return;
                    default:
                        Debug.Assert(false);
                        return;
                }
            case HitResult.Sunken:
                ChangeTacticsToRandom();
                return;
        }
    }

    private void RecordTargetResult(HitResult hitResult)
    {
        switch (hitResult)
        {
            case HitResult.Missed:
                target.ChangeState(SquareState.Missed);
                return;
            case HitResult.Hit:
                target.ChangeState(SquareState.Hit);
                shipSquares.Add(target);
                return;
            case HitResult.Sunken:
                MarkShipSunken();
                return;
        }
    }

    private void MarkShipSunken()
    {
        shipSquares.Add(target);
        foreach (var square in shipSquares)
        {
            square.ChangeState(SquareState.Sunken);
        }
        var toEliminate = eliminator.ToEliminate(shipSquares, recordGrid.Rows, recordGrid.Columns);
        foreach (var square in toEliminate)
        {
            recordGrid.GetSquare(square.Row, square.Column).ChangeState(SquareState.Eliminated);
        }
        shipSquares.Clear();
    }

    private void ChangeTacticsToRandom()
    {
        ShootingTactics = ShootingTactics.Random;
        targetSelector = new RandomTargetSelector(recordGrid, shipLengths[0]);
    }

    private void ChangeTacticsToSurrounding()
    {
        ShootingTactics = ShootingTactics.Surrounding;
        targetSelector = new SurroundingTargetSelector();
    }

    private void ChangeTacticsToInline()
    {
        ShootingTactics = ShootingTactics.Inline;
        targetSelector = new InlineTargetSelector();
    }

    public ShootingTactics ShootingTactics { get; private set; } = ShootingTactics.Random;

    private readonly ShotsGrid recordGrid;

    private readonly List<int> shipLengths = [];

    private List<Square> shipSquares = new List<Square>();

    private Square target;

    private ITargetSelector targetSelector;

    private readonly SquareEliminator eliminator = new SquareEliminator();
}
