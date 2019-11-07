using System;
using System.Collections.Generic;
using System.Threading;
namespace Tetris
{
    public enum TextStyles {Solid, Multi, Calico };

    public class SplashWriter
    {

        int pixHeight;
        int pixWidth;
        int Xmargin;
        int Ymargin;
        ConsoleColor backGround;
        int x;
        int y;
        Random rando = new Random();
        int padding = 0;
        //char[] stubborn = { 'R' };

        public ConsoleColor BackGround { get { return backGround; } set { backGround = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Padding { get { return padding; } set { padding = value; } }
        public int YMargin { get { return Ymargin; } set { Ymargin = value; } }
        public int FontWidth { get { return pixWidth; } set { pixWidth = value; } }


        Dictionary<int, ConsoleColor> colors = new Dictionary<int, ConsoleColor>()
        {

            { 0, ConsoleColor.Magenta},
            { 1, ConsoleColor.Cyan},
            { 2, ConsoleColor.Red},
            { 3, ConsoleColor.Blue},
            { 4, ConsoleColor.Yellow},
            { 5, ConsoleColor.Green},
            //{ 6, ConsoleColor.DarkGray}
        };
        Dictionary<char, int> letterDimensions = new Dictionary<char, int>()
        {

            { 'E', 5},
            { 'M', 5},
            { 'F', 5},
            { 'D', 5},
            { 'O', 5},
            { 'X', 5},
            { 'I', 3},
            { 'R', 10},
            { 'S', 5},
            { 'H', 5},
            { 'A', 5},
            { 'T', 5},
            { 'P', 5},
            { 'r', 3},
            { 'e', 4},
            { 's', 5},
            { 'n', 5},
            { 't', 5},
            { 'a', 5},
            { 'i', 3},
            { 'o', 5},
            { 'h', 5},
            { ' ', 2},
            { '_', 4},
            { '.', 3},
            { '?', 5},

        };

        public Dictionary<char, int[]> Alphabet = new Dictionary<char, int[]>()
        {

            { 'E', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0} },

            { 'M', new int[]{   1, 0, 0, 0, 1,
                                1, 1, 0, 1, 1,
                                1, 0, 1, 0, 1,
                                1, 0, 0, 0, 1,
                                1, 0, 0, 0, 1} },

            { '?', new int[]{   0, 1, 1, 1, 0,
                                0, 0, 0, 1, 0,
                                0, 0, 1, 1, 0,
                                0, 0, 0, 0, 0,
                                0, 0, 1, 0, 0} },

            { 'D', new int[]{   0, 1, 1, 0, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 0, 0} },

            { 'O', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0} },

            { 'F', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 0, 0, 0} },

            { 'I', new int[]{   0, 1, 0,
                                0, 1, 0,
                                0, 1, 0,
                                0, 1, 0,
                                0, 1, 0 } },

            { 'R', new int[]{   0, 0, 1, 1, 1, 1, 1, 0, 0, 0,
                                0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
                                0, 0, 1, 1, 1, 1, 1, 0, 0, 0,
                                0, 0, 1, 0, 0, 1, 0, 0, 0, 0,
                                0, 0, 1, 0, 0, 0, 1, 0, 0, 0} },

            { 'X', new int[]{   1, 1, 1, 1, 0,
                                1, 0, 0, 1, 0,
                                1, 1, 1, 1, 0,
                                1, 0, 1, 0, 0,
                                1, 0, 0, 1, 0} },

            { 'T', new int[]{   0, 1, 1, 1, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0} },

            { 'A', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0} },

            { 'H', new int[]{   0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0} },

