using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
//Matthew
=======

>>>>>>> 30d2fffabd512719d986a905da3faa1c031cc074

namespace SpaceGame
{
    
   class Program
    {
        // resources and death criteria
        int credits = 1000;
        int totalCreditsEarned = 0;
        int shipHealth = 1000;
        double fuel = 1000;
        int fuelCapacity = 1000;
        int cargoWeight = 0;
        int cargoCapacity = 1000;
        double yearsLeft = 40;
        int location = 0;           // This variable changes between 0, 1, and 2 throughout the program, corresponding to Earth, Alpha Centauri, and Mystery Planet respectively.

        // variables for travel calculations
        double x1 = 0;              // x1 & y1 are coordinates associated with the players current location. Set each time currentCoords() is called.
        double y1 = 0;
        double x2 = 0;              // x2 & y2 are coordinates associated with the travel destination. Set inside travel().
        double y2 = 0;
        double side1 = 0;           
        double side2 = 0;
        double travelDistance = 0;
        int warpFactor = 1;
        double warpSpeed = 0;
        double efficiency = 1;      // affects fuel burned per distance. Set in fuelEfficiency().

        // trade items
        int earthItem = 0;
        int acItem = 0;
        int mpItem = 0;

        int ship = 0;   // determines your current ship

        bool dead = false;          // used to reinitiate mainMenu loop throughout game duration

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        static void Main(string[] args)
        {
            (new Program()).run();
        }

