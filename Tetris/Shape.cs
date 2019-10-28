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
                configurations = ShapeDictionary.zero;

            }
            else if(rando == 1)
            {
                this.color = ConsoleColor.Yellow;
                configurations = ShapeDictionary.one;

            }
            else if (rando == 2)
            {
                this.color = ConsoleColor.Red;
                configurations = ShapeDictionary.two;
            }
            else if (rando == 3)
            {
                this.color = ConsoleColor.Blue;
                configurations = ShapeDictionary.three;
            }
            else if (rando == 4)
            {
                this.color = ConsoleColor.Cyan;
                configurations = ShapeDictionary.four;
            }
            else if (rando == 5)
            {
                this.color = ConsoleColor.Magenta;
                configurations = ShapeDictionary.five;
            }
            else if (rando == 6)
            {
                this.color = ConsoleColor.Gray;
                configurations = ShapeDictionary.six;
            }
        }

        public Block [] getBlocks()
        {
            return blocks;
        }

        public void render()
        {
            foreach (Block bk in blocks)
            {
                bk.draw();
            }
        }

        public void delete()
        {
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
                    x -= Block.Width;
                    break;
                case ConsoleKey.RightArrow:
                    x += Block.Width;
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

            //Block bk = new Block(posX, posY, color);

            int addHeight = Block.Height;
            int addWidth = Block.Width;

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

        public void Mutate(List<Point> edges, List<Block> gameState)
        {
            bool hitBorder = false;
            bool hitShape = false;
            int previous = configuration;


            if (configuration == 4){
                configuration = 1;
            }
            else
            {
                configuration++;
            }
            
            Arrange();

            hitBorder = checkCollision(edges, 0, 0);
            hitShape = checkCollision(gameState, 0, 0);

            if(!hitBorder && !hitShape)
            {
                delete();

                render();
            }
            else
            {
                configuration = previous;
                Arrange();

            }

        }

        public bool checkCollision(List<Block> obstacles, int xOffset, int yOffset)
        {
            bool collided = false;

            foreach (Block ob in obstacles)
            {
                collided = checkBlocks(ob, xOffset, yOffset);
                if (collided) break;
            }
            return collided;

        }

        public bool checkCollision(List<Point> borders, int xOffset, int yOffset)
        {
            bool collided = false;

            foreach (Point p in borders)
            {
                collided = checkPoints(p, xOffset, yOffset);
                if (collided) break;
            }
            return collided;

        }

        public bool checkBlocks(Block obstacle, int xOffset, int yOffset)
        {
            bool collided = false;

                foreach (Block blk in blocks)
                {
                    collided = blk.checkBlock(obstacle, xOffset, yOffset);
                    if (collided) break;
                }

            return collided;

        }

        public bool checkPoints(Point p, int xOffset, int yOffset)
        {
            bool collided = false;

            foreach (Block blk in blocks)
            {
                collided = blk.checkEveryPoint(p.X + xOffset, p.Y + yOffset);
                if (collided)
                {
                    collided = true;
                    break;
                }
            }

            return collided;

        }

        public void revert()
        {
            for(int i = 0; i < blocks.Length; i++)
            {
                Block temp = new Block(prior[i].X, prior[i].Y, prior[i].Color);
                temp.inflate();
                blocks[i] = temp;
            }

        }

        public void printAll()
        {
            int index = 0;
            foreach(Block blk in blocks)
            {
                foreach(Point pt in blk.getArea())
                {
                    Console.SetCursorPosition(10, 10 + index);
                    Console.Write($"X: {pt.X}, Y: {pt.Y}");
                    index++;
                }

                int ind = 0;
                foreach (Block b in prior)
                {
                    foreach (Point p in b.getArea())
                    {
                        Console.SetCursorPosition(30, 10 + ind);
                        Console.Write($"X: {p.X}, Y: {p.Y}");
                        ind++;
                    }
                }
            }
        }
    }
}
