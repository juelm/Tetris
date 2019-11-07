using System;
using System.Drawing;
namespace Tetris
{


    /// <summary>
    /// Creates renders and controls all behavior for the individual block objects that comprise each shape and the state of the game board.
    /// Each block is comprised of individual points.
    /// </summary>
    public class Block
    {

        //private Point position;
        private int x;
        private int y;
        private ConsoleColor color;
        private static int height = 1;
        private static int width = height * 2;
        private Point[] area;

        //public Point Position { set; get; }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Point[] getArea()
        {
            return area;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public static int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public static int Width
        {
            get
            {
                return width;
            }
        }


        public Block(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            area = new Point[height * (height * 2)];

        }




        //instantiates each point contained in the block

        public void inflate()
        {

            int index = 0;
            int posX = x;
            int posY = y;

            for (int i = 0; i < height; i++)
            {
                posX = x;
                for (int j = 0; j < height * 2; j++)
                {
                    Point current = new Point(posX, posY);
                    area[index] = current;
                    index++;
                    posX++;
                }
                posY++;

            }
        }




        //Renders each point contained in the block

        public void draw()
        {
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                Console.BackgroundColor = color;
                Console.Write(" ");
            }
            Console.ResetColor();
        }





        public void Shift(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.LeftArrow:
                    x -= width;
                    break;
                case ConsoleKey.RightArrow:
                    x += width;
                    break;
                case ConsoleKey.DownArrow:
                    y += height;
                    break;
            }

            inflate();

        }




        //Erases each point contained in the block

        public void erase()
        {
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                Console.Write(" ");
            }

            Console.ResetColor();
        }




        //Checks each point in block for collision with given x / y coordinates

        public bool checkEveryPoint(int xCoord, int yCoord)
        {
            bool didCollide = false;
                foreach (Point pt in area)
                {
                    if (xCoord == pt.X && yCoord == pt.Y)
                    {
                        didCollide = true;
                        break;
                    }
                }
            return didCollide;
        }




        //Checks each point in block for collision with each block in b

        public bool checkBlock(Block b, int xOffset, int yOffset) // X & Y offset to determine collision before visual overlap
        {
            bool collision = false;
            foreach(Point p in b.area)
            {
                collision = checkEveryPoint(p.X + xOffset, p.Y + yOffset);
                if (collision) break;
            }
            return collision;
        }
    }
}