        // general methods
        private void run()
        {
            Console.WriteLine("This message gives an introduction to the game. " +
                              "Edit the text in the run() method to alter this message.");
            Console.WriteLine();
            Console.WriteLine("You are in space. You are in a spaceship. Go buy things on one planet and sell them on another to make money (credits).");
            Console.WriteLine("If you run out of fuel, you die. If you run out of money, you die. If 40 years elapse, you die.");
            Console.WriteLine();

            while (dead == false)
            {
                mainMenu();
                deathCheck();
            }
            endScreen();
            Console.ReadLine();
        }                   // initiates game and contains loop that continues game
        private void deathCheck()
        {
            if (fuel <= 0)
            {
                dead = true;
                Console.WriteLine();
                Console.WriteLine("You're stranded. Aliens are coming to eat you. Try again.");
            }
            else if (credits <= 0)
            {
                dead = true;
                Console.WriteLine();
                Console.WriteLine("You may have fuel, but you're broke. You are doomed to wander aimlessly about the universe. Try again.");
            }
            else if (yearsLeft <= 0)
            {
                dead = true;
                Console.WriteLine();
                Console.WriteLine("40 years have passed since you first left Earth. After reflecting on a long, prosperous");
                Console.WriteLine("career in intergalactic trade, you decide to retire in Florida.");
            }
            //additional condition will go here (years, ship health, etc.)
            else
            {
                Console.WriteLine();
            }
        }            // checks criteria that will end game
        private void mainMenu()
        {
            Console.WriteLine("What's your next move, Captain?");
            Console.WriteLine("1 = Travel, 2 = Trade, 3 = Status Check, 4 = Cargo Check, 5 = Quit Game");
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
                        if (location == 3)
                        {
                            buyship();
                        }
                        else
                        {
                            trade();
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        checkResources();
                        break;
                    case 4:
                        Console.WriteLine();
                        checkCargo();
                        break;
                    case 5:
                        dead = true;
                        Console.WriteLine();
                        Console.WriteLine("You are a quitter.");
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
        private void checkResources()
        {
            Console.WriteLine();
            Console.WriteLine($"      Credits = {credits}");
            Console.WriteLine($"  Ship Health = {shipHealth}");
            Console.WriteLine($"   Fuel Level = {(fuel).ToString("F0")}");
            Console.WriteLine($" Cargo Weight = {cargoWeight}/{cargoCapacity}");
            Console.WriteLine($" Time elapsed = {(40 - yearsLeft).ToString("F2")} of 40 years.");
            Console.WriteLine($"     Location = {locationDisplaySetter()}");
            Console.WriteLine($"         ship = {shipDisplaySetter()}");
            Console.WriteLine();
        }
        private string locationDisplaySetter()
        {
            string locationDisplay;
            if (location == 0)
            {
                locationDisplay = "Earth";
            }
            else if (location == 1)
            {
                locationDisplay = "Alpha Centauri";
            }
            else if (location == 2)
            {
                locationDisplay = "Mystery Planet";
            }
            else
            {
                locationDisplay = "Easy Eddie's InterGalactic Garage and Massage Parlor";
            }
            return locationDisplay;
        }
        private string shipDisplaySetter()
        {
            string shipName;
            if (ship == 0)
            {
                shipName = "Your Great Start Ship";
            }
            else if (ship == 1)
            {
                shipName = "A helium balloon";
            }
            else if (ship == 2)
            {
                shipName = "Reasonable Rocketship";
            }
            else
            {
                shipName = "Malaysia Airlines Flight 370";
            }
            return shipName;
        }
        private void checkCargo()
        {
            Console.WriteLine();
            Console.WriteLine($" Earth items: {earthItem}");
            Console.WriteLine($"    Ac items: {acItem}");
            Console.WriteLine($"    Mp items: {mpItem}");
            Console.WriteLine($"Cargo Weight: {cargoWeight}/{cargoCapacity}");
            Console.WriteLine();
        }
        private void endScreen()
        {
            Console.WriteLine();
            Console.WriteLine($"Credits: {credits}");
            Console.WriteLine($"Total credits earned: {totalCreditsEarned}");
            Console.WriteLine($"Time traveled: {(40 - yearsLeft).ToString("F2")} years");
            Console.WriteLine();
            Console.WriteLine("End of game.");
        }
        private void mainError()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input");
            Console.WriteLine();
        }

        // travel methods
        private void travel()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine($"1 = Earth, 2 = Alpha Centauri, 3 = Mystery Planet");
            Console.WriteLine("4 = Easy Eddie's InterGalactic Garage and Massage Parlor, 5 = Stay here");
            Console.WriteLine();
            try
            {
                int option;
                switch (option = int.Parse(Console.ReadLine()))
                {
                    case 1:
                        x2 = 0;
                        y2 = 0;
                        travelCalc();
                        fuelBurn(option);
                        break;
                    case 2:
                        x2 = 0;
                        y2 = -4.367;
                        travelCalc();
                        fuelBurn(option);
                        break;
                    case 3:
                        x2 = -5;
                        y2 = 4;
                        travelCalc();
                        fuelBurn(option);
                        break;
                    case 4:
                        x2 = 2;
                        y2 = 1;
                        travelCalc();
                        fuelBurn(option);
                        break;
                    case 5:
                        Console.WriteLine();
                        break;
                    default:
                        travelError();
                        break;
                }
            }
            catch (Exception)
            {
                travelError();
            }
        }
        private void travelError()
        {
            Console.WriteLine("You did not enter a valid destination.");
            Console.WriteLine();
            travel();
        }
        private void warpSelector()
        {
            Console.WriteLine("Select your warp speed, Captain.");
            Console.WriteLine("Enter a number 1 - 10.");
            Console.WriteLine();
            try
            {
                warpFactor = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (warpFactor > 0 && warpFactor <= 10)
                {
                    travel();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You must enter a valid warp speed.");
                    Console.WriteLine();
                }
            }
            catch
            {
                mainError();
            }
        }
        private void travelCalc()
        {
            currentCoordsCalc();
            sideLengthCalc();
            distanceCalc();
            warpSpeedCalc();
        }                // used to call all calculation methods at once.
        private void currentCoordsCalc()
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
        private void sideLengthCalc()
        {
            side1 = x1 - x2;
            side2 = y1 - y2;
        }
        private void distanceCalc()
        {
            travelDistance = Math.Sqrt((side1 * side1) + (side2 * side2));
        }
        private void warpSpeedCalc()
        {
            warpSpeed = Math.Pow(warpFactor, (10.0 / 3.0)) + Math.Pow((10 - warpFactor), (-11.0 / 3.0));
        }
        private void fuelEfficiencyCalc()
        {
            efficiency = Math.Pow(warpFactor, 1.5);
        }
        private void fuelBurn(int destination)
        {
            fuelEfficiencyCalc();
            string locationDisplay;
            if (destination == 1)
            {
                locationDisplay = "Earth";
            }
            else if (destination == 2)
            {
                locationDisplay = "Alpha Centauri";
            }
            else if (destination == 3)
            {
                locationDisplay = "Mystery Planet";
            }
            else
            {
                locationDisplay = "Easy Eddie's InterGalactic Garage and Massage Parlor";
            }
            Console.WriteLine();
            Console.WriteLine($"This trip will cost you {(efficiency * travelDistance * 10).ToString("F0")} fuel and {(travelDistance / warpSpeed).ToString("F2")} years.");
            Console.WriteLine("Do you wish to proceed?");
            Console.WriteLine("1 = Yes, 2 = No");
            Console.WriteLine();
            try
            {
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    fuel -= efficiency * travelDistance * 10;
                    yearsLeft -= travelDistance / warpSpeed;
                    location = destination - 1;
                    Console.WriteLine();
                    Console.WriteLine($"You have arrived at {locationDisplay}.");
                    Console.WriteLine($"{(40 - yearsLeft).ToString("F2")} years have passed since you first left Earth.");
                    Console.WriteLine($"Your fuel level is: {(fuel).ToString("F0")}/{fuelCapacity}. Think about refueling this stop.");
                    Convert.ToDouble(fuel);
                }
                else if (option == 2)
                {
                    Console.WriteLine(); ;
                }
                else
                {
                    mainError();
                }
            }
            catch
            {
                mainError();
            }

        }   // prompts user to initiate travel, then subtracts resources

