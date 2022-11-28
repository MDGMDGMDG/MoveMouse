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
            // display information about program to user in the console
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This program moves your mouse between an user generated interval (input time in ms).");
            Console.WriteLine();
            Console.WriteLine("To exit program press CONTROL + C");
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // ask for user input for the time interval between mouse movements
            Console.WriteLine("Please enter minimum milliseconds and press enter");
            var minTime = Console.ReadLine();
            Console.WriteLine("Please enter maximum milliseconds and press enter");
            var maxTime = Console.ReadLine();

            // if user input was not a number take defaults
            if (!Int32.TryParse(minTime, out int min))
                min = 1000;
            if (!Int32.TryParse(minTime, out int max))
                max = 3000;

            while (true)
            {
                Console.WriteLine();

                // declare space of movement for mouse pointer
                int height = 1080;
                int width = 1920;

                // get current pointer position
                Point defPnt = new Point();
                GetCursorPos(ref defPnt);
                
                // set pointer to new position
                SetCursorPos(new Random().Next(width), new Random().Next(height));

                // write pointer position to console
                Console.WriteLine($"X pointer= {defPnt.X.ToString()}, Y pointer= {defPnt.Y.ToString()}");

                // wait x-time (user generated interval) before next mouse movement
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