            { 'S', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 0, 0, 1, 0,
                                0, 1, 1, 1, 0} },

            { 'P', new int[]{   0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 0, 0, 0} },

            { 'r', new int[]{   0, 0, 0,
                                1, 1, 1,
                                1, 0, 1,
                                1, 0, 0,
                                1, 0, 0} },

            { 'e', new int[]{   0, 0, 0, 0,
                                1, 1, 1, 1,
                                1, 1, 2, 1,
                                1, 0, 0, 0,
                                1, 1, 1, 1} },

            { 's', new int[]{   0, 0, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 0, 1, 0,
                                0, 1, 1, 1, 0} },

            { 'n', new int[]{   0, 0, 0, 0, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0} },

            { 't', new int[]{   0, 0, 0, 0, 0,
                                0, 0, 1, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 0, 1, 0, 0,
                                0, 0, 1, 0, 0} },

            { 'a', new int[]{   0, 0, 0, 0, 0,
                                0, 0, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 1} },

            { 'i', new int[]{   0, 1, 0,
                                0, 0, 0,
                                0, 1, 0,
                                0, 1, 0,
                                0, 1, 0} },


            { 'o', new int[]{   0, 0, 0, 0, 0,
                                0, 0, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 1, 1, 0} },

            { 'h', new int[]{   0, 1, 0, 0, 0,
                                0, 1, 0, 0, 0,
                                0, 1, 1, 1, 0,
                                0, 1, 0, 1, 0,
                                0, 1, 0, 1, 0} },

            { ' ', new int[]{   0, 0,
                                0, 0,
                                0, 0,
                                0, 0,
                                0, 0} },

            { '_', new int[]{   0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0} },

            { '.', new int[]{   0, 0, 0,
                                0, 0, 0,
                                0, 0, 0,
                                0, 0, 0,
                                0, 1, 0} },



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

        public void WriteWord(string title, ConsoleColor color = ConsoleColor.Black, TextStyles textStyle = TextStyles.Solid)
        {
            int curX = x;
            int curY = y;
            int startX = x + Xmargin;


            DrawBackground(title);

            switch (textStyle)
            {
                case TextStyles.Multi:
                    foreach (char l in title)
                    {
                        int pixWidth = l == 'R' ? pixHeight : pixHeight * 2;
                        WriteLetter(l, startX, y, colors[rando.Next(6)]);
                        startX += letterDimensions[l] * pixWidth + padding;
                    }
                    break;
                case TextStyles.Calico:
                    foreach (char l in title)
                    {
                        int pixWidth = l == 'R' ? pixHeight : pixHeight * 2;
                        WriteLetter(l, startX, y);
                        startX += letterDimensions[l] * pixWidth + padding;
                    }
                    break;

                default:
                    foreach (char l in title)
                    {
                        int pixWidth = l == 'R' ? pixHeight : pixHeight * 2;
                        WriteLetter(l, startX, y, color);
                        startX += letterDimensions[l] * pixWidth + padding;
                    }
                    break;

            }

            //foreach (char l in title)
            //{
            //    int pixWidth = l == 'R' ? pixHeight : pixHeight * 2;
            //    WriteLetter(l, startX, y, ConsoleColor.Magenta);
            //    startX += letterDimensions[l] * pixWidth;
            //}
        }

        public void WriteLetter(char letter, int x, int y, ConsoleColor background)
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
                    //Console.ForegroundColor = foreground;
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

                if (arr[i] == 2)
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.BackgroundColor = background;
                    //Console.ForegroundColor = foreground;
                    //writePixel();
                    Drawe();
    
                }
            }

        }

        public void WriteLetter(char letter, int x, int y)
        {
            int[] arr = Alphabet[letter];
            int xDim = letterDimensions[letter];

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
                    if (letter == 'R' || letter == 'e') posX += pixWidth / 2;
                    else posX += pixWidth;
                }

                if (arr[i] == 1)
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.BackgroundColor = colors[rando.Next(6)];
                    if (letter == 'R')
                    {
                        DrawR();
                    }
                    else
                    {
                        writePixel();
                    }

                    //Uncomment to add animation
                    //Thread.Sleep(100); 

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

            foreach (char let in word)
            {
                if(let == 'R') backgroundWidth += letterDimensions[let];
                else backgroundWidth += letterDimensions[let] * 2;
                
            }
            backgroundWidth += 2 * pixWidth;
            backgroundHeight += pixHeight * 5 + Ymargin * 2;

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = backGround;
            for (int i = 0; i < backgroundHeight; i++)
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

        public void Drawe(char icon = ' ')
        {

            for (int i = 0; i < pixHeight; i++)
            {

                for (int j = 0; j < pixWidth; j++)
                {
                    
                    ConsoleColor tempFore = Console.ForegroundColor;
                    ConsoleColor tempBack = Console.BackgroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.BackgroundColor = ConsoleColor.Black;
                    //Console.CursorSize = 50;
                    char box = (char)222;
                    Console.Write('▀');
                    Console.ForegroundColor = tempFore;
                    Console.ForegroundColor = tempBack;
                    
                    
                }
                Console.WriteLine();

            }

        }

    }

}
