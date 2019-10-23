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
        private int score;
        List<Block> fallingDebris = new List<Block>();
        // private List<Block> lines;



        public Game(int x, int y, int height, int width, int ms)
        {
            this.x = x;
            this.y = y;
            Point p = new Point(x, y);
            board = new Board(width, height, p);
            timer = new Timer(ms);
            lineTimer = new Timer(ms / 4);
            state = new List<Block>();
        }

        public void playGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            board.drawBoard();
            current = new Shape(board.SpawnPoint.X - Block.Width, board.SpawnPoint.Y, rando.Next(6));

            current.Arrange();

            current.render();

            current.Move(ConsoleKey.DownArrow);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            ConsoleKey userInput = ConsoleKey.UpArrow;

            while (userInput == ConsoleKey.UpArrow || userInput == ConsoleKey.DownArrow || userInput == ConsoleKey.LeftArrow || userInput == ConsoleKey.RightArrow)
            {
                userInput = Console.ReadKey().Key;

                processInput(userInput);

            }
        }


        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //processInput(ConsoleKey.DownArrow);

        }

        public void processInput(ConsoleKey action)
        {

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

                            //Console.Clear();

                            board.drawBoard();

                            foreach(Block b in state)
                            {
                                b.erase();
                                b.inflate();
                                b.draw();

                            }


                            //Console.WriteLine(toDelete.Count);

                            current = new Shape(board.SpawnPoint.X - Block.Width, board.SpawnPoint.Y, 5);
                            current.Arrange();
                            current.render();

                            delay = 0;
                        }

                        else
                        {
                            delay++;
                        }

                        //Console.WriteLine(lines);

                    }
                }
            }
        }

        public void Lines()
        {

            int[] YLines = new int[board.Height + board.Start.Y];
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
                bool wasFound = false;
                foreach(Point p in bk.getArea())
                {
                    foreach(int lin in Yindexes)
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
                            break;
                        }
                            
                    }
                }
            }

            this.score += toDelete.Count;
            //deleteLines(toDelete);

            fallingDebris = fallingBlocks;

            foreach (Block b in toDelete)
            {
                state.Remove(b);

                b.erase();
            }

            //Console.WriteLine(fallingBlocks.Count);
            //Console.WriteLine(minY);
            //Console.WriteLine(maxY);

            //for(int i = 0; i < YLines.Length; i++)
            //{
            //    Console.WriteLine($"Index: {i}, Count: {YLines[i]}");
            //}
            //Console.WriteLine(YLines.Length);
            Console.Clear();
            Console.SetCursorPosition(45, 5);
            for(int i = 0; i < YLines.Length; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(YLines[i]);
            }
            Console.WriteLine(lines);
            Console.WriteLine(minY);
            Console.WriteLine(fallingDebris.Count);


            debrisFall(fallingBlocks, lines);

            //lineTimer.Elapsed += OnLineDeletion2;
            //lineTimer.Enabled = true;

            //debrisFall(fallingDebris);

        }

        //public void deleteLines(List<Block> deleteable)
        //{
        //    timerCounter = 0;
        //    lineTimer.Elapsed += OnLineDeletion;
        //    lineTimer.Enabled = true;

        //    while (timerCounter < 4)
        //    {
        //        Console.WriteLine(timerCounter);
        //        if (timerCounter % 2 == 0)
        //        {
        //            foreach (Block b in deleteable)
        //            {
        //                b.Color = ConsoleColor.White;
        //                b.inflate();

        //            }

        //        }

        //        else
        //        {
        //            foreach (Block b in deleteable)
        //            {
        //                b.Color = ConsoleColor.Black;
        //                b.inflate();

        //            }
        //        }
        //    }

        //    Console.WriteLine(timerCounter);
        //    timerCounter = 0;
        //    lineTimer.Stop();

        //}

        public void debrisFall(List<Block> fallingDebris, int lines)
        {
            foreach(Block b in fallingDebris)
            {
                state.Remove(b);
            }

            for(int i = 0; i < lines; i++)
            {
                foreach(Block bk in fallingDebris)
                {
                    bk.Y += Block.Height;
                    bk.inflate();
                }
            }

            foreach (Block b in fallingDebris)
            {
                state.Add(b);
            }
        }

        //public void debrisFall(List<Block> fallingDebris, List<Point> edges)
        //{

        //    for(int i = (fallingDebris.Count - 1); i >=0; i--)
        //    {
        //        bool hitBottom = false;
        //        bool hitBlock = false;

        //        Block b = fallingDebris[i];
        //        state.Remove(b);
        //        Block falling = new Block(b.X, b.Y,b.Color);
        //        falling.Shift(ConsoleKey.DownArrow);

        //        for (int j = 0; j < state.Count; j++)
        //        {
        //            hitBlock = state[j].checkBlock(falling, 0, + 1);
        //            if (hitBlock)
        //            {
        //                fallingDebris.Remove(b);
        //                state.Add(falling);
        //                //state.Remove(b);
        //                i--;

        //            }
        //        }
        //        for(int k = 0; k < edges.Count; k++)
        //        {
        //            hitBottom = b.checkEveryPoint(edges[k].X, edges[k].Y + 1);
        //            if(hitBottom)
        //            {
        //                fallingDebris.Remove(b);
        //                state.Add(falling);
        //                //state.Remove(b);
        //                i--;

        //            }
        //        }
        //    }

        //    //timerCounter = 0;
        //}


        //public void OnLineDeletion(Object source, ElapsedEventArgs e)
        //{
        //    timerCounter++;   
        //}

        //public void OnLineDeletion2(Object source, ElapsedEventArgs e)
        //{

        //}
    } 
}
