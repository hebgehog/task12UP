using System;
using System.Diagnostics;

namespace task12UP
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan time;
            Stopwatch t = new Stopwatch();//переменная для подсчета времени 
            int N = 0;
            bool exit = false;
            Console.WriteLine("\nВведите количество элементов массива: ");
            while (!exit)
            {
                N = wwww();
                if (N <= 0) { Console.WriteLine("Такой размерности массива не существует, или он пуст"); }
                else { exit = true; }
            }
            int[] arr = new int[N];//заполняемый 
            int[] arr1 = new int[N];//копия 
            int[] arrYV = new int[N];
            int[] arrYY = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
            arr1 = arr;
            arrYV = arr;
            Array.Sort(arrYV);
            arrYY = arr;
            Array.Sort(arrYY);
            Array.Reverse(arrYV);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=========================== СОРТИРОВКА ПЕРЕМЕШИВАНИЕМ ===========================");
            Console.ResetColor();
            Console.WriteLine("\nНЕупорядоченный массив \nВывод массива: ");
            WriteArray(arr);
            t = new Stopwatch();
            t.Start();
            ShakerSort(arr);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arr);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();

            Console.WriteLine("\nУпорядоченный по ВОЗРАСТАНИЮ массив \nВывод массива: ");
            WriteArray(arrYV);
            t = new Stopwatch();
            t.Start();
            ShakerSort(arrYV);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arrYV);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();

            Console.WriteLine("\nУпорядоченный по УБЫВАНИЮ массив \nВывод массива: ");
            WriteArray(arrYY);
            t = new Stopwatch();
            t.Start();
            ShakerSort(arrYY);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arrYY);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n=========================== СОРТИРОВКА ПРОСТЫМИ ВСТАВКАМИ ===========================");
            Console.ResetColor();
            arr = arr1;
            arrYV = arr;
            Array.Sort(arrYV);
            arrYY = arr;
            Array.Sort(arrYY);
            Array.Reverse(arrYV);

            Console.WriteLine("\nНЕупорядоченный массив \nВывод массива: ");
            WriteArray(arr);
            t = new Stopwatch();
            t.Start();
            SortVstavki(arr);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arr);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();


            Console.WriteLine("\nУпорядоченный по ВОЗРАСТАНИЮ массив \nВывод массива: ");
            WriteArray(arrYV);
            t = new Stopwatch();
            t.Start();
            SortVstavki(arrYV);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arrYV);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();

            Console.WriteLine("\nУпорядоченный по УБЫВАНИЮ массив \nВывод массива: ");
            WriteArray(arrYY);
            t = new Stopwatch();
            t.Start();
            SortVstavki(arrYY);
            t.Stop();
            time = t.Elapsed;
            Console.WriteLine("Вывод массива после сортировки: ");
            WriteArray(arrYY);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Время сортировки: " + time.ToString());
            Console.ResetColor();
            Console.ReadKey();
        }
        static void ShakerSort(int[] arr)
        {
            int count1 = 0;
            int left = 0,
            right = arr.Length - 1,
            count = 0;
            Console.WriteLine("Пересылки: ");
            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        count++;
                        Swap(arr, i, i + 1);
                        WriteArray(arr);
                        count1++;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {

                    if (arr[i - 1] > arr[i])
                    {
                        count++;
                        Swap(arr, i - 1, i);
                        WriteArray(arr);
                        count1++;
                    }
                }
                count++;
                left++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Количество перемещений = {0} \nКоличество сравнений = {1}", count1, count.ToString());
            Console.ResetColor();
        }
        static void Swap(int[] arr, int i, int j)
        {
            int glass = arr[i];
            arr[i] = arr[j];
            arr[j] = glass;
        }
        static void WriteArray(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0} ", i.ToString());
            Console.WriteLine();
        }
        static void SortVstavki(int[] arr)
        {
            int counter1 = 0;
            int counter = 0;
            int x, i, j;
            Console.WriteLine("Пересылки");
            for (i = 0; i < arr.Length; i++)
            {
                x = arr[i];
                for (j = i - 1; j >= 0 && arr[j] > x; j--)
                {
                    arr[j + 1] = arr[j];
                    counter1++;
                    counter++;
                    WriteArray(arr);
                }
                counter++;
                arr[j + 1] = x;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Количество перемещений = {0} \nКоличество сравнений = {1}", counter1, counter.ToString());
            Console.ResetColor();
        }
        static int wwww()
        {
            while (true)
            {
                int number;
                if (int.TryParse(Console.ReadLine(), out number))
                    return number;
                else
                    Console.WriteLine("Ошибка, введите еще раз");
            }
        }
    }
}