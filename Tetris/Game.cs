using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace Tetris
{
    public class Game
    {

        private Timer timer;
        private int x;
        private int y;
        private Board board;
        private Shape current;
        private List<Block> state = new List<Block>();
        private Random rando = new Random();



        public Game(int x, int y, int height, int width, int ms)
        {
            this.x = x;
            this.y = y;
            Point p = new Point(x, y);
            board = new Board(width, height, p);
            timer = new Timer(ms);
        }

        public void playGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            board.drawBoard();
            current = new Shape(x + board.Width / 2 - 2, y + 5, rando.Next(6));

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

            if (action == ConsoleKey.UpArrow)
            {
                current.Mutate();
            }
            else
            {

                bool hitEdge = false;
                bool hitBlock = false;
                List<Point> edges = board.getBorders();

                if (action == ConsoleKey.LeftArrow)
                {

                    hitEdge = checkBorders(edges, current, 1, 1);
                    hitBlock = checkCollision(current, state, 1, 0);

                    if (!hitEdge && !hitBlock) current.Move(action);
                }

                if (action == ConsoleKey.RightArrow)
                {

                    hitEdge = checkBorders(edges, current, -1, 0);
                    hitBlock = checkCollision(current, state, -1, 0);

                    if (!hitEdge && !hitBlock) current.Move(action);
                }

                if (action == ConsoleKey.DownArrow)
                {

                    hitEdge = checkBorders(edges, current, 0, -1);
                    hitBlock = checkCollision(current, state, 0, -1);

                    if (!hitEdge && !hitBlock) current.Move(action);
                    else
                    {
                        foreach(Block blk in current.getBlocks())
                        {
                            state.Add(blk);

                            int index = 51;
                            foreach(Block bk in state)
                            {
                                Console.SetCursorPosition(71, index);
                                Console.Write($"X: {bk.X}, Y: {bk.Y}");
                                index++;
                            }
                        }

                        current = new Shape(x + board.Width / 2 - 2, y + 5, rando.Next(6));
                        current.Arrange();
                        current.render();
                    }
                }
            }
        }

        public bool checkBorders(List<Point> borders, Shape cur, int xOffset, int yOffset)
        {
            bool didCollide = false;
            foreach (Point p in borders)
            {
                didCollide = cur.checkPoints(p, xOffset, yOffset);
                if (didCollide) break;
            }
            return didCollide;
        }

        public bool checkCollision(Shape cur, List<Block> obstacles, int xOffset, int yOffset)
        {
            bool collided = false;

            foreach (Block ob in obstacles)
            {
                collided = current.checkBlocks(ob, xOffset, yOffset);
                if (collided) break;
            }
            return collided;

        }
    } 
}
