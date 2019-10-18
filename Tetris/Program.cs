using System;
using System.Drawing;
using System.Timers;

namespace Tetris
{
    class Program
    {

        public static int startX = 5;
        public static int startY = 5;
        public static int boardHeight = 50;
        public static int boardWidth = 70;
        public static int ms = 500;

        static void Main(string[] args)
        {
            Game game = new Game(startX, startY, boardHeight, boardWidth, ms);
            game.playGame();
        }

    }


}
