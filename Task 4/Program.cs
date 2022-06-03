/*Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, 
на пересечении которых расположен наименьший элемент массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим 
следующий массив:
9 4 2
2 2 6
3 4 7
*/

int[,] RandomArrayCreation(int rows , int colums , int minRandom , int maxRandom)//вставил на всякий случай 
                                                                                 //возможность изменения рандомности чисел
{
    Random rnd = new Random();
    int[,] array = new int[rows,colums];
    for ( int i = 0 ; i < rows ; i ++)
        for ( int j = 0 ; j < colums ; j ++)
            array[i,j] = rnd.Next(minRandom,maxRandom+1);
return array;
}

int NumberInput(string text)//Метод ввода и проверки на число
{
    bool isInputInt = true;
    int number =0;
    while (isInputInt)
    {
        Console.Write($"Введите {text} :");
        string numberSTR = Console.ReadLine();
        if (int.TryParse(numberSTR, out int numberInt))
        {
            if (numberInt <= 0) Console.WriteLine("Введите число больше нуля");
            else
            {
                number = numberInt;
                isInputInt = false;
            } 
        }
        else 
            Console.WriteLine("Ввели не число");
    }
    return number;
}

void ArrayPrint(int[,] array)
{
    Console.Write("\n");
    for ( int i = 0 ; i < array.GetLength(0) ; i ++)
    {
        Console.Write($"Строка {i+1}");
        for ( int j = 0 ; j < array.GetLength(1) ; j ++)
            Console.Write($"\t{array[i,j],3}"); 
        Console.Write("\n");
    }
}

(int,int,int) MinIndexInArray(int[,] array)
{
    int min = array[0,0];
    int minIndexRow = -1;
    int minIndexColum = -1;
    for ( int i = 0 ; i < array.GetLength(0); i ++)
        for ( int j = 0 ; j < array.GetLength(1); j++)
            if (array[i,j] < min )
            {
                minIndexRow = i;
                minIndexColum = j;
                min = array[i,j];
            }
    return (minIndexRow,minIndexColum,min);
}

int[,] DeleteLaneAndColumInArray(int[,] array , int rowToDelete, int columToDelete)
{
    int x = 0;
    int y = 0;
    int[,] arrayNew = new int[array.GetLength(0)-1,array.GetLength(1)-1];
    for ( int i = 0 ; i < array.GetLength(0) ; i++)
        if ( i != rowToDelete) 
        {   
            y = 0;
            for ( int j = 0 ; j < array.GetLength(1) ; j ++)
            {
                if ( j != columToDelete) 
                {
                    arrayNew[x,y] = array[i,j];
                    y++;
                }
            }
            x++;
        }
    return arrayNew;
}

int rows = NumberInput("кол-во строк");
int colums = NumberInput("кол-во столбцов");

int[,] array= RandomArrayCreation( rows:rows,
                                    colums:colums,
                                    minRandom:0,
                                    maxRandom:9);
Console.Write("\n Изначальный массив:");
ArrayPrint(array);
(int minIndexRow, int minIndexColum, int min) = MinIndexInArray(array);
int[,] arrayNew = DeleteLaneAndColumInArray(array,minIndexRow,minIndexColum);
Console.Write($"\n Новый массив удаляя {min}:");
ArrayPrint(arrayNew);
