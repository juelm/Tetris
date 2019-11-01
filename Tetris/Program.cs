﻿using System;
using System.Drawing;
using System.Threading;

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

            SplashWriter splashscreen = new SplashWriter(5,5, 1, ConsoleColor.White);

            splashscreen.WriteWord("TETRIS", ConsoleColor.Black, TextStyles.Calico);

            Console.WriteLine("\n\nHit any key to play.");
            Console.WriteLine("\n\nq at any time quits.");

            ConsoleKey initial = Console.ReadKey().Key;
            bool play = true;
            if (initial == ConsoleKey.Q) play = false;

            while (play)
            {
                Game game = new Game(startX, startY, boardHeight, boardWidth, ms);
                play = game.playGame();
            }
        }

    }
}
