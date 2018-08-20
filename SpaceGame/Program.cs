using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        int credits = 1000;
        int shipHealth = 1000;
        int fuel = 1000;
        int cargo = 1000;
        int location = 0;

        static void Main(string[] args)
        {
            (new Program()).run();
        }
        private void run()
        {
            travel();
        }
        private void travel()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("1 = Earth, 2 = Alpha Centauri, 3 = Mystery Planet");
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        location = 0;
                        break;
                    case 2:
                        location = 1;
                        break;
                    case 3:
                        location = 2;
                        break;
                    default:
                        ErrorMessage();
                        travel();
                        return;
                }
                if (location == 0)
                {
                    Console.WriteLine("You have arrived at Earth");
                }
                else if (location == 1)
                {
                    Console.WriteLine("You have arrived at Alpha Centauri.");
                }
                else
                {
                    Console.WriteLine("You have arrived at Mystery Planet.");
                }
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }
        private void ErrorMessage()
        {
            Console.WriteLine("You did not enter a valid destination.");
            travel();
        }
    }
}
