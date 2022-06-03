/*
Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
*/

int GetDemension(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] FillArray(int firstDemension, int secondDemention)
{
    Random rnd = new Random();
    int[,] arr = new int[firstDemension, secondDemention];
    for (int i = 0; i < firstDemension; i++)
    {
        for (int j = 0; j < secondDemention; j++) arr[i, j] = rnd.Next(0, 10);
    }
    return arr;
}

void PrintArray(int[,] arr)
{
    int[] array = new int[10];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {    
            array[arr[i,j]] ++;
            Console.Write(arr[i,j]);
        }   
        Console.WriteLine();
    }
    Console.WriteLine();
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i]!=0)
            Console.WriteLine($"{i} встречается {array[i]} раз");
    }
}

int firstDemension = GetDemension("Введите размер первого разряда: ");
int secondDemention = GetDemension("Введите размер второго разряда: ");
int[,] arr = FillArray(firstDemension, secondDemention);
Console.WriteLine("массив чисел");
PrintArray(arr);
