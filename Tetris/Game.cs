using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace Tetris
{
    public class Game
    {

        private Timer timer;
        private Timer lineTimer;
        private int timerCounter;
        private int x;
        private int y;
        private Board board;
        private Shape current;
        private List<Block> state;
        private Random rando = new Random();
        private int delay = 0;
        private int score = 0;
        private int lines = 0;
        private int level = 1;
        private int ms;
        //List<Block> fallingDebris = new List<Block>();
        // private List<Block> lines;



        public Game(int x, int y, int height, int width, int ms)
        {
            this.x = x;
            this.y = y;
            this.ms = ms;
            Point p = new Point(x, y);
            board = new Board(width, height, p, ConsoleColor.DarkGray);
            timer = new Timer(ms);
            lineTimer = new Timer(ms / 4);
            state = new List<Block>();
        }

        public bool playGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            board.drawBoard();
            current = new Shape(board.SpawnPoint.X - Block.Width, board.SpawnPoint.Y, rando.Next(7));

            current.Arrange();

            current.render();

            setStats();

            current.Move(ConsoleKey.DownArrow);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            ConsoleKey userInput = ConsoleKey.UpArrow;
            bool notDead = true;

            while (notDead && (userInput == ConsoleKey.UpArrow || userInput == ConsoleKey.DownArrow || userInput == ConsoleKey.LeftArrow || userInput == ConsoleKey.RightArrow))
            {
                userInput = Console.ReadKey().Key;

                notDead = processInput(userInput);

            }

            ConsoleKey playAgain = gameOver();

            if (playAgain == ConsoleKey.Q)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            processInput(ConsoleKey.DownArrow);

        }

        public void UponMyDeath(Object source, ElapsedEventArgs e)
        {
            timerCounter++;
        }

        public bool processInput(ConsoleKey action)
        {
            bool alive = true;
            List<Point> edges = board.getBorders();

            if (action == ConsoleKey.UpArrow)
            {
                current.Mutate(edges, state);
            }
            else
            {

                bool hitEdge = false;
                bool hitBlock = false;


                if (action == ConsoleKey.LeftArrow)
                {

                    hitEdge = current.checkCollision(edges, 1, 0);
                    hitBlock = current.checkCollision(state, 1, 0);

                    if (!hitEdge && !hitBlock) current.Move(action);
                }

                if (action == ConsoleKey.RightArrow)
                {

                    hitEdge = current.checkCollision(edges, -1, 0);
                    hitBlock = current.checkCollision(state, -1, 0);

                    if (!hitEdge && !hitBlock) current.Move(action);
                }

                if (action == ConsoleKey.DownArrow)
                {

                    hitEdge = current.checkCollision(edges, 0, -1);
                    hitBlock = current.checkCollision(state, 0, -1);

                    if (!hitEdge && !hitBlock) current.Move(action);

                    else
                    {
                        if(delay == 1)
                        {
                            foreach (Block blk in current.getBlocks())
                            {
                                state.Add(blk);
                            }

                            Lines();

                            Console.Clear();

                            foreach (Block b in state)
                            {
                                //b.erase();
                                b.inflate();
                                b.draw();

                            }

                            board.drawBoard();

                            setStats();

                            current = new Shape(board.SpawnPoint.X - Block.Width, board.SpawnPoint.Y, rando.Next(7));
                            current.Arrange();
                            current.render();

                            alive = !current.checkCollision(state, 0, -1);

                            delay = 0;
                        }

                        else
                        {
                            delay++;
                        }

                    }
                }
            }

            return alive;
        }

        public void Lines()
        {

            int[] YLines = new int[1000];
            List<Block> toDelete = new List<Block>();
            List<int> Yindexes= new List<int>();
            List<Block> fallingBlocks = new List<Block>();
            int maxY = 0;
            int minY = int.MaxValue;
            int lines = 0;
            bool lineCompleted = false;


            foreach(Block blk in state)
            {
                foreach(Point pt in blk.getArea())
                {
                    
                    int temp = YLines[pt.Y];
                    temp++;
                    YLines[pt.Y] = temp;
                    if(temp >= board.Width - Program.margin + 1)
                    {
                        Yindexes.Add(pt.Y);
                        if (pt.Y > maxY) maxY = pt.Y;
                        if (pt.Y < minY) minY = pt.Y;
                        lineCompleted = true;
                    }
                }
            }

            if (!lineCompleted) return;

            for(int i = 0; i < YLines.Length; i++)
            {
                if(YLines[i] >= board.Width - Program.margin + 1)
                {
                    lines++;
                }
            }

            foreach(Block bk in state)
            {
                //bool wasFound = false;
                foreach(Point p in bk.getArea())
                {
                    bool wasFound = false;
                    foreach (int lin in Yindexes)
                    {
                        if(lin == p.Y)
                        {
                            toDelete.Add(bk);
                            wasFound = true;
                            break;
                        }

                        if (p.Y < minY)
                        {
                            fallingBlocks.Add(bk);
                            wasFound = true;
                            break;
                        }
                            
                    }
                    if (wasFound) break;
                }
            }

            this.lines += lines;
            this.score += (int)Math.Pow(2,lines);


            foreach (Block b in toDelete)
            {
                state.Remove(b);

                b.erase();
            }


            debrisFall(fallingBlocks, lines);

        }


        public void debrisFall(List<Block> fallingDebris, int lines)
        {

            for(int i = 0; i < lines; i++)
            {
                foreach(Block bk in fallingDebris)
                {
                    bk.Y += Block.Height;
                    bk.inflate();
                }
            }

        }

        public void setStats()
        {
            Console.SetCursorPosition(board.getScore().GetCursorPosition().X, board.getScore().GetCursorPosition().Y);
            Console.ForegroundColor = board.getScore().GetTextColor();
            Console.Write(this.score);
            Console.SetCursorPosition(board.getLines().GetCursorPosition().X, board.getLines().GetCursorPosition().Y);
            Console.ForegroundColor = board.getLines().GetTextColor();
            Console.Write(this.lines);
            Console.SetCursorPosition(board.getLevel().GetCursorPosition().X, board.getLevel().GetCursorPosition().Y);
            Console.ForegroundColor = board.getLevel().GetTextColor();
            Console.Write(this.level);
            Console.ResetColor();
        }

        public ConsoleKey gameOver()
        {
            int length = 40;
            int height = 10;
            int centerX = board.Start.X + (board.Width - length) / 2;
            int centerY = board.Start.Y + (board.Height - height) / 2;
            string message = "****GAME OVER****";
            string line2 = "q to quit enter to play again";
            int messX = length > message.Length ? (length - message.Length) / 2 : 0;
            int messY = height / 2;
            int line2X = length > line2.Length ? (length - line2.Length) / 2 : 0;

            timerCounter = 0;
            timer.Interval = ms / 4;
            timer.Elapsed -= OnTimedEvent;
            timer.Elapsed += new ElapsedEventHandler(UponMyDeath);

            
            while (timerCounter < board.Height)
            { 
                int YCursor = board.Start.X + timerCounter;
                for (int j = 0; j < board.Width; j++)
                {
                    int XCursor = board.Start.X + j;
                    Console.SetCursorPosition(XCursor, YCursor);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                }
            }

            timer.Stop();
            timer.Elapsed -= UponMyDeath;
            timerCounter = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < height; i++)
            {
                int YCursor = centerY + i;
                for(int j = 0; j < length; j++)
                {
                    int XCursor = centerX + j;
                    Console.SetCursorPosition(XCursor, YCursor);
                    Console.Write(" ");
                }
            }

            Console.ResetColor();

            Console.SetCursorPosition(centerX + messX, centerY + messY);
            Console.WriteLine(message);
            Console.SetCursorPosition(centerX + line2X, centerY + messY + 1);
            Console.WriteLine(line2);

            ConsoleKeyInfo playAgain;

            do
            {
                playAgain = Console.ReadKey();

            } while (playAgain.Key == ConsoleKey.DownArrow);


            return playAgain.Key;
        }

        //public void OnLineDeletion(Object source, ElapsedEventArgs e)
        //{
        //    timerCounter++;
        //}

    } 
}
