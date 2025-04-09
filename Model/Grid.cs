using Model;


public class Grid
{
    public readonly int Rows;
    public readonly int Columns;

    private readonly Square?[,] squares;

    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        squares = new Square[Rows, Columns];

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                squares[r, c] = new Square(r, c);
            }
        }
}

public IEnumerable<Square> Squares
{
    get { return squares.Cast<Square>().Where(s => s != null); }
}

}
