using System;
namespace Tetris
{
    public class Presentation
    {
        int indent = 5;
        int currentY = 5;
        public Presentation()
        {
        }

        public void Start()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            SplashWriter title = new SplashWriter(5, 5, 1, ConsoleColor.Black);
            SplashWriter label = new SplashWriter(5, 5, 1, ConsoleColor.Black);


            label.WriteWord("TETRIS", ConsoleColor.Black, TextStyles.Calico);
            title.WriteWord("", ConsoleColor.Black, TextStyles.Calico);



            //title.Y = 17;
            //title.BackGround = ConsoleColor.White;
            //title.FontWidth = 1;
            //title.WriteWord("The Presentation");
            //Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            Console.ReadKey();
            
            Console.WriteLine("\n\n     The Presentation");

            Console.ReadKey();


            Shape bullet = new Shape(indent - 2, Console.CursorTop + 1, 5);
            bullet.Arrange();
            bullet.render();

            title.X = indent * 3;
            title.Y = Console.CursorTop - 3;
            title.BackGround = ConsoleColor.White;
            title.FontWidth = 1;
            title.Padding = - 4;
            title.YMargin = 0;
            title.WriteWord("STATE");
       

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(indent * 4, Console.CursorTop + 2);
            Console.WriteLine("Shape = Block[]");
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("Block = Point[]");
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("Each point represents a character space on the console, and has a unique x and y.");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine();

            Shape bullet2 = new Shape(indent - 2, Console.CursorTop + 1, 4);
            bullet2.Arrange();
            bullet2.render();

            title.X = indent * 3;
            title.Y = Console.CursorTop - 4;
            title.BackGround = ConsoleColor.White;
            title.FontWidth = 1;
            title.Padding = -4;
            title.YMargin = 0;
            title.WriteWord("THXEAD_SAFE");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;


            Console.SetCursorPosition(indent * 4, Console.CursorTop + 2);
            Console.WriteLine("Game uses a timer to cause the shape to fall and trigger other game events");
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("User input can also cause the shape to move and trigger events");
            Console.ReadKey();
            Console.SetCursorPosition(indent * 4, Console.CursorTop + 1);
            Console.WriteLine("  -  Unusual behavior.");
            Console.ReadKey();
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("  -  Difficult to Debug.");
            Console.ReadKey();
            Console.SetCursorPosition(indent * 4, Console.CursorTop + 1);
            Console.WriteLine("Critical Section / Lock");
            Console.ReadKey();


            Shape bullet3 = new Shape(indent - 2, Console.CursorTop + 1, 3);
            bullet3.Arrange();
            bullet3.render();

            title.X = indent * 3;
            title.Y = Console.CursorTop - 4;
            title.BackGround = ConsoleColor.White;
            title.FontWidth = 1;
            title.Padding = -4;
            title.YMargin = 0;
            title.WriteWord("MOXPH...?");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;


            Console.SetCursorPosition(indent * 4, Console.CursorTop + 2);
            Console.WriteLine("Polymorphism vs Dictionary");
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("Create abstract shape class and a class for each shape");
            Console.SetCursorPosition(indent * 4, Console.CursorTop);
            Console.WriteLine("Or some other way");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            Console.ReadKey();
        }
    }
}
