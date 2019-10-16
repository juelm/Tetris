using System;
using System.Drawing;
namespace Tetris
{
    public class Block
    {

        //private Point position;
        private int x;
        private int y;
        private ConsoleColor color;
        private static int height = 1;
        private int width = height * 2;
        private Point[] area;

        public Point Position { set; get; }

        public Point[] getArea()
        {
            return area;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }


        public Block(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            area = new Point[height * 3];

        }

        public void draw()
        {
            Console.SetCursorPosition(x, y);
            //Console.ForegroundColor = color;
            int index = 0;
            

            for(int i = 0; i < height; i++)
            {

                for (int j = 0; j < height * 2; j++)
                {
                    Point current = new Point(Console.CursorLeft, Console.CursorTop);
                    area[index] = current;
                    Console.BackgroundColor = color;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


            Console.ResetColor();
        }

        //public void erase()
        //{
        //    Console.SetCursorPosition(x, y);
        //    //Console.ForegroundColor = color;
        //    int index = 0;


        //    for (int i = 0; i < height; i++)
        //    {

        //        for (int j = 0; j < height * 2; j++)
        //        {
        //            Console.Write(" ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public void erase()
        {
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                Console.Write(" ");
                //Console.Write($"X: {pt.X}, Y: {pt.Y} ");

            }
        }
    }
}
