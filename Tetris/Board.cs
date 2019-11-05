using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace Tetris
{

    /// <summary>
    /// Creates and renders all components of board including borders and scoreboards.
    /// </summary>
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
        private Nextboard next;
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

        public Scoreboard getNext()
        {
            return next;
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





        //Instantiates each point in game board border and all scoreboards

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
            next = new Nextboard(12, width - 8, Start.X + Width + scoreBoardOffsetX + 18, Start.Y, color, ConsoleColor.Blue, "Next:");
            highScoreBoard = new HighScoreBoard(14, width - 8, Start.X + Width + scoreBoardOffsetX + 18, Start.Y + Height - 13, color, ConsoleColor.Green, "HighScores:");

        }





        //Renders each point in game board border and all scoreboards

        public void drawBoard(ConsoleColor col = ConsoleColor.DarkGray)
        {

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
            next.drawScoreboard();
            highScoreBoard.drawScoreboard();
            highScoreBoard.displayScores();


        }

    }





    /// <summary>
    /// Creates and renders a scoreboard object to track game statistics. 
    /// </summary>
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





    /// <summary>
    /// Creates and renders a HighScoreBoard object.
    /// Upon initialization, reads in highscores.txt and highscorers.txt to populate high score board. Tracks any changes and writes them to the same files.
    /// </summary>

    public class HighScoreBoard : Scoreboard
    {
        private int[] highScores = new int[10];
        private string[] highScorers;

        public override Point GetCursorPosition()
        {
            return new Point(cursorX + 3, cursorY + 3);
        }
        public int[] getHighScores() { return highScores; }
        public string[] getHighScorers() { return highScorers; }


        public HighScoreBoard(int height, int width, int cursorX, int cursorY, ConsoleColor borderColor, ConsoleColor textColor, string text) : base(height, width, cursorX, cursorY, borderColor, textColor, text)
        {
            highScorers = File.ReadAllLines("/Users/matthewjuel/Projects/Tetris/Tetris/highScorers.txt");
            string[] highScoresText = File.ReadAllLines("/Users/matthewjuel/Projects/Tetris/Tetris/highScores.txt");

            for (int i = 0; i < highScoresText.Length; i++)
            {
                try
                {
                    highScores[i] = Convert.ToInt32(highScoresText[i]);
                }
                catch
                {
                    highScores[i] = 0;
                }
            }
        }

        public void displayScores()
        {
            Console.SetCursorPosition(cursorX + 3, cursorY + 3);
            for (int i = 0; i < highScorers.Length; i++)
            {
                Console.SetCursorPosition(cursorX + 3, Console.CursorTop);
                Console.Write($"{i + 1}. {highScorers[i]}:");
                Console.SetCursorPosition(cursorX + width - 6, Console.CursorTop);
                Console.WriteLine(highScores[i]);

            }
        }

        public void updateScores(int currentScore, int x, int y)
        {
            //int x = Console.CursorLeft;
            //int y = Console.CursorTop;
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
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("Congratulations!");
                        
                        Console.SetCursorPosition(x, y + 1);
                        Console.WriteLine("You cracked the leaderboard.");
                        Console.SetCursorPosition(x, y + 3);
                        Console.CursorVisible = true;
                        Console.Write("Enter your Name: ");
                        string playerName = Console.ReadLine();
                        Console.CursorVisible = false;
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
            if (isAWinner)
            {
                File.WriteAllLines("/Users/matthewjuel/Projects/Tetris/Tetris/highScorers.txt", highScorers);
                string[] textScores = new string[10];
                for(int i = 0; i < highScores.Length; i++)
                {
                    textScores[i] = Convert.ToString(highScores[i]);
                }
                File.WriteAllLines("/Users/matthewjuel/Projects/Tetris/Tetris/highScores.txt", textScores);
            }
        }
    }





    /// <summary>
    /// Creates and renders a Nextboard object to display the next shape. 
    /// </summary>

    public class Nextboard : Scoreboard
    {
        public Nextboard(int height, int width, int cursorX, int cursorY, ConsoleColor borderColor, ConsoleColor textColor, string text) : base(height, width, cursorX, cursorY, borderColor, textColor, text)
        {
            
        }

        public override Point GetCursorPosition()
        {
      
            return new Point(cursorX + (this.width - Block.Width * 5) / 2, cursorY + (this.height - Block.Height * 5) / 2);
        }
    }
}
