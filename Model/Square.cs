namespace Model;

public class Square
{
    public readonly int Row;
    public readonly int Column;

    public Square(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public void Hit()
    {
        hit = true;
    }

    public bool IsHit => hit;

    private bool hit = false;
}