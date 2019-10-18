using System;
using System.Collections.Generic;
using System.Drawing;
namespace Tetris
{
    public class Board
    {
        private int height;
        private int width;
        private Point start;
        private List<Point> borders = new List<Point>();

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
        public Point Start
        {
            get
            {
                return start;
            }
        }

        public List<Point> getBorders()
        {
            return borders;
        }

        public Board(int x, int y, Point pt)
        {

            width = x;
            height = y;
            start = pt;

        }


        private void createBoard()
        {
            for (int i = start.Y; i <= start.Y + height; i++)
            {
                for (int j = start.X; j <= start.X + width; j++)
                {
                    if (i == start.Y || i == start.Y + height)
                    {
                        borders.Add(new Point(j, i));

                    }
                    else if(j == start.X || j == start.X + width)
                    {
                        borders.Add(new Point(j, i));
                    }
                }
            }
        }

        public void drawBoard()
        {
            createBoard();

            foreach(Point p in borders)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("#");
            }
        }

        //public void drawBoard()
        //{
        //    for (int i = 0; i <= height + 1; i++)
        //    {
        //        Console.Write('+');

        //        for (int j = 1; j <= width + 1; j++)
        //        {
        //            if(i == 0 || i == height + 1)
        //            {
        //                Console.Write("-");
        //            }
        //            else
        //            {
        //                Console.Write(" ");
        //            }
        //        }
        //        Console.Write('+');
        //        Console.WriteLine();
        //    }
        //}
    }
}
