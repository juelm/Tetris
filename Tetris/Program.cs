using System;
using System.Drawing;
using System.Timers;

namespace Tetris
{
    class Program
    {

        static int startX = 0;
        static int startY = 0;
        static int height = 50;
        static int width = 70;
        static int ms = 100;

        static void Main(string[] args)
        {
            Game game = new Game(startX, startY, height, width, ms);
            game.playGame();
        }

    }


}
