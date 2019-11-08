using System;
namespace Tetris
{
    public class UML : Scoreboard
    {
        string[] methods;

        public UML(int height, int width, int cursorX, int cursorY, ConsoleColor borderColor, ConsoleColor textColor, string text, string[] methodList) : base (height, width, cursorX, cursorY, borderColor, textColor, text)
        {
            methods = methodList;
        }

        public void displayMethods()
        {
            //int textY = cursorY + 3;
            //Console.SetCursorPosition(cursorX + 3, cursorY + 3);
            for(int i = 0; i < methods.Length; i++)
            {
                Console.SetCursorPosition(cursorX + 3, cursorY + 3 + i);
                Console.Write(methods[i]);
                

            }

        }
    }
}
