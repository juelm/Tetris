using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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
        private HighScoreBoard highScoreBoard;



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

        public HighScoreBoard getHighScoreBoard()
        {
            return highScoreBoard;
        }

        public Board(int x, int y, Point pt, ConsoleColor color)
        {

            width = x;
            height = y;
            start = pt;
            this.color = color;
            spawnPoint = new Point(pt.X + width / 2, pt.Y);

        }


        public void createBoard()
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
            highScoreBoard = new HighScoreBoard(height + 1, width - 10, Start.X + Width + scoreBoardOffsetX + 17, Start.Y, color, ConsoleColor.Green, "HighScores:");

        }

        public void drawBoard(ConsoleColor col = ConsoleColor.DarkGray)
        {
            //createBoard();

            Console.BackgroundColor = col;

            foreach (Point p in borders)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
            Console.ResetColor();

            score.drawScoreboard();
            lines.drawScoreboard();
            level.drawScoreboard();
            highScoreBoard.drawScoreboard();
            //highScoreBoard.displayScores();


        }

    }

    public class Scoreboard
    {
        protected string title;
        protected int height;
        protected int width;
        protected int cursorX;
        protected int cursorY;
        protected ConsoleColor borderColor;
        protected ConsoleColor textColor;
        protected Point statCursor;

        public virtual Point GetCursorPosition()
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

    public class HighScoreBoard : Scoreboard
    {
        private int[] highScores;
        private string[] highScorers;

        public override Point GetCursorPosition()
        {
            return new Point(cursorX + 3, cursorY + 3);
        }
        public int[] getHighScores() { return highScores; }
        public int[] getHighScorers() { return highScores; }


        public HighScoreBoard(int height, int width, int cursorX, int cursorY, ConsoleColor borderColor, ConsoleColor textColor, string text) : base(height, width, cursorX, cursorY, borderColor, textColor, text)
        {
            highScores = new int[10] { 100, 82, 60, 44, 30, 12, 8, 6, 2, 1 };
            highScorers = new string[10] { "Matt", "Eddy", "Linus", "Anders", "Matt", "Eddy", "Linus", "Anders", "Matt", "Eddy" };
        }

        //public async void eventuallyDisplayScores()
        //{
        //    await Task.Run(displayScores);
        //}

        public void displayScores()
        {
            Console.SetCursorPosition(cursorX + 3, cursorY + 3);
            for (int i = 0; i < highScorers.Length; i++)
            {
                Console.SetCursorPosition(cursorX + 3, Console.CursorTop);
                Console.WriteLine($"{i + 1}. {highScorers[i]}: \t{highScores[i]}");
            }
        }

        public void updateScores(int currentScore)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            bool isAWinner = false;
            int priorScore = 0;
            string priorName = " ";

            for(int i = 0; i < highScores.Length; i++)
            {
                if (!isAWinner)
                {
                    if (currentScore >= highScores[i])
                    {
                        isAWinner = true;
                        priorName = highScorers[i];
                        priorScore = highScores[i];
                        Console.WriteLine("Congratulations! You cracked the leaderboard.");
                        Console.SetCursorPosition(x, Console.CursorTop);
                        Console.Write("\nEnter your Name: ");
                        string playerName = Console.ReadLine();
                        highScores[i] = currentScore;
                        highScorers[i] = playerName;
                    }
                }
                else
                {
                    int tempScore = highScores[i];
                    string tempName = highScorers[i];
                    highScores[i] = priorScore;
                    highScorers[i] = priorName;
                    priorScore = tempScore;
                    priorName = tempName;
                }
            }
        }
    }
}
