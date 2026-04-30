using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHomeWork
{
    internal class Program
    {
        // Задание 1: работа со списком строк
        private class ListTask
        {
            private readonly List<string> _list = new List<string> { "яблоко", "банан", "вишня" };

            public void TaskLoop()
            {
                Console.WriteLine("--- Задание 1: список строк ---");
                Console.WriteLine("Для выхода в любой момент введите exit\n");

                while (true)
                {
                    Console.WriteLine($"Текущий список: {string.Join(", ", _list)}");
                    Console.Write("Введите строку для добавления в конец (или exit): ");
                    string input = Console.ReadLine();
                    if (input == "exit") break;
                    _list.Add(input);
                    Console.WriteLine($"Список после добавления: {string.Join(", ", _list)}");

                    Console.Write("Введите строку для вставки в середину (или exit): ");
                    input = Console.ReadLine();
                    if (input == "exit") break;
                    int mid = _list.Count / 2;
                    _list.Insert(mid, input);
                    Console.WriteLine($"Список после вставки в середину: {string.Join(", ", _list)}");

                    Console.WriteLine("\nНажмите Enter, чтобы повторить, или введите exit для выхода.");
                    if (Console.ReadLine() == "exit") break;
                }
                Console.WriteLine("Выход из задания 1.\n");
            }
        }

        // Задание 2: словарь (имя -> средняя оценка)
        private class DictionaryTask
        {
            private readonly Dictionary<string, double> _students = new Dictionary<string, double>();

            public void TaskLoop()
            {
                Console.WriteLine("--- Задание 2: словарь студентов ---");
                Console.WriteLine("Для выхода в любой момент введите exit\n");

                while (true)
                {
                    Console.WriteLine("\nДоступные команды: add - добавить студента, find - найти оценку, exit - выход");
                    Console.Write("Введите команду: ");
                    string cmd = Console.ReadLine()?.ToLower();
                    if (cmd == "exit" || cmd == "exit") break;

                    switch (cmd)
                    {
                        case "add":
                            AddStudent();
                            break;
                        case "find":
                            FindStudent();
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда. Попробуйте add, find или exit.");
                            break;
                    }
                }
                Console.WriteLine("Выход из задания 2.\n");
            }

            private void AddStudent()
            {
                Console.Write("Введите имя студента: ");
                string name = Console.ReadLine();
                if (name == "exit") return;

                Console.Write("Введите среднюю оценку (от 2 до 5): ");
                string gradeInput = Console.ReadLine();
                if (gradeInput == "exit") return;

                if (double.TryParse(gradeInput, out double grade) && grade >= 2 && grade <= 5)
                {
                    _students[name] = grade;
                    Console.WriteLine($"Студент {name} добавлен с оценкой {grade}.");
                }
                else
                {
                    Console.WriteLine("Ошибка: оценка должна быть числом от 2 до 5.");
                }
            }

            private void FindStudent()
            {
                Console.Write("Введите имя студента для поиска: ");
                string name = Console.ReadLine();
                if (name == "exit") return;

                if (_students.TryGetValue(name, out double grade))
                    Console.WriteLine($"Студент {name} имеет среднюю оценку {grade}.");
                else
                    Console.WriteLine($"Студент с именем '{name}' не найден.");
            }
        }

        // Задание 3: двусвязный список
        private class LinkedListTask
        {
            private class Node
            {
                public int Data { get; set; }
                public Node Prev { get; set; }
                public Node Next { get; set; }

                public Node(int data)
                {
                    Data = data;
                    Prev = null;
                    Next = null;
                }
            }

            private Node _head;
            private Node _tail;

            public void TaskLoop()
            {
                Console.WriteLine("--- Задание 3: двусвязный список ---");
                Console.WriteLine("Для выхода в любой момент введите exit\n");

                while (true)
                {
                    Console.Write("Введите от 3 до 6 целых чисел через пробел (или exit): ");
                    string input = Console.ReadLine();
                    if (input == "exit") break;

                    string[] parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 3 || parts.Length > 6)
                    {
                        Console.WriteLine("Ошибка: нужно ввести от 3 до 6 чисел. Попробуйте снова.");
                        continue;
                    }

                    List<int> numbers = new List<int>();
                    bool valid = true;
                    foreach (var p in parts)
                    {
                        if (!int.TryParse(p, out int num))
                        {
                            valid = false;
                            break;
                        }
                        numbers.Add(num);
                    }

                    if (!valid)
                    {
                        Console.WriteLine("Ошибка: все значения должны быть целыми числами.");
                        continue;
                    }

                    // Построение двусвязного списка
                    BuildList(numbers);
                    Console.WriteLine("Список в прямом порядке: " + GetForwardString());
                    Console.WriteLine("Список в обратном порядке: " + GetBackwardString());

                    Console.WriteLine("\nНажмите Enter, чтобы создать новый список, или введите exit для выхода.");
                    if (Console.ReadLine() == "exit") break;
                }
                Console.WriteLine("Выход из задания 3.\n");
            }

            private void BuildList(List<int> numbers)
            {
                _head = null;
                _tail = null;
                foreach (int num in numbers)
                {
                    Node newNode = new Node(num);
                    if (_head == null)
                    {
                        _head = newNode;
                        _tail = newNode;
                    }
                    else
                    {
                        _tail.Next = newNode;
                        newNode.Prev = _tail;
                        _tail = newNode;
                    }
                }
            }

            private string GetForwardString()
            {
                if (_head == null) return "пусто";
                List<string> values = new List<string>();
                Node current = _head;
                while (current != null)
                {
                    values.Add(current.Data.ToString());
                    current = current.Next;
                }
                return string.Join(", ", values);
            }

            private string GetBackwardString()
            {
                if (_tail == null) return "пусто";
                List<string> values = new List<string>();
                Node current = _tail;
                while (current != null)
                {
                    values.Add(current.Data.ToString());
                    current = current.Prev;
                }
                return string.Join(", ", values);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите задание (1, 2, 3) или 0 для выхода:");
                string choice = Console.ReadLine();
                if (choice == "0") break;

                if (int.TryParse(choice, out int task))
                {
                    switch (task)
                    {
                        case 1:
                            CheckTaskFirst();
                            break;
                        case 2:
                            CheckTaskSecond();
                            break;
                        case 3:
                            CheckTaskThird();
                            break;
                        default:
                            Console.WriteLine("Некорректный номер. Введите 1, 2 или 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите число.");
                }
                Console.WriteLine();
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictTask = new DictionaryTask();
            dictTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedTask = new LinkedListTask();
            linkedTask.TaskLoop();
        }
    }
}

