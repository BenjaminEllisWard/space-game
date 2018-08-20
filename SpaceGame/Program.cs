﻿using System;
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
        int cargoWeight = 1000;
        int location = 0;
        int yearsLeft = 40;
        int earthItem = 0;
        int acItem = 0;
        int mpItem = 0;

        static void Main(string[] args)
        {
            (new Program()).run();
            
        }
        private void run()
        {
            mainMenu();
            
        }
        private void mainMenu()
        {
            Console.WriteLine("What's your next move, Captain?");
            Console.WriteLine("1 = Travel, 2 = Trade, 3 = Status Check");
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine();
                        travel();
                        break;
                    case 2:
                        trade();
                        break;
                    case 3:
                        Console.WriteLine();
                        checkStatus();
                        break;

                    default:
                        ErrorMessage();
                        break;
                }
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }
        public void travel()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("1 = Earth, 2 = Alpha Centauri, 3 = Mystery Planet");
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("You have arrived at Earth");
                        if (location == 1)
                        {
                            fuel -= 100;
                        }
                        else if (location == 2)
                        {
                            fuel -= 200;
                        }
                        else { }
                        location = 0;
                        break;
                    case 2:
                        Console.WriteLine("You have arrived at Alpha Centauri.");
                        if (location == 0)
                        {
                            fuel -= 100;
                        }
                        else if (location == 2)
                        {
                            fuel -= 200;
                        }
                        else { }
                        location = 1;
                        break;
                    case 3:
                        Console.WriteLine("You have arrived at Mystery Planet.");
                        if (location == 0)
                        {
                            fuel -= 100;
                        }
                        else if (location == 1)
                        {
                            fuel -= 200;
                        }
                        else { }
                        location = 2;
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine($"Your fuel level is: {fuel}/1000. Think about refueling this stop.");
                Console.WriteLine();
                deathCheck();
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }
        private void trade()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 = Buy, 2 = Sell, 3 = Something else");
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        buyMenu();
                        break;
                    case 2:
                        Console.WriteLine("What would you like to sell?");
                        break;
                    case 3:
                        break;

                    default:
                        ErrorMessage();
                        break;
                }
                Console.WriteLine();
                mainMenu();
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }
        private void ErrorMessage()
        {
            Console.WriteLine("You did not enter a valid destination.");
            Console.WriteLine();
            travel();
        }
        private void checkStatus()
        {
            Console.WriteLine($" Credits = {credits}");
            Console.WriteLine($" Ship Health = {shipHealth}");
            Console.WriteLine($" Fuel Level = {fuel}");
            Console.WriteLine($" Cargo Weight = {cargoWeight}");
            Console.WriteLine($" Location = {location}");
            Console.WriteLine();
            mainMenu();
        }
        private void deathCheck()
        {
            if (fuel <= 0)
            {
                Console.WriteLine("You're stranded. Aliens are coming to eat you. Try again.");
            }
            else if (credits <= 0)
            {
                Console.WriteLine("You may have fuel, but you're broke. You are doomed to wander aimlessly about the universe. Try again.");
            }
            //additional condition will go here (years, ship health, etc.)
            else
            {
                mainMenu();
            }
        }
        private void buyMenu()
        {
            switch (location)
            {
                case 0:
                    earthBuyMenu();
                    break;
                case 1:
                    earthBuyMenu(); // This menu needs to be replaced w mpBuyMenu
                    break;
                case 2:
                    earthBuyMenu(); // This menu needs to be replaced w mpBuyMenu
                    break;
                default:
                    mainMenu();
                    break;
            }
        }
        private void earthBuyMenu()
        {
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1 = Earth item, 2 = Fuel");
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        buyEarthItem();
                        break;
                    case 2:
                        buyFuel();
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
                Console.WriteLine();
                mainMenu();
            }
            catch (Exception)
            {
                ErrorMessage();
            }

        }
        private void acBuyMenu() //This menu needs to be completed.
        {

        }
        private void mpBuyMenu() //This menu needs to be completed.
        {

        }
        private void buyEarthItem()
        {
            credits -= 200;
            earthItem += 1;
            cargoWeight += 150;
            Console.WriteLine($"Item purchased. Current credits = {credits}.");
            deathCheck();
        }
        private void buyAcItem()
        {
            credits -= 200;
            acItem += 1;
            cargoWeight += 150;
            deathCheck();
        }
        private void buyMpItem()
        {
            credits -= 200;
            mpItem += 1;
            cargoWeight += 150;
            deathCheck();
        }
        private void buyFuel()
        {
            credits -= 100;
            fuel += 200;
            Console.WriteLine("Fuel purchased.");
            Console.WriteLine($"Credits = {credits}.");
            Console.WriteLine($"Fuel = {fuel}.");
            deathCheck();
        }
    }
}
