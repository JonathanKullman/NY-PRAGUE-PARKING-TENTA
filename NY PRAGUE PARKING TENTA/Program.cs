using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace NY_PRAGUE_PARKING_TENTA
{
    class Program
    {
        static void Main(string[] args)
        {

              
            //SKapar dessa två encoding.unicode för att kunna skriva ut och ta in bland annat tjeckiska tecken.
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            //Här lägger vi in den nuvarande valutan till tjeckiska för att valutan ska vara relevant.    
            CultureInfo.CurrentCulture = new CultureInfo("cs-CZ");

            //Skapar ett objekt "startMenu" av classen "MethodsInclMenu" för att anropa metoden "MainMenu" som kör igång parkeringsprogrammet.
            MethodsInclMenu startMenu = new MethodsInclMenu();
            startMenu.MainMenu();

            //När man vill stänga av programmet skickas man hit.
           
            
            //Skriver ut att programmet stängs till användaren....
            Console.Clear();
            string dots = "....";

            Console.SetCursorPosition(38, 11);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("PRAGUE PARKING 2.0 IS SHUTTING DOWN");

            for (int i = 0; i < dots.Length; i++)
            {
                Console.Write(dots[i]);
                Thread.Sleep(1300);
            }
        }
    }
}
