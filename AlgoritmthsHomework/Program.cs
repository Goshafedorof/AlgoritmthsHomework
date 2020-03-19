using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Федоров Игорь
namespace AlgoritmthsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            // здесь должно быть меню
            ChangeVariable();

        }

        private static void ChangeVariable()
        {
            Console.Write("\nЗначение целочисленной переменной V_1: ");
            string v1_str = Console.ReadLine();
            Console.Write("Значение целочисленной переменной V_2: ");
            string v2_str = Console.ReadLine();

            Console.WriteLine("\nВыберите способ подмена переменной:");
            Console.WriteLine("- введите \"1\", чтобы использовать третью переменную;");
            Console.WriteLine("- введите \"2\", чтобы не использовать третью переменную.");
            Console.Write("Номер вывода информации: ");
            string selectMarker = Console.ReadLine();

            int v1 = int.Parse(v1_str);
            int v2 = int.Parse(v2_str);

            // перестановка переменной
            switch (selectMarker)
            {
                case "1":
                    int v3 = v2;
                    v2 = v1;
                    v1 = v3;
                    break;
                case "2":
                    v2 = v1 ^ v2;
                    v1 = v2 ^ v1 ;
                    v2 = v2 ^ v1;
                    break;
                default:
                    Console.WriteLine("Значение \"{0}\" не является корректным", selectMarker);
                    Console.WriteLine("\nДля выхода из программы нажмите любую клавишу.");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("\nПерестановка: V_1 = {0}; V_2 = {1}", v1, v2);
            Console.ReadKey();
        }
    }
}
