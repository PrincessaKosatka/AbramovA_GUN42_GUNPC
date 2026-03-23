class Programm
{
    static void Main(string[] args)
    {
        // Задание А
        // Первый массив Чи́сла Фибона́ччи 
        int[] Fibonaccinumbers = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

        // Массив 12 месяцев
        string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        // Двумерный массив (матрицу) 3x3
        int[,] Matrix = new int[3, 3]
        {
            { 2, 3, 4 },
            { 4, 9, 16 }, // Тут можно было написать функцию Math.Pow
            { 8, 27, 64 }
        };

        // Jagged array (ломанный массив)
        double[][] jaggedArray = new double[3][];

        // Первый массив - числа от 1 до 5
        jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };

        // Второй массив - константы e и pi
        jaggedArray[1] = new double[] { Math.E, Math.PI };

        // Третий массив - логарифм по основанию 10 чисел 1, 10, 100, 1000
        jaggedArray[2] = new double[]

        {
            Math.Log10(1),
            Math.Log10(10),
            Math.Log10(100),
            Math.Log10(1000)
        };

        // Задание Б
        // Задание 5 // Скопируйте первые 3 элемента первого массива во второй

        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
        Array.Copy(array, 0, array2, 0, 3);

        // Задание 6 
        int[] sample = { 1, 2, 3, 4, 5 };
        Array.Resize(ref sample, sample.Length * 2);

        //   До изменения размера:
        //   array: 1, 2, 3, 4, 5
        //   Длина array: 5

        //   После изменения размера:
        //   array: 1, 2, 3, 4, 5, 0, 0, 0, 0, 0
        //   Длина array: 10

    }
}