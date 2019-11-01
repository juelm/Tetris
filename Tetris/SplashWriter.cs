using System;
using System.Collections.Generic;
namespace Tetris
{
    public class SplashWriter
    {

        int pixHeight;
        int pixWidth;
        int Xmargin;
        int Ymargin;
        ConsoleColor backGround;
        int x;
        int y;
        Dictionary<char, int> letterDimensions = new Dictionary<char, int>()
        {

            { 'E', 5},
            { 'I', 3},
            { 'R', 10},
            { 'S', 5},
            { 'T', 5},
        };

        public Dictionary<char, int[]> Alphabet = new Dictionary<char, int[]>()
        {

            { 'E', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0} },

            { 'I', new int[]{   0, 1, 0,
                                0, 1, 0,
                                0, 1, 0,
                                0, 1, 0,
                                0, 1, 0 } },

            //{ 'R', new int[]{   0, 1, 1, 1, 0,
            //                    0, 1, 0, 1, 0,
            //                    0, 1, 1, 0, 0,
            //                    0, 1, 0, 1, 0,
            //                    0, 1, 0, 1, 0} },

            //{ 'R', new int[]{   0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0,
            //                    0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0,
            //                    0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0,
            //                    0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0,
            //                    0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0,
            //                    0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0} },

            { 'R', new int[]{   0, 0, 1, 1, 1, 1, 1, 0, 0, 0,
                                0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
                                0, 0, 1, 1, 1, 1, 1, 0, 0, 0,
                                0, 0, 1, 0, 0, 1, 0, 0, 0, 0,
                                0, 0, 1, 0, 0, 0, 1, 0, 0, 0} },

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


        public SplashWriter(int startX, int startY, int height, ConsoleColor backGround = ConsoleColor.Black, int width = 0)
        {
            pixHeight = height;
            x = startX;
            y = startY;
            this.backGround = backGround;
            Xmargin = height * 2;
            Ymargin = height;

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

        public void WriteWord(string title)
        {
            int curX = x;
            int curY = y;
            int startX = x + Xmargin;

            DrawBackground(title);

            foreach (char l in title)
            {
                int pixWidth = l == 'R' ? pixHeight : pixHeight * 2;
                WriteLetter(l, startX, y, ConsoleColor.Magenta, ConsoleColor.Magenta);
                startX += letterDimensions[l] * pixWidth;
            }
        }

        public void WriteLetter(char letter, int x, int y, ConsoleColor background = ConsoleColor.White, ConsoleColor foreground = ConsoleColor.White, char icon = ' ')
        {
            int[] arr = Alphabet[letter];
            int xDim = letterDimensions[letter];
            //int pixWidth = letter == 'R' ? pixHeight : pixHeight * 2;

            int posX = x;
            int posY = y;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % xDim == 0)
                {
                    posY += pixHeight;
                    posX = x;
                }

                else
                {
                    if (letter == 'R') posX += pixWidth / 2;
                    else posX += pixWidth;
                }

                if (arr[i] == 1)
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.BackgroundColor = background;
                    Console.ForegroundColor = foreground;
                    //writePixel();
                    if (letter == 'R')
                    {
                        DrawR();
                    }
                    else
                    {
                        writePixel();
                    }
                    
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

        public void DrawBackground(string word)
        {
            int backgroundHeight = 0;
            int backgroundWidth = 0;
            //ConsoleColor backColor = ConsoleColor.White;

            foreach (char let in word)
            {
                backgroundWidth += letterDimensions[let] * 2;
            }
            //backgroundWidth += 2 * pixWidth;
            backgroundHeight += pixHeight * 5 + Ymargin * 2;

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = backGround;
            for(int i = 0; i < backgroundHeight; i++)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                for (int j = 0; j < backgroundWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void DrawR(char icon = ' ')
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

    }

}
