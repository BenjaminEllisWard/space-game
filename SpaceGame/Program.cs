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
        int cargoWeight = 0;
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
            Console.WriteLine("This is an introduction message that gives an introduction to the game. " +
                              "Edit the text in the run() method to alter this message.");
            Console.WriteLine();
            mainMenu();
        }
        private void mainMenu()
        {
            Console.WriteLine("What's your next move, Captain?");
            Console.WriteLine("1 = Travel, 2 = Trade, 3 = Status Check, 4 = Cargo Check");
            Console.WriteLine();
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
                    case 4:
                        Console.WriteLine();
                        checkCargo();
                        break;

                    default:
                        mainError();
                        break;
                }
            }
            catch (Exception)
            {
                mainError();
            }
        }
        public void travel()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("1 = Earth, 2 = Alpha Centauri, 3 = Mystery Planet, 4 = Stay here");
            Console.WriteLine();
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine();
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
                        Console.WriteLine();
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
                        Console.WriteLine();
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
                    case 4:
                        Console.WriteLine();
                        mainMenu();
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine($"Your fuel level is: {fuel}/1000. Think about refueling this stop.");
                deathCheck();
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }
        private void trade()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 = Buy, 2 = Sell, 3 = Something else");
            Console.WriteLine();
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        buyMenu();
                        break;
                    case 2:
                        sellMenuSelector();
                        break;
                    case 3:
                        mainMenu();
                        break;

                    default:
                        tradeError();
                        break;
                }
            }
            catch (Exception)
            {
                tradeError();
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
            Console.WriteLine();
            Console.WriteLine($" Credits = {credits}");
            Console.WriteLine($" Ship Health = {shipHealth}");
            Console.WriteLine($" Fuel Level = {fuel}");
            Console.WriteLine($" Cargo Weight = {cargoWeight}/1000");
            Console.WriteLine($" Location = {location}");
            Console.WriteLine();
            mainMenu();
        }
        private void checkCargo()
        {
            Console.WriteLine();
            Console.WriteLine($"Earth items: {earthItem}");
            Console.WriteLine($"Ac items: {acItem}");
            Console.WriteLine($"Mp items: {mpItem}");
            Console.WriteLine($" Cargo Weight = {cargoWeight}/1000");
            Console.WriteLine();
            mainMenu();
        }
        private void deathCheck()
        {
            if (fuel <= 0)
            {
                Console.WriteLine("You're stranded. Aliens are coming to eat you. Try again.");
                endScreen();
            }
            else if (credits <= 0)
            {
                Console.WriteLine("You may have fuel, but you're broke. You are doomed to wander aimlessly about the universe. Try again.");
                endScreen();
            }
            //additional condition will go here (years, ship health, etc.)
            else
            {
                Console.WriteLine();
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
                    acBuyMenu();
                    break;
                case 2:
                    mpBuyMenu();
                    break;
                default:
                    mainMenu();
                    break;
            }
        }
        private void earthBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1 = Earth item, 2 = Fuel");
            Console.WriteLine();
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
                        tradeError();
                        break;
                }
                Console.WriteLine();
                deathCheck();
            }
            catch (Exception)
            {
                tradeError();
            }

        }
        private void acBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1 = Ac item, 2 = Fuel");
            Console.WriteLine();
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        buyAcItem();
                        break;
                    case 2:
                        buyFuel();
                        break;
                    default:
                        tradeError();
                        break;
                }
                Console.WriteLine();
                deathCheck();
            }
            catch (Exception)
            {
                tradeError();
            }
        }
        private void mpBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1 = Mp item, 2 = Fuel");
            Console.WriteLine();
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        buyMpItem();
                        break;
                    case 2:
                        buyFuel();
                        break;
                    default:
                        tradeError();
                        break;
                }
                Console.WriteLine();
                deathCheck();
            }
            catch (Exception)
            {
                tradeError();
            }
        }
        private void buyEarthItem()
        {
            if (cargoWeight < 851)
            {
                credits -= 200;
                earthItem += 1;
                cargoWeight += 150;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
                deathCheck();
            }
            else
            {
                weightError();
            }
        }
        private void buyAcItem()
        {
            if (cargoWeight < 851)
            {
                credits -= 200;
                acItem += 1;
                cargoWeight += 150;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
                deathCheck();
            }
            else
            {
                weightError();
            }
        }
        private void buyMpItem()
        {
            if (cargoWeight < 851)
            {
                credits -= 200;
                mpItem += 1;
                cargoWeight += 150;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
                deathCheck();
            }
            else
            {
                weightError();
            }
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
        private void sellMenuSelector()
        {
            switch (location)
            {
                case 0:
                    sellEarthMenu();
                    break;
                case 1:
                    sellAcMenu();
                    break;
                case 2:
                    sellMpMenu();
                    break;
                default:
                    tradeError();
                    break;
            }
        }
        private void sellEarthMenu ()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");
            Console.WriteLine("1 = earthItem for 150 credits");
            Console.WriteLine("2 = acItem for 250 credits");
            Console.WriteLine("3 = mpItem for 275 credits");
            Console.WriteLine();
            try
            {

                        sellEarth(int.Parse(Console.ReadLine()));
                        
            }
            catch (Exception ex)
            {
                tradeError();
            }
        }
        private void sellEarth(int action)
        {
            switch (action)
            {
                case 1:
                    if (earthItem > 0)
                    {
                        credits += 150;
                        earthItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem > 0)
                    {
                        credits += 250;
                        acItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem > 0)
                    {
                        credits += 275;
                        mpItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                default:
                    tradeError();
                    break;
            }
        }
        private void sellAcMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");
            Console.WriteLine("1 = earthItem for 275 credits");
            Console.WriteLine("2 = acItem for 150 credits");
            Console.WriteLine("3 = mpItem for 250 credits");
            Console.WriteLine();
            try
            {

                sellAc(int.Parse(Console.ReadLine()));

            }
            catch (Exception ex)
            {
                tradeError();
            }
        }
        private void sellAc(int action)
        {
            switch (action)
            {
                case 1:
                    if (earthItem > 0)
                    {
                        credits += 275;
                        earthItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem > 0)
                    {
                        credits += 150;
                        acItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem > 0)
                    {
                        credits += 250;
                        mpItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                default:
                    Console.WriteLine();
                    tradeError();
                    break;
            }
        }
        private void sellMpMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");
            Console.WriteLine("1 = earthItem for 250 credits");
            Console.WriteLine("2 = acItem for 275 credits");
            Console.WriteLine("3 = mpItem for 150 credits");
            Console.WriteLine();
            try
            {

                sellMp(int.Parse(Console.ReadLine()));

            }
            catch (Exception ex)
            {
                tradeError();
                mainMenu();
            }
        }
        private void sellMp(int action)
        {
            switch (action)
            {
                case 1:
                    if (earthItem > 0)
                    {
                        credits += 250;
                        earthItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem > 0)
                    {
                        credits += 275;
                        acItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem > 0)
                    {
                        credits += 150;
                        mpItem -= 1;
                        cargoWeight -= 150;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                default:
                    Console.WriteLine();
                    tradeError();
                    break;
            }
        }
        private void mainError()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input");
            Console.WriteLine();
            mainMenu();
        }
        private void sellError()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have that item to sell.");
            deathCheck();
        }
        private void tradeError()
        {
            Console.WriteLine();
            Console.WriteLine("You did not pick a valid option.");
            trade();
        }
        private void weightError()
        {
            Console.WriteLine();
            Console.WriteLine("Your cargo is full. Go sell something.");
            deathCheck();
        }
        private void endScreen()
        {
            Console.WriteLine("End of game.");
        }
    }
}
