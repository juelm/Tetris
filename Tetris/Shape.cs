using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace Tetris
{
    public class Shape
    {

        protected Block[] arrangement;
        protected int x;
        protected int y;
        protected Block[] blocks = new Block[4];
        protected Block[] prior = new Block[4];
        protected ConsoleColor color;
        protected Dictionary<int, int[]> configurations= new Dictionary<int, int[]>();
        protected int configuration = 1;

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public Shape (int x, int y, int rando)
        {
            this.x = x;
            this.y = y;
            //this.color = color;

            if(rando == 0)
            {
                this.color = ConsoleColor.Green;
                int[]pos1 =
                    {
                        0, 0, 0, 0, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 1, 1, 1, 0,
                        0, 1, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 1, 0, 0, 0,
                        0, 1, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);

            }
            else if(rando == 1)
            {
                this.color = ConsoleColor.Yellow;
                int[] pos1 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 1, 0, 0, 0,
                        0, 1, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 1, 1,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);
            }
            else if (rando == 2)
            {
                this.color = ConsoleColor.Red;
                int[] pos1 =
                    {
                        0, 0, 0, 0, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 1, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 1, 0, 0, 0,
                        0, 1, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);
            }
            else if (rando == 3)
            {
                this.color = ConsoleColor.Yellow;
                int[] pos1 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 1, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 1, 0, 0, 0,
                        0, 1, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);
            }
            else if (rando == 4)
            {
                this.color = ConsoleColor.Yellow;
                int[] pos1 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 1, 1, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);
            }
            else if (rando == 5)
            {
                this.color = ConsoleColor.Yellow;
                int[] pos1 =
                    {
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0
                    };

                int[] pos2 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        1, 1, 1, 1, 1,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                int[] pos3 =
                    {
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0,
                        0, 0, 1, 0, 0
                    };

                int[] pos4 =
                    {
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        1, 1, 1, 1, 1,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0
                    };

                configurations.Add(1, pos1);
                configurations.Add(2, pos2);
                configurations.Add(3, pos3);
                configurations.Add(4, pos4);
            }
        }

        public Block [] getBlocks()
        {
            return blocks;
        }

        public void render()
        {
            Console.SetCursorPosition(1, 1);
            Console.Write($"X: {x}, Y: {y} ");
            foreach (Block bk in blocks)
            {
                bk.draw();
            }
        }

        public void delete()
        {
            Console.SetCursorPosition(1, 2);
            Console.Write(prior.Length);
            foreach (Block bk in prior)
            {
                bk.erase();
            }
        }

        public void Move(ConsoleKey pressed)
        {
            switch (pressed)
            {
                case ConsoleKey.LeftArrow:
                    x -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    x += 1;
                    break;
                case ConsoleKey.DownArrow:
                    y += 1;
                    break;
            }

            Arrange();

            delete();

            render();

        }

        public void Arrange()
        {

            int[] arr = configurations[configuration];

            int posX = x;
            int posY = y;

            Block bk = new Block(posX, posY, color);

            int addHeight = bk.Height;
            int addWidth = bk.Width;

            int blockIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 5 == 0)
                {
                    posY += addHeight;
                    posX = x;
                }

                else
                {
                    posX += addWidth;
                }

                if (arr[i] == 1)
                {
                    Block blk = new Block(posX, posY, color);
                    prior[blockIndex] = blocks[blockIndex];
                    blk.inflate();
                    blocks[blockIndex] = blk;
                    blockIndex++;
                }

            }
        }

        public void Mutate()
        {
            if (configuration == 4){
                configuration = 1;
            }
            else
            {
                configuration++;
            }
            
            Arrange();

            delete();

            render();
        }

    }
}
