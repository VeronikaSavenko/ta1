using System;
using System.Collections.Generic;
using System.Text;

namespace ta1
{
    class BreadthFirstSearch
    {
        char[][] map;
        bool[][] bitArr;
        public BreadthFirstSearch()
        {
            map = new char[8][];
            map[0] = new char[] { '#', '.', 'S', '.', '.', '.', '.', '.' };
            map[1] = new char[] { '#', '#', '.', '#', '.', '#', '#', '#' };
            map[2] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.' };
            map[3] = new char[] { '.', '#', '#', '#', '#', '.', '#', '.' };
            map[4] = new char[] { '.', '.', '.', '.', '.', '#', '.', '.' };
            map[5] = new char[] { '.', '.', '#', '.', 'F', '#', '.', '.' };
            map[6] = new char[] { '.', '.', '#', '#', '#', '#', '.', '.' };
            map[7] = new char[] { '#', '.', '.', '.', '.', '.', '.', '.' };

            Console.WriteLine("Вихiдний лабiринт:");
            PrintMap();

            bitArr = new bool[map.Length][];
            for (int i = 0; i < map.Length; i++)
            {
                bitArr[i] = new bool[map[i].Length];
            }
            DrawPath(SearchPath(SearchStart()));

            Console.WriteLine("Пройдений лабiринт:");
            PrintMap();
        }
        private void PrintMap()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
        }
        private Point SearchPath(Point start)
        {
            Queue<Point> queue = new Queue<Point>();

            queue.Add(start);
            if (start == null)
                throw new InvalidOperationException("В лабiринтi немає старту!");
            else
            while (queue.count != 0)
            {
                Point point = queue.Poll();

                if (point.x - 1 >= 0 && map[point.y][point.x - 1] != '#' && bitArr[point.y][point.x - 1] == false)
                {
                    queue.Add(new Point(point.y, point.x - 1, point));
                    bitArr[point.y][point.x - 1] = true;
                    if (map[point.y][point.x - 1] == 'F')
                    {
                        return new Point(point.y, point.x - 1, point);
                    }
                }
                if (point.y + 1 < map.Length && map[point.y + 1][point.x] != '#' && bitArr[point.y + 1][point.x] == false)
                {
                    queue.Add(new Point(point.y + 1, point.x, point));
                    bitArr[point.y + 1][point.x] = true;
                    if (map[point.y + 1][point.x] == 'F')
                    {
                        return new Point(point.y + 1, point.x, point);
                    }
                }
                if (point.x + 1 < map[0].Length && map[point.y][point.x + 1] != '#' && bitArr[point.y][point.x + 1] == false)
                {
                    queue.Add(new Point(point.y, point.x + 1, point));
                    bitArr[point.y][point.x + 1] = true;
                    if (map[point.y][point.x + 1] == 'F')
                    {
                        return new Point(point.y, point.x + 1, point);
                    }
                }
                if (point.y - 1 >= 0 && map[point.y - 1][point.x] != '#' && bitArr[point.y - 1][point.x] == false)
                {
                    queue.Add(new Point(point.y - 1, point.x, point));
                    bitArr[point.y - 1][point.x] = true;
                    if (map[point.y - 1][point.x] == 'F')
                    {
                        return new Point(point.y - 1, point.x, point);
                    }
                }
            }
            return null;
        }
        private void DrawPath(Point point)
        {
            if (point == null)
                throw new InvalidOperationException("В лабiринтi немає фiнiшу!");
            else
            while (point.prev.prev != null)
            {
                point = point.prev;
                map[point.y][point.x] = 'X';
            }
        }
        private Point SearchStart()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'S')
                    {
                        bitArr[i][j] = true;
                        return new Point(i, j, null);
                    }
                }
            }
            return null;
        }
        class Point
        {
            public int x;
            public int y;
            public Point prev;
            public Point(int y, int x, Point prev)
            {
                this.x = x;
                this.y = y;
                this.prev = prev;
            }
        }
    }
}
