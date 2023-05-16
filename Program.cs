#pragma warning disable

// задание 1

//string path = @"..\..\..\data14.txt";
////File.WriteAllLines(path, new string[] { "5", "0 2 5 3 4" });
//File.WriteAllLines(path, new string[] { "5", "2 1 4 3 5" });
//int[] arr;

//using (StreamReader sr = new(path))
//{
//    int n = int.Parse(sr.ReadLine());
//    arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
//    if (arr.Length != n)
//        throw new ArgumentOutOfRangeException("n", "Количество чисел в массиве не совпадает с переменной n");
//    if (IsMinHeap(arr))
//        Console.WriteLine("YES.");
//    else Console.WriteLine("NO.");
//}
//MinHeap h = new MinHeap(arr.Length);

//static bool IsMinHeap(int[] arr)
//{
//    int n = arr.Length;
//    for (int i = 0; i < n / 2; i++)
//    {
//        int left = 2 * i + 1;
//        int right = 2 * i + 2;
//        if (left < n & arr[i] > arr[left])
//            return false;
//        if (right < n & arr[i] > arr[right])
//            return false;
//    }
//    return true;
//}


//// задание 2

//h.BuildHeap(arr);
//Console.WriteLine("Куча: " + h);


//// Задание 3

//int[] sorted = h.HeapSort();
//Console.WriteLine("Отсортированный массив: " + string.Join(", ", sorted.Take(sorted.Length)));


// задание 4

string path = @"..\..\..\data14_2.txt";
string path2 = @"..\..\..\output14.txt";
File.WriteAllLines(path, new string[] { "8", "A 3", "A 4", "A 2", "X", "D 1 1", "X", "X", "X" });
var f = File.Create(path2);
f.Close();

int n;
PriorityQueue queue = new();

using (StreamReader sr = new(path))
{
    n = int.Parse(sr.ReadLine());
    for (int i = 0; i < n; i++)
    {
        string[] s = sr.ReadLine().Split();
        if (s[0] == "A")
            queue.Enqueue(int.Parse(s[1]));
        else if (s[0] == "X")
        {
            int? res;
            if ((res = queue.Dequeue()) == null)
                File.AppendAllText(path2, "*\n");
            else File.AppendAllText(path2, res.ToString() + "\n");
        }
        else if (s[0] == "D")
            queue.DecreaseValue(int.Parse(s[1]), int.Parse(s[2]));
    }
}


