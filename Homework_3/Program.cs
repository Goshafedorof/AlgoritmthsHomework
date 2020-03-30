using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Program
    {
        private static readonly int[] BASE_ARRAY = new int[] { 55, 44, 33, 22, 11, 10, 5, 0, };

        static void Main(string[] args)
        {
            Console.WriteLine("Выполнил: Федоров Игорь");
            Console.WriteLine();
            Console.WriteLine("Массив входных данных: {0}", ArrayToString(BASE_ARRAY));
            Console.WriteLine();

            int[] array = new int[BASE_ARRAY.Length];

            #region Задача 1

            Console.WriteLine("Задача 1. Оптимизация пузырьковой сортировки:");
                        
            Array.Copy(BASE_ARRAY, array, BASE_ARRAY.Length);

            int perfomance = BubbleSort(ref array);
            Console.WriteLine("Сортировка пузырьком:   [{0}] - произв-ть = {1}", ArrayToString(array), perfomance);
            
            Array.Copy(BASE_ARRAY, array, BASE_ARRAY.Length);
            perfomance = BubbleSortModificate(ref array);
            Console.WriteLine("сортировка пузырьком-М: [{0}] - произв-ть = {1}", ArrayToString(array), perfomance);
            Console.WriteLine();
            #endregion

            #region Задача 2

            Console.WriteLine("Задача 2. Шейкерная сортировка:");

            Array.Copy(BASE_ARRAY, array, BASE_ARRAY.Length);

            perfomance = SheakerSort(ref array);
            Console.WriteLine("Шейкерная сортировка:   [{0}] - произв-ть = {1}", ArrayToString(array), perfomance);
            Console.WriteLine();
            #endregion

            #region Задача 3

            Console.WriteLine("Задача 3. Бинарный алгоритм поиска:");
            Console.Write("Введите число для поиска: ");

            int value = int.Parse(Console.ReadLine());
            int index = BinarySearch(value, ref array);

            if (index != -1)
            {
                Console.WriteLine("Индекс найден: МАССИВ[{0}] == {1}", index, value);
            }
            else
            {
                Console.WriteLine("Значение {0} не найдено", value);
            }
            Console.WriteLine();
            #endregion

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static string ArrayToString(int[] array)
        {
            string line = string.Empty;

            for (int i = 0; i < array.Length; i++)
                line += string.Format("{0} ", array[i]);

            return line;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="array">массив</param>
        public static int BubbleSort(ref int[] array)
        {
            int counterPerfomance = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    counterPerfomance++;

                    if (array[j] > array[j + 1])
                    {
                        counterPerfomance++;

                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return counterPerfomance;
        }

        /// <summary>
        /// Модернизированная соротировка пузырьком
        /// </summary>
        /// <param name="array"></param>
        public static int BubbleSortModificate(ref int[] array)
        {
            int counterPerfomance = 0;
            // расчет вложенной длины с учетом того, что в конце всегда отсортировано
            int nestedLength = array.Length;
            // последний проход не учитвается, так как на предпоследнем проходе первый и второй элемент меняются местами
            for (int i = 0; i < array.Length - 1; i++)
            {
                nestedLength--;

                for (int j = 0; j < nestedLength; j++)
                {
                    counterPerfomance++;

                    if (array[j] > array[j + 1])
                    {
                        counterPerfomance++;

                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return counterPerfomance;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="array"></param>
        public static int SheakerSort(ref int[] array)
        {
            int counterPerfomance = 0;

            int startPosition = 0;
            int stopPosition = array.Length - 1;

            while (startPosition <= stopPosition)
            {
                for (int j = startPosition; j < stopPosition; j++)
                {
                    counterPerfomance++;

                    if (array[j] > array[j + 1])            
                    {
                        counterPerfomance++;
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }

                stopPosition--;

                for (int j = stopPosition; j > startPosition; j--)
                {
                    counterPerfomance++;

                    if (array[j] < array[j - 1])
                    {
                        counterPerfomance++;
                        Swap(ref array[j], ref array[j - 1]);
                    }
                }

                startPosition++;
            }

            return counterPerfomance;
        }

        /// <summary>
        /// Бинарный поиск
        /// </summary>
        /// <param name="value"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int BinarySearch(int value, ref int[] array)
        {
            int left = 0;
            int rigth = array.Length - 1;

            int middle = left + (rigth - left) / 2;

            while (array[middle] != value && left <= rigth)
            {
                if (array[middle] < value)
                    left = middle + 1;
                else
                    rigth = middle - 1;

                middle = left + (rigth - left) / 2;
            }

            return array[middle] != value ? -1 : middle;
        }
    }
}
