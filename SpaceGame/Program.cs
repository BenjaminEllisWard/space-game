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
        double fuel = 1000;
        int cargoWeight = 0;
        int location = 0;
        double x1 = 0; // x1 & y1 are coordinates associated with the players current location.
        double y1 = 0;
        double x2 = 0; // x2 & y2 are coordinate associated with the travel destination.
        double y2 = 0;
        double side1 = 0;
        double side2 = 0;
        double travelDistance = 0;
        int warpFactor = 1;
        double warpSpeed = 0;
        double efficiency = 1;
        double yearsLeft = 40;
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
                        warpSelector();
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
                        x2 = 0;
                        y2 = 0;
                        travelCalc();
                        Console.WriteLine();
                        Console.WriteLine("You have arrived at Earth");
                        location = 0;
                        break;
                    case 2:
                        x2 = 0;
                        y2 = -4.367;
                        travelCalc();
                        Console.WriteLine();
                        Console.WriteLine("You have arrived at Alpha Centauri.");
                        location = 1;
                        break;
                    case 3:
                        x2 = -5;
                        y2 = 4;
                        travelCalc();
                        Console.WriteLine();
                        Console.WriteLine("You have arrived at Mystery Planet.");
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
                Console.WriteLine($"Your fuel level is: {Convert.ToInt32(fuel)}/1000. Think about refueling this stop.");
                Convert.ToDouble(fuel);
                deathCheck();
            }
            catch (Exception)
            {
                ErrorMessage();
            }
        }     // mainMenu(), ErrorMessage(), deathCheck(), travelCalc()
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
        }     // buyMenu(), sellMenuSelector(), mainMenu(), tradeError()
        private void ErrorMessage()
        {
            Console.WriteLine("You did not enter a valid destination.");
            Console.WriteLine();
            travel();
        }   // travel()
        private void checkStatus()
        {
            Console.WriteLine();
            Console.WriteLine($" Credits = {credits}");
            Console.WriteLine($" Ship Health = {shipHealth}");
            Console.WriteLine($" Fuel Level = {Convert.ToInt32(fuel)}");
            Console.WriteLine($" Cargo Weight = {cargoWeight}/1000");
            Console.WriteLine($" Location = {location}");
            Console.WriteLine($" Years Passed = {(Convert.ToUInt32(40 - yearsLeft))}");
            Console.WriteLine();
            Convert.ToDouble(fuel);
            mainMenu();
        }   // mainMenu()
        private void checkCargo()
        {
            Console.WriteLine();
            Console.WriteLine($"Earth items: {earthItem}");
            Console.WriteLine($"Ac items: {acItem}");
            Console.WriteLine($"Mp items: {mpItem}");
            Console.WriteLine($"Cargo Weight = {cargoWeight}/1000");
            Console.WriteLine();
            mainMenu();
        }   // mainMenu()
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
            else if (yearsLeft <= 0)
            {
                Console.WriteLine("40 years have passed since you first left Earth. After reflecting on a long, prosperous career in intergalactic trade, you decide to retire in Florida.");
                endScreen();
            }
            //additional condition will go here (years, ship health, etc.)
            else
            {
                Console.WriteLine();
                mainMenu();
            }
        }   // mainMenu(), endScreen()
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
        }   // earthBuyMenu(), acBuyMenu(), mpBuyMenu(), mainMenu()
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

        }   // buyEarthItem(), buyFuel(), tradeError(), deathCheck(), tradeError()
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
        }   // buyAcItem(), buyFuel(), tradeError(), deathCheck(), tradeError()
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
        }   // buyMpItem(), buyFuel(), tradeError(), deathCheck(), tradeError()
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
        }   // deathCheck(), weightError()
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
        }      // deathCheck(), weightError()
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
        }      // deathCheck(), weightError()
        private void buyFuel()
        {
            credits -= 100;
            fuel += 200;
            Console.WriteLine("Fuel purchased.");
            Console.WriteLine($"Credits = {credits}.");
            Console.WriteLine($"Fuel = {Convert.ToInt32(fuel)}.");
            Convert.ToDouble(fuel);
            deathCheck();
        }   // deathCheck()
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
        }   // sellEarthMenu(), sellAcMenu(), sellMpMenu(), tradeError()
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
        }   //sellEarth(), tradeError()
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
        }   //sellError()
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
        }   //sellAc(), tradeError()
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
        }   //sellError()
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
        }   //sellMp(), tradeError()
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
        }   //sellError(),tradeError()
        private void mainError()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input");
            Console.WriteLine();
            mainMenu();
        }   // mainMenu()
        private void sellError()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have that item to sell.");
            deathCheck();
        }   //deathCheck()
        private void tradeError()
        {
            Console.WriteLine();
            Console.WriteLine("You did not pick a valid option.");
            trade();
        }   // trade()
        private void weightError()
        {
            Console.WriteLine();
            Console.WriteLine("Your cargo is full. Go sell something.");
            deathCheck();
        }   // deathCheck()
        private void endScreen() // needs additional features for end credits requirements
        {
            Console.WriteLine("End of game.");
        }
        private void currentCoords()
        {
            if (location == 0)
            {
                x1 = 0;
                y1 = 0;
            }
            else if (location == 1)
            {
                x1 = 0;
                y1 = -4.367;
            }
            else
            {
                x1 = -5;
                y1 = 4;
            }
        }
        private void sideLength()
        {
            side1 = x1 - x2;
            side2 = y1 - y2;
        }
        private void distanceCalc()
        {
            travelDistance = Math.Sqrt((side1 * side1) + (side2 * side2));
        }
        private void travelCalc()
        {
            currentCoords();
            sideLength();
            distanceCalc();
            warpSpeedCalc();
            yearsLeft -= travelDistance / warpSpeed;
            fuelBurn();
            Console.WriteLine($"distance = {travelDistance}");
            Console.WriteLine($"years left = {Convert.ToInt32(yearsLeft)}");
            Console.WriteLine($"fuel left = {Convert.ToInt32(fuel)}");
            Convert.ToDouble(fuel);
            Console.WriteLine($"Velocity = {Convert.ToInt32(warpSpeed)} Times faster than light speed");
        }   // currentCoords(), sideLength(), distanceCalc(), warpSpeedCalc()
        private void warpSpeedCalc()
        {
            warpSpeed =  Math.Pow(warpFactor, 3.3333333333) + Math.Pow(10 - warpFactor, -3.6666666666);
        }
        private void warpSelector()
        {
            Console.WriteLine("Select your warp speed, Captain.");
            Console.WriteLine("Enter a number 1 - 10.");
            Console.WriteLine();
            try
            {
                warpFactor = int.Parse(Console.ReadLine());
                if (warpFactor > 0 && warpFactor <= 10)
                {
                    travel();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You must enter a valid warp speed.");
                    Console.WriteLine();
                    mainMenu();
                }
            }
            catch
            {
                mainError();
            }
        }   // travel(), mainMenu(), mainError()
        private void fuelEfficiency()
        {
            efficiency = Math.Pow(warpFactor, 1.5);
        }
        private void fuelBurn()
        {
            fuelEfficiency();
            fuel -= efficiency * travelDistance;
        }   // fuelEfficiency()
    }
}
