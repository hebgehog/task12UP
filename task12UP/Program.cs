using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12UP
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0, counter = 1;
            bool exit = false;
            Console.WriteLine("Введите количество элементов массива: ");
            while (!exit)
            {
                N = wwww();
                if (N <= 0) { Console.WriteLine("Такой размерности массива не существует, или он пуст"); }
                else { exit = true; }
            }
            int[] arr = new int[N];
            int[] arr1 = new int[N];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Введите {0}-й элемент массива", counter);
                counter++;
                arr[i] = wwww();
            }
            for (int i = 0; i < arr.Length; i++) { arr1[i] = arr[i]; }
            Console.WriteLine();
            Console.WriteLine("Вывод массива: ");
            WriteArray(arr);
            Console.WriteLine("Сортировка перемешиванием: ");
            ShakerSort(arr);
            Console.WriteLine("Вывод массива: ");
            WriteArray(arr);
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++) { arr[i] = arr1[i]; }
            Console.WriteLine("Сортировка простыми вставками: ");
            SortVstavki(arr);
            Console.WriteLine("Вывод массива: ");
            WriteArray(arr);
            Console.WriteLine();

            Console.ReadKey();
        }
        static void ShakerSort(int[] arr)
        {
            int left = 0,
            right = arr.Length - 1,
            count = 0;
            Console.WriteLine("Пересылки");
            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        WriteArray(arr);
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (arr[i - 1] > arr[i])
                    {
                        Swap(arr, i - 1, i);
                        WriteArray(arr);
                    }
                }
                left++;
            }
            Console.WriteLine("Количество сравнений = {0}", count.ToString());
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
            int counter = 0;
            int x, i, j;
            Console.WriteLine("Пересылки");
            for (i = 0; i < arr.Length; i++)
            {
                x = arr[i];
                for (j = i - 1; j >= 0 && arr[j] > x; j--)
                    arr[j + 1] = arr[j];
                counter++;
                arr[j + 1] = x;
                WriteArray(arr);
            }
            Console.WriteLine("Количество сравнений = {0}", counter.ToString());
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