using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        MainMenu MainMenu = new MainMenu();
        private bool Dead = false;

        static void Main(string[] args)
        {
            (new Program()).Run();
        }


        private void Run()
        {
            Console.WriteLine("This message gives an introduction to the game. " +
                              "Edit the text in the run() method to alter this message.");
            Console.WriteLine();
            Console.WriteLine("You are in space. You are in a spaceship. Go buy things on one planet and sell them on another to make money (credits).");
            Console.WriteLine("If you run out of fuel, you die. If you run out of money, you die. If 40 years elapse, you die.");
            Console.WriteLine();

            // loop continues game until Dead is returned true.
            while (Dead == false)
            {
                MainMenu.MainMenuRun();
                Dead = MainMenu.DeathChecker();
            }

            MainMenu.EndScreen();
        }

    }
}