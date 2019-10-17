using System;
using System.Timers;
using System.Drawing;
namespace Tetris
{
    public class Game
    {

        private Timer timer;
        private int x;
        private int y;
        private Board board;
        private Shape current;
        private Shape[] state;
        


        public Game(int x, int y, int height, int width, int ms)
        {
            this.x = x;
            this.y = y;
            Point p = new Point(x, y);
            board = new Board(width, height, p);
            timer = new Timer(ms);
            state = new Shape[100];


        }

        public void playGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            board.drawBoard();
            current = new Shape(x + board.Width / 2 - 2, y + 1, ConsoleColor.Green);

            int[] pos1 ={
                0, 0, 0, 0, 0,
                0, 0, 1, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0,
                0, 0, 0, 0, 0 };

            current.Arrange(pos1);

            current.render();

            current.Move(ConsoleKey.DownArrow);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            ConsoleKey action = ConsoleKey.UpArrow;


            while (action == ConsoleKey.UpArrow || action == ConsoleKey.DownArrow || action == ConsoleKey.LeftArrow || action == ConsoleKey.RightArrow)
            {
                action = Console.ReadKey().Key;

                if(action == ConsoleKey.UpArrow)
                {
                    current.Mutate();
                }
                else
                {
                    current.Move(action);
                }

            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //current.Fall();

            //if ()
            //{

            //}
        }
    }

        //public void checkEdge(Board bo, Shape sh)
        //{
        //    Block[] blks = sh.getBlocks();
        //    foreach (Block blk in blks)
        //    {
        //        Point[] pts = blk.getArea();
        //        foreach(Point pt in pts)
        //        {
                    
        //        }
        //    }
        //}


   
}
