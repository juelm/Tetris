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
        private static int width = height * 2;
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

        public void inflate()
        {

            int index = 0;
            int posX = x;
            int posY = y;

            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < height * 2; j++)
                {
                    Point current = new Point(posX, posY);
                    area[index] = current;
                    index++;
                    posX++;
                }
                posY++;
            }
        }

        public void draw()
        {

            //int index = 0;
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                Console.BackgroundColor = color;
                Console.Write(" ");
                //Console.SetCursorPosition(20, index + 25);
                //Console.Write($"X: {pt.X}, Y: {pt.Y} ");
                //index++;
            }
            Console.ResetColor();
        }

        public void Shift(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.LeftArrow:
                    x -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    x += 1;
                    break;
                case ConsoleKey.DownArrow:
                    y += 1;
                    break;
            }

            inflate();

        }

        public void erase()
        {
            //int index = 0;
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                //Console.SetCursorPosition(0, index + 10);
                //Console.Write($"X: {pt.X}, Y: {pt.Y} ");
                //index++;
            }

            Console.ResetColor();
        }
    }
}
