using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
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
                Console.WriteLine("1 - Перевод из десятичной в двоичную систему счисления;");
                Console.WriteLine("2 - Определение правильности ввода скобочной последоваетльности;");

                Console.Write("\nВведите номер программы (для выхода - любой другой символ): ");
                #endregion

                string sign = Console.ReadLine();

                Console.Clear();

                switch (sign)
                {
                    case "1":
                        DecToBin();
                        break;
                    case "2":
                        BracketSequence();
                        break;
                    default:
                        return;
                }

                Console.WriteLine("Для перехода в меню нажмите любую клавишу.");
                Console.ReadKey();

                Console.Clear();
            }
        }

        public class Node<T>
        {
            /// <summary>
            /// Данные
            /// </summary>
            public T Value { get; set; }
            /// <summary>
            /// следующий элемент
            /// </summary>
            public Node<T> NodeNext { get; set; }
        }


        public class Stack<T>
        {
            /// <summary>
            /// Начальный элемент стека
            /// </summary>
            public Node<T> Head { get; set; }
            /// <summary>
            /// Текущий размер стека
            /// </summary>
            public int Size { get; set; }
            /// <summary>
            /// Максимальный размер стека
            /// </summary>
            public int MaxSize { get; set; }
            /// <summary>
            /// Флаг "Стек пустой"
            /// </summary>
            public bool IsEmpty
            {
                get { return Size == 0; }
            }

            public void Push(T value)
            {
                if (Size >= MaxSize)
                    throw new Exception("Stack overflow");

                Node<T> node = new Node<T>() { Value = value, NodeNext = Head };

                Head = node;

                Size++;
            }

            public T Pop()
            {
                if (Size == 0)
                    throw new Exception("Stack is empty");

                T value = Head.Value;

                Head = Head.NodeNext;

                Size--;

                return value;
            }

            public bool ExistValue(T value)
            {
                if (Size == 0)
                    throw new Exception("Stack is empty");

                bool existed = false;

                Node<T> currentNode = Head;

                while (!IsEmpty)
                {
                    
                }

                return existed;
            }
        }

        private static void DecToBin()
        {
            Console.WriteLine("Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.\n");

            Console.Write("Введите число в десятчиной системе счисления: ");
            int valuePrev = int.Parse(Console.ReadLine());

            int value = valuePrev;

            // Инициалиазция стека
            Stack<int> stack = new Stack<int>() { MaxSize = 100 };

            // заполнение стека
            while (value != 0)
            {
                stack.Push(value % 2);

                value = value / 2;
            }

            string line = string.Empty;

            // выгрузка стека
            while (!stack.IsEmpty)
            {
                line += stack.Pop().ToString();
            }

            Console.WriteLine();
            Console.WriteLine("Перевод: {0}(10) = {1}(2)", valuePrev, line);
            Console.WriteLine();
        }

        private static readonly char[] VALITED_CHARS = { '(', ')', '[', ']', '{', '}' };

        private static void BracketSequence()
        {
            Console.WriteLine("Программа, которая определяет, является ли введенная скобочная последовательность правильной.\n");

            Console.Write("Введите скобочную последовательность (без пробелов): ");

            string chars = "";

            Stack<char> stack = new Stack<char>() { MaxSize = 100 };

            for (int indexChar = 0; indexChar < chars.Length; indexChar++)
            {
                if (!CharValited(chars[indexChar]))
                {
                    Console.WriteLine("Введен неверный символ \'{0}\'", chars[indexChar]);
                    return;
                }
            }
        }

        private static bool CharValited(char symbol)
        {
            for (int i = 0; i < VALITED_CHARS.Length; i++)
            {
                if (VALITED_CHARS[i] == symbol)                
                    return true;
            }

            return false;
        }
    }
}
