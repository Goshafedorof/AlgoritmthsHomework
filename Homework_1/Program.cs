using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Федоров Игорь
namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continued = true;                  // флаг "продолжать выполнение программы"

            while (continued)
            {
                #region Menu
                Console.WriteLine("Выполнил: Федоров Игорь.");
                Console.WriteLine("Меню:");
                Console.WriteLine("# - Краткое описание программы");
                Console.WriteLine("1 - Расчет индекса массы тела;");
                Console.WriteLine("2 - Нахождение максимального числа из четрыех;");
                Console.WriteLine("3 - Обмен значениями двух целочисленных переменных;");
                Console.WriteLine("4 - Шахматная задачка;");

                Console.Write("\nВведите номер программы (для выхода - любой другой символ): ");
                #endregion

                string sign = Console.ReadLine();

                Console.Clear();

                switch (sign)
                {
                    case "1":                        
                        Bmi();
                        break;
                    case "2":                        
                        MaxValue();
                        break;
                    case "3":
                        ChangeVariable();
                        break;
                    case "4":
                        Chess();
                        break;

                    default:
                        continued = false;
                        break;
                }

                Console.Clear();
            }
        }

        private static void Bmi()
        {
            Console.WriteLine("Рассчет индекса массы тела.\n");
            Console.Write("Масса тела, кг: ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("Рост, м: ");
            float height = float.Parse(Console.ReadLine());

            float bmi = weight / (height * height);
            Console.WriteLine("{0}Индекс массы тела составляет: {1:F3} (кг/м^2){0}", Environment.NewLine, bmi);

            Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        private static void MaxValue()
        {
            Console.WriteLine("Максимальное из четырех чисел.\n");
            Console.Write("Введите четыре числа, формат ввода V_1 V_2 V_3 V_4: ");

            string line = Console.ReadLine();
            string[] values = line.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            int v_1 = int.Parse(values[0]);
            int v_2 = int.Parse(values[1]);
            int v_3 = int.Parse(values[2]);
            int v_4 = int.Parse(values[3]);

            // проверка первой пары
            v_1 = v_1 > v_2 ? v_1 : v_2;
            // проверка второй пары
            v_3 = v_3 > v_4 ? v_3 : v_4;
            // проверка наибольших
            v_1 = v_1 > v_3 ? v_1 : v_3;

            Console.WriteLine("{0}Максимальное число: {1}", Environment.NewLine, v_1);

            Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        private static void ChangeVariable()
        {
            Console.WriteLine("Обмен значениями двух целочисленных переменных.\n");

            // Ввод переменных
            Console.Write("Переменная V_1 = ");
            int v_1 = int.Parse(Console.ReadLine());
            Console.Write("Переменная V_2 = ");
            int v_2 = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Способ обмена пременными:");
            Console.WriteLine("\"1\" - с использование третьей переменной;");
            Console.WriteLine("\"2\" - без использования третьей переменной.");
            Console.Write("\nВведите номер способа (для выхода - любой другой символ): ");
            
            string sign = Console.ReadLine();

            switch (sign)
            {
                case "1":            
                    int v_3 = v_1;
                    v_1 = v_2;
                    v_2 = v_3;                    
                    break;
                case "2":
                    v_1 = v_1 ^ v_2;
                    v_2 = v_1 ^ v_2;
                    v_1 = v_1 ^ v_2;                    
                    break;
                default:
                    return;
            }

            Console.WriteLine("Преобразование: V_1 = {0}; V_2 = {1}", v_1, v_2);
            Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        private static void Chess()
        {
            Console.WriteLine("Одного ли цвета указанные поля шахматной доски.\n");            
            Console.Write("Введите координаты полей шахматной доски, формат ввода x1 y1 x2 y2: ");

            string line = Console.ReadLine();
            string[] values = line.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            int x1 = int.Parse(values[0]);
            int y1 = int.Parse(values[1]);
            int x2 = int.Parse(values[2]);
            int y2 = int.Parse(values[3]);

            bool cell1_IsBlack = CheckBlackCell(x1, y1);
            bool cell2_IsBlack = CheckBlackCell(x2, y2);

            Console.WriteLine("Цвета поля шахматной доски {0}совпадают", cell1_IsBlack & cell2_IsBlack ? "" : "не ");
            Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        private static bool CheckBlackCell(int x, int y)
        {
            if (y % 2 != 0)
            {
                // строка начинается с белой клетки
                if (x % 2 != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // строка начинается с черной клектки
                if (x % 2 != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
