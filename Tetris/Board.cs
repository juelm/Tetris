using System;
using System.Drawing;
namespace Tetris
{
    public class Board
    {
        private int height;
        private int width;
        private Point start;

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

        public Board(int x, int y, Point pt)
        {

            width = x;
            height = y;
            start = pt;

        }

        public void drawBoard()
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write('+');

                for (int j = 1; j < width - 1; j++)
                {
                    if(i == 0 || i == height - 1)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write('+');
                Console.WriteLine();
            }
        }
    }
}
