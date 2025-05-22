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
        recordGrid = new Grid(rows, columns);
    }

    public SquareCoordinate Next()
    {
        throw new NotImplementedException();
    }

    public void ProcessHitResult(HitResult hitResult)
    {
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
                        ChangeTacticsToInline(); break;
                    case ShootingTactics.Inline:
                        return;
                    default:
                        Debug.Assert(false);
                        return;
                }
                return;
            case HitResult.Sunken:
                ChangeTacticsToRandom();
                return;
        }
    }

    private void ChangeTacticsToRandom()
    {
        ShootingTactics = ShootingTactics.Random;
    }

    private void ChangeTacticsToSurrounding()
    {
        ShootingTactics = ShootingTactics.Surrounding;
    }

    private void ChangeTacticsToInline()
    {
        ShootingTactics = ShootingTactics.Inline;
    }

    public ShootingTactics ShootingTactics { get; private set; } = ShootingTactics.Random;
    private readonly Grid recordGrid;
    private ITargetSelector targetSelector = new RandomTargetSelector();
}
