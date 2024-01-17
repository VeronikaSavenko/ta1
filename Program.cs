using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ta1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte choice;
            sbyte choice_1;
            do
            {
                Console.WriteLine("Для виконання 1 завдання введiть 1.\n" +
                    "Для виконання 2 завдання введiть 2.\n" +
                    "Для виходу з програми введiть 0.");
                choice = sbyte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1 завдання:");
                        Queue<int> queue = new Queue<int>();
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Щоб додати елемент до черги введiть 1.\n" +
                            "Щоб видалити елемент з черги введiть 2.\n" +
                            "Щоб дiзнатися розмiр черги введiть 3.\n" +
                            "Для виходу з програми введiть 0.");
                            choice_1 = sbyte.Parse(Console.ReadLine());
                            switch (choice_1)
                            {
                                case 1:
                                    Console.WriteLine("Введiть елемент:");
                                    int el = int.Parse(Console.ReadLine());
                                    queue.Add(el);
                                    break;
                                case 2:
                                    queue.Poll();
                                    Console.WriteLine("Елемент успiшно видалено.");
                                    break;
                                case 3:
                                    Console.WriteLine($"Розмiр черги: {queue.Size()}");
                                    queue.Size();
                                    break;
                                case 0:
                                    Console.WriteLine("Вихiд з програми виконано.");
                                    break;
                                default:
                                    Console.WriteLine($"Команда \"{choice}\" не розпiзнана.");
                                    break;
                            }
                        } while (choice_1 != 0);
                        break;
                    case 2:
                        Console.WriteLine("2 завдання:");
                        BreadthFirstSearch map = new BreadthFirstSearch();
                        break;
                    case 0:
                        Console.WriteLine("Вихiд з програми виконано.");
                        break;
                    default:
                        Console.WriteLine($"Команда \"{choice}\" не розпiзнана.");
                        break;
                }
            } while (choice != 0);

            //Queue<int> queue = new Queue<int>();
            //Console.WriteLine();
            //queue.Add(1);
            //queue.Add(2);
            //queue.Size();
            //queue.Add(3);
            //queue.Poll();
            //BreadthFirstSearch map = new BreadthFirstSearch();
        }
    }
}
