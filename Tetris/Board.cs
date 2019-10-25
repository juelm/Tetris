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
        private ConsoleColor color;
        private Scoreboard score;
        private Scoreboard lines;
        private Scoreboard level;


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

        public Scoreboard getScore()
        {
            return score;
        }

        public Scoreboard getLines()
        {
            return lines;
        }

        public Scoreboard getLevel()
        {
            return level;
        }

        public Board(int x, int y, Point pt, ConsoleColor color)
        {

            width = x;
            height = y;
            start = pt;
            this.color = color;
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
                    else if (j == start.X || j == start.X + width)
                    {
                        borders.Add(new Point(j, i));
                    }
                }
            }

            score = new Scoreboard(7, 14, Start.X + Width + scoreBoardOffsetX, Start.Y, color, ConsoleColor.Magenta, "Score:");
            lines = new Scoreboard(7, 14, Start.X + Width + scoreBoardOffsetX, Start.Y + 10, color, ConsoleColor.Cyan, "Lines:");
            level = new Scoreboard(7, 14, Start.X + Width + scoreBoardOffsetX, Start.Y + 20, color, ConsoleColor.Yellow, "Level:");
        }

        public void drawBoard()
        {
            createBoard();
            ConsoleColor col = ConsoleColor.DarkGray;

            Console.BackgroundColor = color;

            foreach (Point p in borders)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
            Console.ResetColor();

            score.drawScoreboard();
            lines.drawScoreboard();
            level.drawScoreboard();

        }

    }

    public class Scoreboard
    {
        string title;
        int height;
        int width;
        int cursorX;
        int cursorY;
        ConsoleColor borderColor;
        ConsoleColor textColor;
        Point statCursor;

        public Point GetCursorPosition()
        {
            return statCursor;
        }

        public ConsoleColor GetTextColor()
        {
            return textColor;
        }

        public Scoreboard(int height, int width, int cursorX, int cursorY, ConsoleColor borderColor, ConsoleColor textColor, string text)
        {
            this.height = height;
            this.width = width;
            this.cursorX = cursorX;
            this.cursorY = cursorY;
            this.borderColor = borderColor;
            this.textColor = textColor;
            this.title = text;
        }

        public void drawScoreboard()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(cursorX, cursorY + i);

                for (int j = 0; j < width; j++)
                {
                    if (i < 2 || i == height - 1)
                    {
                        Console.BackgroundColor = borderColor;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            Console.BackgroundColor = borderColor;
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

            int centerText = width > title.Length ? (width - title.Length) / 2 : 0;
            Console.SetCursorPosition(cursorX + centerText, cursorY + 1);
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = borderColor;
            Console.Write(title);
            Console.ResetColor();
            statCursor = new Point(cursorX + 3, cursorY + height / 2 + 1);
        }
    }
}
