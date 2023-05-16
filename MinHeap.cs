public class MinHeap
{
    private int[] heapArray;
    private int count;

    public int Count { get { return count; } }
    public int this[int i]
    {
        get { return heapArray[i]; }
        set { heapArray[i] = value; }
    }
    public MinHeap(int size)
    {
        if (size > 10000)
            throw new ArgumentOutOfRangeException("size", "Размер кучи не должен превышать 10000");
        heapArray = new int[size];
        count = 0;
    }
    public MinHeap() : this(10) { }

    public int Parent(int index)
    {
        if (index >= count || index < 0)
        {
            throw new IndexOutOfRangeException("Неверный индекс");
        }
        else if (index == 0)
        {
            throw new IndexOutOfRangeException("Невозможно найти родительский узел для корневого элемента");
        }
        return heapArray[(index - 1) / 2];
    }

    public int? LeftChildren(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Неверный индекс");
        int left_index = 2 * index + 1;
        if (left_index >= count)
        {
            return null;
        }
        else
            return heapArray[left_index];
    }
    public int? RightChildren(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Неверный индекс");
        int right_index = 2 * index + 2;
        if (right_index >= count)
        {
            return null;
        }
        else
            return heapArray[right_index];
    }

    public void SiftUp(int index)
    {
        if (index == 0)
            return;
        else if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Неверный индекс");
        }
        int parent_index = (index - 1) / 2;
        if (heapArray[parent_index] > heapArray[index])
        {
            int temp = heapArray[parent_index];
            heapArray[parent_index] = heapArray[index];
            heapArray[index] = temp;
            SiftUp(parent_index);
        }
    }

    public void SiftDown(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Неверный индекс");
        }
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int smallest = index;
        if (leftChild < count && heapArray[leftChild] < heapArray[smallest])
        {
            smallest = leftChild;
        }
        if (rightChild < count && heapArray[rightChild] < heapArray[smallest])
        {
            smallest = rightChild;
        }
        if (smallest != index)
        {
            int temp = heapArray[index];
            heapArray[index] = heapArray[smallest];
            heapArray[smallest] = temp;
            SiftDown(smallest);
        }
    }

    public void BuildHeap(int[] arr)
    {
        if (arr.Length > heapArray.Length)
        {
            throw new ArgumentOutOfRangeException("arr", "Размер входного массива превышает размер кучи");
        }
        count = arr.Length;
        Array.Copy(arr, heapArray, count);
        for (int i = count / 2 - 1; i >= 0; i--)
        {
            SiftDown(i);
        }
    }

    public int ExtractMin()
    {
        if (count <= 0)
        {
            throw new InvalidOperationException("Куча пуста");
        }
        int min = heapArray[0];
        heapArray[0] = heapArray[count - 1];
        count--;
        if (count != 0)
            SiftDown(0);
        return min;
    }

    public void Insert(int value)
    {
        if (count >= heapArray.Length)
        {
            throw new InvalidOperationException("Куча заполнена");
        }
        heapArray[count] = value;
        count++;
        SiftUp(count - 1);
    }

    public int[] HeapSort()
    {
        int[] sorted_arr = new int[count];
        for (int i = 0; i < sorted_arr.Length; i++)
        {
            sorted_arr[i] = ExtractMin();
        }
        heapArray = sorted_arr;
        count = sorted_arr.Length;
        return sorted_arr;
    }

    public override string ToString()
    {
        return string.Join(", ", heapArray.Take(count));
    }
}