using Model;

namespace ModelTests;

[TestClass]
public class LimitedQueueTests
{
    [TestMethod]
    public void EnqueueInsertsItmToQueue()
    {
        var queue = new LimitedQueue<int>(3);

        Assert.AreEqual(0, queue.Count);

        queue.Enqueue(1);

        Assert.AreEqual(1, queue.Count);

        queue.Enqueue(3);

        Assert.AreEqual(2, queue.Count);
    }

    [TestMethod]
    public void QueueRemovesExtraItemsAfterItIsFilled()
    {
        var queue = new LimitedQueue<int>(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.AreEqual(3, queue.Count);

        queue.Enqueue(4);
        Assert.AreEqual(3, queue.Count);
        Assert.IsFalse(queue.Contains(1));

        queue.Enqueue(5);
        Assert.AreEqual(3, queue.Count);
        Assert.IsFalse(queue.Contains(2));
    }
}