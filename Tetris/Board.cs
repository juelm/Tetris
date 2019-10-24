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
        private Point spawnPoint;
        private int scoreBoardOffsetX = 6;

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

        public Point SpawnPoint
        {
            get
            {
                return spawnPoint;
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
            spawnPoint = new Point(pt.X + width / 2, pt.Y);

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
            ConsoleColor col = ConsoleColor.DarkGray;

            Console.BackgroundColor = col;

            foreach (Point p in borders)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
            Console.ResetColor();

            drawScoreBoard(Start.Y, col, ConsoleColor.Magenta, "Lines:");
            drawScoreBoard(Start.Y + 10, col, ConsoleColor.Cyan, "Score:");

        }
     
        public void drawScoreBoard(int yOffset, ConsoleColor color, ConsoleColor textColor, string title)
        {
            int height = 7;
            int width = 14;
            int centerText = width > title.Length ? (width - title.Length) / 2 : 0;
            int cursorX = Start.X + Width + scoreBoardOffsetX;
            int cursorY = yOffset;


            for(int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(cursorX, cursorY + i);

                for(int j = 0; j < width; j++)
                {
                    if(i < 2 || i == height - 1)
                    {
                        Console.BackgroundColor = color;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        if(j == 0 || j == width - 1)
                        {
                            Console.BackgroundColor = color;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(cursorX + centerText, cursorY + 1);
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = color;
            Console.Write(title);
            Console.ResetColor();
        }
    }
}
