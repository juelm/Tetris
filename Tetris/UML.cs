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
    }
}
