using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// Федоров Игорь

namespace Homework_2
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
                Console.WriteLine("1 - Перевод чисел из десятичной системы в двоичную;");
                Console.WriteLine("2 - Возведение числа \"a\" в степень \"b\";");

                Console.Write("\nВведите номер программы (для выхода - любой другой символ): ");
                #endregion

                string sign = Console.ReadLine();

                Console.Clear();

                switch (sign)
                {
                    case "1":
                        Prev_DecToBin();
                        break;
                    case "2":
                        Prev_Pow();
                        break;
                    
                    default:
                        continued = false;
                        break;
                }

                Console.Clear();
            }
        }

        private static void Prev_DecToBin()
        {
            Console.WriteLine("Функция перевода чисел из десятичной системы в двоичную, используя рекурсию\n");
            Console.Write("Введите целое положительное число в десятчиной системе: ");

            int value = int.Parse(Console.ReadLine());

            Console.WriteLine("\nЧисло в двоичной системе: {0}", DecToBin(value));

            Console.WriteLine("\nДля перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        /// <summary>
        /// Перевод из числа из десятичной системы счисления в двоичную
        /// </summary>
        /// <param name="value">число в десятичной системе считсления</param>
        /// <returns></returns>
        private static string DecToBin(int value)
        {
            if (value == 0)
                return "";

            string sign = (value % 2).ToString();
            return DecToBin(value / 2) + sign;
        }

        private static void Prev_Pow()
        {
            Console.WriteLine("Функция возведения числа \"a\" в степень \"b\"\n");
            Console.Write("Число a: ");

            int value = int.Parse(Console.ReadLine());

            Console.Write("Степень b: ");

            int degree = int.Parse(Console.ReadLine());

            Stopwatch timer = new Stopwatch();

            timer.Reset();
            timer.Start();
            int pow  = Pow(value, degree);
            timer.Stop();

            Console.WriteLine("\nМетод без рекурсии:           a ^ b = {0} ({1} тактов)", pow, timer.ElapsedTicks);

            timer.Reset();
            timer.Start();
            pow = PowRecurse(value, degree);
            timer.Stop();

            Console.WriteLine("Метод с рекурсией:            a ^ b = {0} ({1} тактов)", pow, timer.ElapsedTicks);

            timer.Reset();
            timer.Start();
            pow = PowRecurseQuick(value, degree);
            timer.Stop();

            Console.WriteLine("Ускоренный метод с рекурсией: a ^ b = {0} ({1} тактов)", pow, timer.ElapsedTicks);

            Console.WriteLine("\nДля перехода в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        /// <summary>
        /// Возведение в степень без использования рекурсии
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="degree">степень</param>
        /// <returns></returns>
        private static int Pow(int value, int degree)
        {
            int result = 1;

            while (degree != 0)
            {
                result *= value;
                degree--;
            }

            return result;
        }

        /// <summary>
        /// Возведение в степень с использованием рекурсии
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="degree">степень</param>
        /// <returns></returns>
        private static int PowRecurse(int value, int degree)
        {
            if (degree == 0)
                return 1;

            return value * PowRecurse(value, degree - 1);
        }

        /// <summary>
        /// Ускоренное возведение в степень с использованием рекурсии
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="degree">степень</param>
        /// <returns></returns>
        private static int PowRecurseQuick(int value, int degree)
        {
            if (degree == 0)
                return 1;

            if (degree % 2 != 0)
            {
                return value * PowRecurseQuick(value, degree - 1);
            }
            else
            {   
                return PowRecurseQuick(value * value, degree / 2);
            }
        }

    }
}
