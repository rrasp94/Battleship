namespace Model;

public enum SquareState
{
    Intact,
    Eliminated,
    Missed,
    Hit,
    Sunken
}

public class Square
{
    public Square(int row, int column)
    {
        Row = row;
        Column = column;
        SquareState = SquareState.Intact;
    }

    public readonly int Row;
    public readonly int Column;

    public void Hit()
    {
        SquareState = SquareState.Hit;
    }

    public void ChangeState(SquareState newState)
    {
        if ((int)newState > (int)SquareState)
        {
            SquareState = newState;
        }
    }

    public bool IsHit => (int)SquareState >= (int)SquareState.Hit;

    public SquareState SquareState { get; private set; }
}