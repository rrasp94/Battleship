namespace Model;

public struct SquareCoordinate
{
    public SquareCoordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public readonly int Row;
    public readonly int Column;
}
