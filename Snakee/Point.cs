using System;


namespace Snakee
{
    struct Point
    {
        public int X;
        public int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static bool AreEqual(Point a, Point b)
        {
            if (a.X == b.X && a.Y == b.Y) return true;
            else return false;
        }

        public void DeleteSymbol()
        {
            PrintSymbol(' ');
        }

        // todo point in common way is not about console. It's about position in dekart coordinate system. So, it's better to extract this method to another place.
        public void PrintSymbol(char sym)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(sym);
        }
    }
}
