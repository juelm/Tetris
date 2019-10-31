using System;
using System.Collections.Generic;
namespace Tetris
{
    public class SplashWriter
    {

        int pixHeight;
        int pixWidth;
        string title;
        int x;
        int y;


        public SplashWriter(string title, int startX, int startY, int height, int width = 0)
        {
            this.title = title;
            pixHeight = height;
            x = startX;
            y = startY;

            if (width == 0)
            {
                pixWidth = height * 2;
            }
            else
            {
                pixWidth = width;
            }
        }

        public SplashWriter()
        {

        }

        public void WriteWord()
        {
            int curX = x;
            int curY = y;
            int startX = x;
            foreach(char l in title)
            {
                //Console.SetCursorPosition(startX, y);
                WriteLetter(l ,startX, y, ConsoleColor.Magenta, ConsoleColor.Magenta);
                startX += 5 * pixWidth;
            }
        }

        public void WriteLetter(char letter, int x, int y, ConsoleColor background = ConsoleColor.White, ConsoleColor foreground = ConsoleColor.White, char icon = ' ')
        {
            int[] arr = Alphabet[letter];

            int posX = x;
            int posY = y;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 5 == 0)
                {
                    posY += pixHeight;
                    posX = x;
                }

                else
                {
                    posX += pixWidth;
                }

                if (arr[i] == 1)
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.BackgroundColor = background;
                    Console.ForegroundColor = foreground;
                    writePixel();
                    Console.ResetColor();
                }
            }

        }

        public void writePixel(char icon = ' ')
        {
            for (int i = 0; i < pixHeight; i++)
            {

                for (int j = 0; j < pixWidth; j++)
                {
                    Console.Write(icon);
                }
                Console.WriteLine();

            }
        }

        public Dictionary<char, int[]> Alphabet = new Dictionary<char, int[]>()
        {

            { 'E', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0} },

            { 'I', new int[]{   0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0} },

            { 'R', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 0, 1} },

            { 'T', new int[]{   0, 1, 1, 1, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0} },

            { 'S', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 0, 0, 1, 0,
                                0, 1, 1, 1, 0} },
        };

        //public Dictionary<char, int> letterDimensions = new Dictionary<char, int>()
        //{

        //    { 'E', 5},
        //    { 'I', 3},

        //    { 'R', 5},

        //    { 'S', new int[]{   0, 1, 1, 1, 0,
        //                        0, 1, 0, 0, 0,
        //                        0, 1, 1, 1, 0,
        //                        0, 0, 0, 1, 0,
        //                        0, 1, 1, 1, 0} },
        //};
    }

}
