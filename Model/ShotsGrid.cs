namespace Model;

public enum Direction
{
    Upwards,
    Rightwards,
    Downwards,
    Leftwards
}
public class ShotsGrid : Grid
{
    public ShotsGrid(int rows, int columns) : base(rows, columns)
    {
    }

    protected override bool IsSquareAvailable(int row, int column)
    {
        return squares[row, column]?.SquareState == SquareState.Intact;
    }

    public void ChangeSquareState(int row, int column, SquareState newState)
    {
        squares[row, column]!.ChangeState(newState);
    }

    public IEnumerable<Square> GetSquaresInDirection(int row, int column, Direction direction)
    {
        var result = new List<Square>();

        int deltaRow = 0;
        int deltaColumn = 0;
        int limit = 0;
        switch (direction)
        {
            case Direction.Upwards:
                --row;
                deltaRow = -1;
                limit = -1;
                break;
            case Direction.Rightwards:
                ++column;
                deltaColumn = +1;
                limit = Columns;
                break;
            case Direction.Downwards:
                ++row;
                deltaRow = +1;
                limit = Rows;
                break;
            case Direction.Leftwards:
                --column;
                deltaColumn = -1;
                limit = -1;
                break;
        }
        for (int r = row, c = column; r != limit && c != limit && IsSquareAvailable(r, c); r += deltaRow, c += deltaColumn)
        {
            result.Add(squares[r, c]!);
        }
        return result;
    }
}
