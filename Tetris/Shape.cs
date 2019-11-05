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





        //Block configurations for a given shape are represented as a 5 x 5 array of integers and are read in from 
        //ShapeDictionary class upon initialization based on random number and stored in configurations instance variable

        public Shape (int x, int y, int rando)
        {
            this.x = x;
            this.y = y;

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





        //Instantiates each block for the current position of the shape and stores them in the "blocks" instance variable
        //and records the previous position of each block in the "prior" instance variable for deletion.

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





        //Changes the configuration of the blocks in shape to one of the other arrangements in the configurations instance variable

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

            hitBorder = checkCollision(edges, 0, 0); //Check to see if requested mutation will collide with other blocks or walls
            hitShape = checkCollision(gameState, 0, 0);

            if(!hitBorder && !hitShape) //if no collision delete prior and render
            {
                delete();

                render();
            }
            else                        //if collision revert to prior and render
            {
                configuration = previous;
                Arrange();

            }

        }





        //Check for collision with other blocks or walls. Overloaded for convenience as walls are individual points and blocks are array of points.

        public bool checkCollision(List<Block> obstacles, int xOffset, int yOffset) // X & Y offset to determine collision before visual overlap
        {
            bool collided = false;

            foreach (Block ob in obstacles)
            {
                collided = checkBlocks(ob, xOffset, yOffset);
                if (collided) break;
            }
            return collided;

        }

        public bool checkCollision(List<Point> borders, int xOffset, int yOffset) // X & Y offset to determine collision before visual overlap
        {
            bool collided = false;

            foreach (Point p in borders)
            {
                collided = checkPoints(p, xOffset, yOffset);
                if (collided) break;
            }
            return collided;

        }





        
        //Checks each point in each block in shape against each block in obstacle for collision

        public bool checkBlocks(Block obstacle, int xOffset, int yOffset) // X & Y offset to determine collision before visual overlap
        {
            bool collided = false;

                foreach (Block blk in blocks)
                {
                    collided = blk.checkBlock(obstacle, xOffset, yOffset);
                    if (collided) break;
                }

            return collided;

        }




        //Checks each point in each block in shape against given Point p

        public bool checkPoints(Point p, int xOffset, int yOffset) // X & Y offset to determine collision before visual overlap
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
    }
}
