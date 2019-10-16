using System;
using System.Drawing;

namespace Tetris
{
    public class L : Shape
    {

        private static ConsoleColor color = ConsoleColor.Green;

        public L(int x, int y)
        {

            this.x = x;
            this.y = y;

            int posX = x;
            int posY = y;

            Block bk = new Block(posX, y, color);

            int addHeight = bk.Height;
            int addWidth = bk.Width;


            for (int i = 0; i < 3; i++)
            {
                
                Block blk = new Block(posX, y, color);
                blocks[i] = blk;
                posX += addWidth;
                
            }

            bk.Y = bk.Y + addHeight;
            blocks[3] = bk;
        }

        public override void Mutate()
        {
            throw new NotImplementedException();
        }
    }
}
