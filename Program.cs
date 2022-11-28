using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("dit programma beweegt je muis tussen 2 random intervallen. geef je minimale en maximale interval door in milliseconden. (voorbeeld ik wil dat mijn muis tussen 1 en 5 seconden beweegt min = 1000 en max = 5000)");
            Console.WriteLine();
            Console.WriteLine("Om programma af te sluiten CONTROL + C");
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine();

            Console.WriteLine("please enter min milliseconds for moving pointer");
            var minTime = Console.ReadLine();
            Console.WriteLine("please enter max milliseconds for moving pointer");
            var maxTime = Console.ReadLine();

            if (!Int32.TryParse(minTime, out int min))
                min = 1000;
            if (!Int32.TryParse(minTime, out int max))
                max = 3000;

            while (true)
            {
                Console.WriteLine();

                // get widht height of console window
                int height = 1080;
                int width = 1920;

                // get pointer position
                Point defPnt = new Point();
                GetCursorPos(ref defPnt);
                
                // set pointer position
                SetCursorPos(new Random().Next(width), new Random().Next(height));

                Console.WriteLine($"X pointer= {defPnt.X.ToString()}, Y pointer= {defPnt.Y.ToString()}");

                Thread.Sleep(new Random().Next(min, max));
            }
        }

        // We need to use unmanaged code
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
    }
}