using System;
using System.Collections.Generic;
using System.Text;

namespace Snakee
{
    class FoodGeneration
    {
        int X;
        int Y;
        Random random = new Random();
        public Point food { get; set; }

        public FoodGeneration(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void CreateFood()
        {
            food = new Point(random.Next(2, X - 2), random.Next(2, Y - 2));
            food.PrintSymbol('@');
        }
    }
}
