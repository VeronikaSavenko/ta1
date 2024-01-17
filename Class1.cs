using System;
using System.Collections.Generic;

public class ShortestPathBFS
{
    static char[,] matrix =
    {
        { '#', '.', 'S', '.', '.', '.', '.', '.' },
        { '#', '#', '.', '#', '.', '#', '#', '#' },
        { '.', '.', '.', '.', '.', '.', '.', '.' },
        { '.', '#', '#', '#', '#', '.', '#', '.' },
        { '.', '.', '.', '.', '.', '#', '.', '.' },
        { '.', '.', '#', '.', 'F', '#', '.', '.' },
        { '.', '.', '#', '#', '#', '#', '.', '.' },
        { '#', '.', '.', '.', '.', '.', '.', '.' }
    };


    //public static void FindShortestPath()
    //{
    //    Queue<(int, int)> queue = new Queue<(int, int)>();

    //    // Знаходимо початкову точку (S)
    //    int startX = -1, startY = -1;
    //    for (int i = 0; i < matrix.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < matrix.GetLength(1); j++)
    //        {
    //            if (matrix[i, j] == 'S')
    //            {
    //                startX = i;
    //                startY = j;
    //                break;
    //            }
    //        }
    //    }

    //    // Додаємо початкову точку до черги
    //    queue.Enqueue((startX, startY));

    //    while (queue.Count > 0)
    //    {
    //        var current = queue.Dequeue();
    //        int x = current.Item1;
    //        int y = current.Item2;

    //        // Перевіряємо сусідні клітинки
    //        CheckCell(queue, x - 1, y); // Вгору
    //        CheckCell(queue, x + 1, y); // Вниз
    //        CheckCell(queue, x, y - 1); // Вліво
    //        CheckCell(queue, x, y + 1); // Вправо
    //    }
    //}

    //static void CheckCell(Queue<(int, int)> queue, int x, int y)
    //{
    //    if (x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1) && matrix[x, y] == '.')
    //    {
    //        matrix[x, y] = 'x'; // Позначаємо найкоротший шлях
    //        queue.Enqueue((x, y));
    //    }
    //}

    //public static void PrintMatrix()
    //{
    //    for (int i = 0; i < matrix.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < matrix.GetLength(1); j++)
    //        {
    //            Console.Write(matrix[i, j] + " ");
    //        }
    //        Console.WriteLine();
    //    }
    //}

    public static void FindShortestPath()
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Знаходимо початкову точку (S)
        int startX = -1, startY = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'S')
                {
                    startX = i;
                    startY = j;
                    break;
                }
            }
        }

        // Додаємо початкову точку до черги
        queue.Enqueue((startX, startY));

        // Структура даних для відстеження попередніх кроків
        Dictionary<(int, int), (int, int)> previousSteps = new Dictionary<(int, int), (int, int)>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;

            // Перевіряємо сусідні клітинки
            ExploreCell(queue, previousSteps, x - 1, y); // Вгору
            ExploreCell(queue, previousSteps, x + 1, y); // Вниз
            ExploreCell(queue, previousSteps, x, y - 1); // Вліво
            ExploreCell(queue, previousSteps, x, y + 1); // Вправо
        }

        // Відновлення шляху з кінцевої точки до початкової
        ReconstructPath(previousSteps, startX, startY);
    }

    static void ExploreCell(Queue<(int, int)> queue, Dictionary<(int, int), (int, int)> previousSteps, int x, int y)
    {
        if (x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1) && (matrix[x, y] == '.' || matrix[x, y] == 'F'))
        {
            if (matrix[x, y] == 'F')
            {
                // Знайдено кінцеву точку, завершуємо алгоритм
                queue.Clear();
            }
            else
            {
                matrix[x, y] = 'x'; // Позначаємо шлях
                queue.Enqueue((x, y));
                // Запам'ятовуємо попередній крок
                var current = queue.Dequeue();
                previousSteps[(x, y)] = (current.Item1, current.Item2);
            }
        }
    }

    static void ReconstructPath(Dictionary<(int, int), (int, int)> previousSteps, int startX, int startY)
    {
        int x = startX, y = startY;
        while (previousSteps.ContainsKey((x, y)))
        {
            var previousStep = previousSteps[(x, y)];
            x = previousStep.Item1;
            y = previousStep.Item2;
            matrix[x, y] = '*'; // Позначаємо найкоротший шлях '*'
        }
    }

    public static void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}