        // trade methods
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
                case 3:
                    buyship();
                    break;
                default:
                    break;
            }
        }
        private void earthBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1 = Earth item: 175 credits / each");
            Console.WriteLine("2 =       Fuel:  75 credits / 250 units");
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
            }
            catch (Exception)
            {
                tradeError();
            }

        }
        private void acBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 =    Ac item: 175 credits / each");
            Console.WriteLine("2 =       Fuel:  75 credits / 250 units");
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
            }
            catch (Exception)
            {
                tradeError();
            }
        }
        private void mpBuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 = Mp item: 175 credits / each");
            Console.WriteLine("2 =    Fuel:  75 credits / 250 units");
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
            }
            catch (Exception)
            {
                tradeError();
            }
        }
        private void buyEarthItem()
        {
            Console.WriteLine();
            Console.WriteLine("How many would you like to buy");
            int quantity = setQuantity();
            if (cargoWeight <= (cargoCapacity - (150 * quantity)) && quantity > 0 && quantity <= 10)
            {
                credits -= 175 * quantity;
                earthItem += 1 * quantity;
                cargoWeight += 150 * quantity;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
            }
            else
            {
                weightError();
            }
        }
        private void buyAcItem()
        {
            Console.WriteLine();
            Console.WriteLine("How many would you like to buy");
            int quantity = setQuantity();
            if (cargoWeight <= (cargoCapacity - (150 * quantity)) && quantity > 0 && quantity <= 10)
            {
                credits -= 175 * quantity;
                acItem += 1 * quantity;
                cargoWeight += 150 * quantity;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
            }
            else
            {
                weightError();
            }
        }
        private void buyMpItem()
        {
            Console.WriteLine();
            Console.WriteLine("How many would you like to buy");
            int quantity = setQuantity();
            if (cargoWeight <= (cargoCapacity - (150 * quantity)) && quantity > 0 && quantity <= 10)
            {
                credits -= 175 * quantity;
                mpItem += 1 * quantity;
                cargoWeight += 150 * quantity;
                Console.WriteLine();
                Console.WriteLine($"Item purchased. Current credits = {credits}.");
            }
            else
            {
                weightError();
            }
        }
        private void buyFuel()
        {
            if (fuel <= fuelCapacity - 250)
            {
                credits -= 75;
                fuel += 250;
                Console.WriteLine();
                Console.WriteLine("Fuel purchased.");
            }
            else if (fuel > fuelCapacity - 250 && fuel < fuelCapacity)
            {
                credits -= 75;
                fuel = fuelCapacity;
                Console.WriteLine();
                Console.WriteLine("Fuel purchased.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You're tank is full");
            }
            Console.WriteLine($"Credits = {credits}.");
            Console.WriteLine($"Fuel = {(fuel).ToString("F0")}.");
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
                case 3:
                    Console.WriteLine("We don't buy things here.");
                    break;
                default:
                    tradeError();
                    break;
            }
        }       // used to vary sell prices based on location
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
            catch (Exception)
            {
                tradeError();
            }
        }
        private void sellEarth(int action)
        {
            Console.WriteLine("How many would you like to sell?");
            int quantity = setQuantity();
            switch (action)
            {
                case 1:
                    if (earthItem >= quantity)
                    {
                        credits += 150 * quantity;
                        totalCreditsEarned += 150 * quantity;
                        earthItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem >= quantity)
                    {
                        credits += 250 * quantity;
                        totalCreditsEarned += 250 * quantity;
                        acItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem >= quantity)
                    {
                        credits += 275 * quantity;
                        totalCreditsEarned += 275 * quantity;
                        mpItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
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
            catch (Exception)
            {
                tradeError();
            }
        }
        private void sellAc(int action)
        {
            Console.WriteLine("How many would you like to sell?");
            int quantity = setQuantity();
            switch (action)
            {
                case 1:
                    if (earthItem >= quantity)
                    {
                        credits += 275 * quantity;
                        totalCreditsEarned += 275 * quantity;
                        earthItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem >= quantity)
                    {
                        credits += 150 * quantity;
                        totalCreditsEarned += 150 * quantity;
                        acItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem >= quantity)
                    {
                        credits += 250 * quantity;
                        totalCreditsEarned += 250 * quantity;
                        mpItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
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
            catch (Exception)
            {
                tradeError();
            }
        }
        private void sellMp(int action)
        {
            Console.WriteLine("How many would you like to sell?");
            int quantity = setQuantity();
            switch (action)
            {
                case 1:
                    if (earthItem >= quantity)
                    {
                        credits += 250 * quantity;
                        totalCreditsEarned += 250 * quantity;
                        earthItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 2:
                    if (acItem >= quantity)
                    {
                        credits += 275 * quantity;
                        totalCreditsEarned += 275 * quantity;
                        acItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
                        Console.WriteLine();
                        Console.WriteLine($"Item sold. Credits = {credits}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;
                case 3:
                    if (mpItem >= quantity)
                    {
                        credits += 150 * quantity;
                        totalCreditsEarned += 150 * quantity;
                        mpItem -= 1 * quantity;
                        cargoWeight -= 150 * quantity;
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
        private int setQuantity()
        {
            int quantity = 0;
            Console.WriteLine("Enter a number 1 - 10");
            Console.WriteLine();
            return quantity = int.Parse(Console.ReadLine());
        }           // used to return integer quantity of an item that will be bought/sold
        private void sellError()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have that item to sell.");
        }
        private void tradeError()
        {
            Console.WriteLine();
            Console.WriteLine("You did not pick a valid option.");
        }      
        private void weightError()
        {
            Console.WriteLine();
            Console.WriteLine("Your cargo is full. Go sell something.");
        }

        //ship stuff
        private void buyship()
        {
            Console.WriteLine();
            Console.WriteLine("Which ship would you like to buy?");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 = A helium baloon                 \"Seriously, don't try to take this");
            Console.WriteLine("                                     thing into space. And DEFINITELY do");
            Console.WriteLine("    cost:               10           not try to use warp fuel with it.\"");
            Console.WriteLine("    Fuel capacity:     100");      
            Console.WriteLine("    Cargo capacity:    200");      
            Console.WriteLine();                                  
            Console.WriteLine();                                  
            Console.WriteLine();                                  
            Console.WriteLine("2 = Reasonable Rocketship           \"Comes with a full tank and a 3,000");
            Console.WriteLine("                                     lightyear, one Pu half-life");
            Console.WriteLine("    cost:            4,200           warranty. Conditions apply.\"");
            Console.WriteLine("    Fuel capacity:   1,500");      
            Console.WriteLine("    Cargo capacity:  3,000");      
            Console.WriteLine();                                  
            Console.WriteLine();                                  
            Console.WriteLine();                                  
            Console.WriteLine("3 = Malaysia Airlines Flight 370    \"The fabric of both space and time are left");
            Console.WriteLine("                                     altered in the wake of this craft's journies");
            Console.WriteLine("    cost:           15,000           into and out of the universe. The passengers");
            Console.WriteLine("    Fuel capacity:     NaN           on board have been asking repeatedly for");
            Console.WriteLine("    Cargo capacity: 20,000           \"peanuts and a ginger ale,\" whatever that means.\"");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Select items 1 - 3, or press 4 to do something");
            Console.WriteLine();
            shipSelector();
        }
        private void shipSelector()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                if (option == 1 && credits >= 10)
                {
                    if (cargoWeight > 200)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        ship = 1;
                        fuel = 100;
                        fuelCapacity = 100;
                        cargoCapacity = 200;
                        credits -= 10;
                        Console.WriteLine();
                        Console.WriteLine("You are now the proud owner of a helium balloon.");
                    }
                }
                else if (option == 2 && credits >= 4200)
                {
                    if (cargoWeight > 3000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        ship = 2;
                        fuel = 1500;
                        fuelCapacity = 1500;
                        cargoCapacity = 3000;
                        credits -= 4200;
                        Console.WriteLine();
                        Console.WriteLine("Welcome aboard the Reasonable Rocketship. You got a great deal.");
                    }
                }
                else if (option == 3 && credits >= 15000)
                {
                    if (cargoWeight > 20000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        ship = 3;
                        fuel = 999999999;
                        fuelCapacity = 999999999;
                        cargoCapacity = 20000;
                        credits -= 15000;
                        Console.WriteLine();
                        Console.WriteLine("You are now Captain of Malaysia Airlines Flight 370. Don't travel to year 2014. They're looking for you there.");
                    }
                }
                else
                {
                    mainError();
                }
            }
            catch (Exception)
            {
                mainError();
            }
        } 
    }
}