using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int[] array;

            Console.WriteLine("=== Лабораторная работа №1 ===");
            Console.WriteLine("Выберите способ ввода массива:");
            Console.WriteLine("1 - Ввод с клавиатуры");
            Console.WriteLine("2 - Генерация случайных чисел");
            Console.WriteLine("3 - Чтение из файла (input.txt)");
            Console.Write("Ваш выбор (1-3): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Ввод с клавиатуры
                Console.Write("Введите размер массива N: ");
                n = Convert.ToInt32(Console.ReadLine());
                array = new int[n];

                Console.WriteLine("Введите элементы массива по одному:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"array[{i}] = ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (choice == "2")
            {
                // Заполнение случайными числами
                Console.Write("Введите размер массива N: ");
                n = Convert.ToInt32(Console.ReadLine());
                array = new int[n];

                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    // Генерируем числа от -50 до 50
                    array[i] = rnd.Next(-50, 51);
                }
            }
            else if (choice == "3")
            {
                // Чтение из файла
                // Ожидается, что на диске есть файл input.txt,
                string path = "input.txt";

                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    n = Convert.ToInt32(reader.ReadLine());
                    array = new int[n];

                    for (int i = 0; i < n; i++)
                    {
                        array[i] = Convert.ToInt32(reader.ReadLine());
                    }
                    reader.Close();
                    Console.WriteLine("Данные успешно прочитаны из файла input.txt!");
                }
                else
                {
                    Console.WriteLine("Файл input.txt не найден! Создаем массив по умолчанию на 5 элементов.");
                    n = 5;
                    array = new int[] { -10, 5, -3, 8, 2 };
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор. Создан массив по умолчанию.");
                n = 5;
                array = new int[] { 4, -7, 2, -1, 10 };
            }

            // Выводим полученный массив на экран
            Console.WriteLine("\nИсходный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();



            int firstNeg = 0;      // Первое отрицательное число
            bool foundNeg = false;

            int lastPos = 0;       // Последнее положительное число
            bool foundPos = false;

            // Ищем первое отрицательное число
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0)
                {
                    firstNeg = array[i];
                    foundNeg = true;
                    break;
                }
            }

            // Ищем последнее положительное число
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                {
                    lastPos = array[i];
                    foundPos = true;
                }
            }

            // Вывод результатов и расчет среднего арифметического
            Console.WriteLine("\n--- Результаты ---");

            if (foundNeg && foundPos)
            {
                Console.WriteLine("Первый отрицательный элемент: " + firstNeg);
                Console.WriteLine("Последний положительный элемент: " + lastPos);

                // Приводим к double, чтобы среднее было с дробной частью
                double avg = (double)(firstNeg + lastPos) / 2.0;
                Console.WriteLine("Среднее арифметическое = " + avg);
            }
            else
            {
                if (!foundNeg)
                {
                    Console.WriteLine("В массиве нет отрицательных элементов!");
                }
                if (!foundPos)
                {
                    Console.WriteLine("В массиве нет положительных элементов!");
                }
                Console.WriteLine("Невозможно вычислить среднее арифметическое.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
