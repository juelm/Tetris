using System;
using System.Drawing;
using System.Timers;

namespace Tetris
{
    class Program
    {

        public static int startX = 5;
        public static int startY = 5;
        //public static int blockHeight = 1;
        //public static int blockWidth = blockHeight * 2;
        public static int margin = 3;
        public static int boardHeight = Block.Height * 26;
        public static int boardWidth = Block.Width * 20 + margin;
        public static int ms = 500;

        static void Main(string[] args)
        {

            bool play = true;

            while (play)
            {
                Game game = new Game(startX, startY, boardHeight, boardWidth, ms);
                play = game.playGame();
            }
        }

    }
}
