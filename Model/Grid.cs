namespace Model.Model;


public class Grid
{
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

    public readonly int Rows;
    public readonly int Columns;

    private readonly Square?[,] squares;


    public IEnumerable<Square> Squares
    {
        get { return squares.Cast<Square>().Where(s => s != null); }
    }

    public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
    {
        return GetHorizontalAvailablePlacements(length).Concat(GetVerticalAvailablePlacements(length));
    }

    private IEnumerable<IEnumerable<Square>> GetHorizontalAvailablePlacements(int length)
    {
        List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();

        for (int r = 0; r < Rows; ++r)
        {
            var queue = new LimitedQueue<Square>(length);
            for (int c = 0; c < Columns; ++c)
            {
                if (squares[r, c] != null)
                {
                    queue.Enqueue(squares[r, c]!);
                    if (queue.Count() == length)
                    {
                        result.Add(queue.ToArray());
                    }
                }
                else
                {
                    queue.Clear();
                }
            }
        }
        return result;
    }

    private IEnumerable<IEnumerable<Square>> GetVerticalAvailablePlacements(int length)
    {
        List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();

        for (int c = 0; c < Columns; ++c)
        {
            var queue = new LimitedQueue<Square>(length);
            for (int r = 0; r < Rows; ++r)
            {
                if (squares[r, c] != null)
                {
                    queue.Enqueue(squares[r, c]!);
                    if (queue.Count() == length)
                    {
                        result.Add(queue.ToArray());
                    }
                }
                else
                {
                    queue.Clear();
                }
            }
        }
        return result;
    }

    public void EleminateSquare(int row, int column)
    {
        squares[row, column] = null;
    }

}


