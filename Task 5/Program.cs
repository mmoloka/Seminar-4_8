/*
Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника
0 _ _ _ _ C00
1 _ _ _ C01 _ C11
2 _ _ C02 _ C12 _C22
3 _ C03 _ C13 _ C23 _ C33
4 C04 _ C14 _ C24 _ C34 _ C44

n C0n C1n C2n ..................Cnn
*/
int GetFactorial(int number)
{
    int factorialNumber =1;
    for(int i = 1; i <= number; i++)
        factorialNumber *= i;
    return factorialNumber;
}
void GetNumberOfPascalTriangle(int number)
{
    for(int i = 0; i < number; i++)
    {
        for(int j = 0; j <= number - i; j++)
            Console.Write(" ");
        for(int k = 0; k <= i; k++)
        {
            Console.Write(GetFactorial(i) / (GetFactorial(k) * GetFactorial(i - k)));
            Console.Write(" ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}




Console.WriteLine("Ввеите количество строк треугольника Паскаля: ");
int n = Convert.ToInt32(Console.ReadLine());
GetNumberOfPascalTriangle(n);