namespace Model;

public class Ship
{
    public Ship(IEnumerable<Square> squares)
    {
        this.squares = squares;
    }

    private readonly IEnumerable<Square> squares;

    public bool Contains(int row, int column)
    {
        return squares.FirstOrDefault(sq => sq.Row == row && sq.Column == column) != null;
    }
}
