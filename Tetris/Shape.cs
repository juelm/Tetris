using System;
using System.Timers;
using System.Drawing;

namespace Tetris
{
    public abstract class Shape
    {

        protected Block[] arrangement;
        protected int x;
        protected int y;
        protected Block[] blocks = new Block[4];
        protected Block[] prior = new Block[4];

        public void Shift(ConsoleKey direction, int magnitude)
        {


            for (int i = 3; i >=0; i--)
            {
                switch (direction)
                {
                    case ConsoleKey.LeftArrow:
                        prior[i] = blocks[i];
                        blocks[i].erase();
                        blocks[i].X -= magnitude;
                        break;
                    case ConsoleKey.RightArrow:
                        prior[i] = blocks[i];
                        blocks[i].erase();
                        blocks[i].X += magnitude;
                        break;
                    case ConsoleKey.DownArrow:
                        prior[i] = blocks[i];
                        blocks[i].erase();
                        blocks[i].Y += magnitude;
                        break;
                }

                blocks[i].draw();
                prior[i].erase();
            }
        }

        public Block [] getBlocks()
        {
            return blocks;
        }

        public void Stop()
        {

        }

        public void Move(ConsoleKey pressed)
        {
            switch (pressed)
            {
                case ConsoleKey.LeftArrow:
                    x -= 1;
                    Shift(ConsoleKey.LeftArrow, 1);
                    break;
                case ConsoleKey.RightArrow:
                    x += 1;
                    Shift(ConsoleKey.RightArrow, 1);
                    break;
                case ConsoleKey.DownArrow:
                    y += 1;
                    Shift(ConsoleKey.DownArrow, 1);
                    break;
            }
        }

        public abstract void Mutate();

    }
}
