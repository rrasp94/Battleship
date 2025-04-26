using System.Collections;

namespace Model;

public class LimitedQueue<T> : Queue<T>
{
    private readonly int _maxItems;
    public LimitedQueue(int maxItems)
    {
        _maxItems = maxItems;
    }
    public new void Enqueue(T item)
    {
        while (Count >= _maxItems)
        {
            Dequeue();
        }
        base.Enqueue(item);
    }
}
