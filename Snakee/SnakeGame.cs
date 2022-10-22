using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Snakee
{
    class Snake
    {
        private Field Field;
        private List<Point> snake;
        private Direction Direction;
        private Point Tail;
        private Point Head;

        public Snake(int x, int y, int fX, int fY)
        {
            Field = new Field(fX, fY);
            snake = new List<Point>();
            Direction = Direction.RIGHT;
            Point p = new Point(x, y);
            snake.Add(p);
            p.PrintSymbol('*');
        }

        public Point Head_() => snake.Last();

        public void Move()
        {
            Head = NextPoint();
            Head.PrintSymbol('*');
            snake.Add(Head);
            Tail = snake.First();
            snake.Remove(snake.First());
            Tail.DeleteSymbol();
        }

        public bool Eaten(Point p)
        {
            Head = NextPoint();
            if (Point.AreEqual(Head, p))
            {
                snake.Add(Head);
                Head.PrintSymbol('*');
                return true;
            }
            return false;
        }

        public Point NextPoint()
        {
            Point p = Head_();
            switch (Direction)
            {
                case Direction.UP:
                    p.Y -= 1;
                    break;
                case Direction.DOWN:
                    p.Y += 1;
                    break;
                case Direction.LEFT:
                    p.X -= 1;
                    break;
                case Direction.RIGHT:
                    p.X += 1;
                    break;
            }
            return p;
        }

        public void Turning(ConsoleKey key)
        {
            switch (Direction)
            {
                case Direction.LEFT:
                case Direction.RIGHT:
                    if (key == ConsoleKey.DownArrow)
                        Direction = Direction.DOWN;
                    else if (key == ConsoleKey.UpArrow)
                        Direction = Direction.UP;
                    break;
                case Direction.UP:
                case Direction.DOWN:
                    if (key == ConsoleKey.LeftArrow)
                        Direction = Direction.LEFT;
                    else if (key == ConsoleKey.RightArrow)
                        Direction = Direction.RIGHT;
                    break;
            }
        }

        public bool IsSuicide(Point p)
        {
            for (int i = snake.Count - 2; i > 0; i--)
            {
                if (Point.AreEqual(snake[i], p))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Game
    {
        Field field;
        Snake snake;
        FoodGeneration foodGeneration;

        public Game(Field field, Snake snake, FoodGeneration foodGeneration)
        {
            this.field = field;
            this.snake = snake;
            this.foodGeneration = foodGeneration;
            foodGeneration.CreateFood();
        }

        public void Play()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Turning(key.Key);
                }
                else if (field.IsDead(snake.Head_()) || snake.IsSuicide(snake.Head_()))
                {
                    Console.SetCursorPosition(35, 14);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER");
                    Thread.Sleep(100000);
                }
                else if (snake.Eaten(foodGeneration.food))
                {
                    foodGeneration.CreateFood();
                }
                else
                {
                    snake.Move();
                    Thread.Sleep(250);
                }
            }
        }
    }

    class SnakeGame
    {
        static void Main()
        {
            Game Game = new Game(new Field(80, 30), new Snake(40, 15, 80, 30), new FoodGeneration(80, 30));
            Game.Play();
        }
    }
}
