namespace Model;

public class ShotsGrid : Grid
{
    public ShotsGrid(int rows, int columns) : base(rows, columns)
    {
    }

    protected override bool IsSquareAvailable(int row, int column)
    {
        return squares[row, column]?.SquareState == SquareState.Intact;
    }

    public Square GetSquare(int row, int column)
    {
        return squares[row, column]!;
    }
}
