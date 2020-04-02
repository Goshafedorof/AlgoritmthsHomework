using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                #region Menu
                Console.WriteLine("Выполнил: Федоров Игорь.");
                Console.WriteLine("Меню:");
                Console.WriteLine("# - Краткое описание программы");
                Console.WriteLine("1 - Количество маршрутов с препятствиями;");
                Console.WriteLine("2 - Нахождение длины максимальной последовательности;");

                Console.Write("\nВведите номер программы (для выхода - любой другой символ): ");
                #endregion

                string sign = Console.ReadLine();

                Console.Clear();

                switch (sign)
                {
                    case "1":
                        ObstacleRoutes();
                        break;
                    case "2":
                        MaxSubsequence();
                        break;
                    default:
                        return;
                }

                Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
                Console.ReadKey();

                Console.Clear();
            }
        }

        private static void MaxSubsequence()
        {
            //Console.WriteLine("Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.\n");

            //Console.Write("Введите строки (регистр не имеет значения):");
            //Console.Write("Первая строка: ");
            //string line_1 = Console.ReadLine().Trim().ToUpper();

            //Console.Write("Вторая строка: ");
            //string line_2 = Console.ReadLine().Trim().ToUpper();

            string line_2 = "geekbrains";
            string line_1 = "geekminds";

            int rowCount = line_1.Length + 1;
            int columnCount = line_2.Length + 1;

            int[][] map = new int[rowCount][];

            for (int row = 0; row < rowCount; row++)             
                map[row] = new int[columnCount];

            int value = 0;

            for (int column = 1; column < columnCount; column++)
            {
                map[1][column] = map[1][column - 1];

                for (int row = 1; row < rowCount; row++)
                {
                    if (line_1[row - 1] == line_2[column - 1])
                    {
                        value++;
                        map[row][column] = value;
                    }
                    else
                    {
                        map[row][column] = map[row - 1][column];
                    }
                    
                }
            }



            //for (int row = 0; row < rowCount; row++)
            //{
            //    bool finded = false;

            //    for (int column = 0; column < columnCount; column++)
            //    {
            //        if (!finded && line_1[row] == line_2[column])
            //        {
            //            value += 1;
            //            map[row][column] = value;
            //            break;
            //        }
            //        else
            //        {
            //            map[row][column]
            //        }
            //    }
            //}

            PrintArray(map);
        }

        private static void ObstacleRoutes()
        {
            Console.WriteLine("Количество маршрутов с препятствиями.\n");
            
            Console.Write("Количество строк в поле: ");
            int rowCount = int.Parse(Console.ReadLine());
            
            Console.Write("Количество столбцов в поле: ");
            int columnCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите карту препятствий");
            Console.WriteLine("где 0 - разрешенная позиция, 1 - барьер\n");

            bool[][] mapObstacle = new bool[columnCount][];

            for (int row = 0; row < rowCount; row++)
            {
                mapObstacle[row] = new bool[columnCount];

                int[] line;

                bool continiued = true;

                // ввод строки
                do
                {
                    Console.Write("Строка {0:D2}: ", row + 1);

                    line = StringToArray(Console.ReadLine());

                    continiued = line.Length != columnCount;

                    if (!continiued)
                        for (int column = 0; column < columnCount; column++)                        
                            mapObstacle[row][column] = line[column] == 1;
                        
                } while (continiued);
            }

            // проверка на правильность ввода данных
            if (mapObstacle[0][0])
            {
                Console.WriteLine("Левая верхняя позиция занята - невозможно начать поиск");
                return;
            }

            int[][] map = new int[rowCount][];

            // в самый левый верхний элемент всегда можно прийти один раз
            map[0] = new int[columnCount];
            map[0][0] = 1;             

            for (int row = 1; row < rowCount; row++)
            {
                map[row] = new int[columnCount];
                // в первой строке значение 0 или 1 также будет зависить от предыдущих
                map[row][0] = mapObstacle[row][0] ? 0 : map[row - 1][0];
            }

            for (int column = 1; column < columnCount; column++)
            {
                // в первой строке значение 0 или 1 также будет зависить от предыдущих
                map[0][column] = mapObstacle[0][column] ? 0 : map[0][column - 1];

                for (int row = 1; row < rowCount; row++)
                {
                    if (mapObstacle[row][column])
                    {
                        map[row][column] = 0;
                    }
                    else
                    {
                        map[row][column] = map[row - 1][column] + map[row][column - 1];
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Количество маршрутов с препятствиями:");
            Console.WriteLine();
            PrintArray(map, mapObstacle);
            Console.WriteLine();
        }

        private static void PrintArray(int[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                string line = string.Empty;

                for (int column = 0; column < array[row].Length; column++)
                {
                    line += array[row][column].ToString("D3") + " ";
                }

                Console.WriteLine(line);
            }        
        }

        private static void PrintArray(int[][] array, bool[][] obstacles)
        {
            for (int row = 0; row < array.Length; row++)
            {
                string line = string.Empty;

                for (int column = 0; column < array[row].Length; column++)
                {
                    line += string.Format("{0} ", obstacles[row][column] ? "***" : array[row][column].ToString("D3"));
                }

                Console.WriteLine(line);
            }
        }

        private static int[] StringToArray(string line)
        {
            string[] valuesStr = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[valuesStr.Length];

            for (int i = 0; i < array.Length; i++)
                array[i] = int.Parse(valuesStr[i]);

            return array;
        }
    }
}
