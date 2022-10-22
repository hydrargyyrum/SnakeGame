using System;
using System.Collections.Generic;

namespace Snakee
{
    class Field
    {
        private List<Point> wall = new List<Point>();

        public Field(int x, int y)
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.CursorVisible = false;
            PrintHorizontal(x, 0);
            PrintHorizontal(x, y);
            PrintVertical(0, y);
            PrintVertical(x, y);
        }

        private void PrintHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = new Point(i, y);
                p.PrintSymbol('#');
                wall.Add(p);
            }
        }

        private void PrintVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i);
                p.PrintSymbol('#');
                wall.Add(p);
            }
        }

        public bool IsDead(Point p)
        {
            foreach (var w in wall)
            {
                if (Point.AreEqual(p, w))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

