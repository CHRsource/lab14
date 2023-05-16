public class PriorityQueue
{
    private MinHeap minHeap;

    public PriorityQueue(int size)
    {
        minHeap = new MinHeap(size);
    }

    public PriorityQueue() : this(10) { }

    public void Enqueue(int value)
    {
        minHeap.Insert(value);
    }

    public int? Dequeue()
    {
        try
        {
            return minHeap.ExtractMin();
        }
        catch (InvalidOperationException)
        {
            return null; // Значение null может быть использовано для обозначения пустой очереди
        }
    }

    public void DecreaseValue(int index, int newValue)
    {
        if (index < 0 || index >= minHeap.Count)
        {
            throw new IndexOutOfRangeException("Неверный индекс");
        }
        if (newValue > minHeap[index])
        {
            throw new ArgumentException("Новое значение должно быть меньше или равно текущему значению");
        }
        minHeap[index] = newValue;
        minHeap.SiftUp(index);
    }
}
