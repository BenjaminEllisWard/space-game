using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class MainMenu
    {
        private bool Dead = false;
        private Ship MyShip = new Ship();


        public void MainMenuRun()
        {
            Console.WriteLine("What's your next move, Captain?");
            Console.WriteLine("1 = Travel, 2 = Trade, 3 = Status Check, 4 = Cargo Check, 5 = Dump fuel and quit");
            Console.WriteLine("6 = Hints");
            Console.WriteLine();

            try
            {
                int option;

                switch (option = Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        MyShip.Travel();
                        break;
                    case 2:
                        Trade();
                        break;
                    case 3:
                        CheckStatus();
                        break;
                    case 4:
                        MyShip.CheckCargo();
                        break;
                    case 5:
                        // The reason for this implementation of a user choice to end the game is to fulfill the end-game requirement of
                        // 0 fuel = dead. Since planets that are out of range are not displayed as an option, this is the only true way
                        // that fuel can be completely depleted.
                        MyShip.ChangeFuel(-MyShip.GetFuelLevel());
                        break;
                    case 6:
                        Hints();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void Hints()
        {
            Console.Clear();
            Console.WriteLine("You are in space. You are in a spaceship. Go buy things on one planet and sell them on another to make money (credits).");
            Console.WriteLine("If you run out of fuel, you die. If you run out of money, you die. If 40 years elapse, you die.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Hints:");
            Console.WriteLine();
            Console.WriteLine("- Items bought on one planet can be sold for profit only on other planets.");
            Console.WriteLine();
            Console.WriteLine("- Your fuel tank can be upgraded at Eddie's Garage. You can buy new ships there too.");
            Console.WriteLine();
            Console.WriteLine("- The more fuel your ship can hold, the farther you may go. Upgrade your fuel tank");
            Console.WriteLine("  or buy a better ship to find new planets. You can also travel faster (warpFactor)"); 
            Console.WriteLine("  if you have more fuel to burn, so upgrade soon in the game or 40 years will pass quickly.");
            Console.WriteLine();
            Console.WriteLine("- It is best to start out traveling at warpFactor = 1 until you get a new ship.");
            Console.WriteLine();
            Console.WriteLine("- Economies in the far reaches of the universe may not recognize items from early on in the game.");
            Console.WriteLine();
            Console.WriteLine("- If you are stuck with a near empty fuel tank and are low on credits, you can beg for fuel in the");
            Console.WriteLine("  Buy fuel screen. The chance for a successful beg is 1/3.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        // displays current location, ship name, credits, years left and fuel.
        private void CheckStatus()
        {
            Console.Clear();
            Console.WriteLine($"      Location: {MyShip.GetLocation()}");
            Console.WriteLine($"          Fuel: {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
            Console.WriteLine($"       Credits: {MyShip.GetCredits()}");
            Console.WriteLine($"Years traveled: {40 - MyShip.GetYears()}");
            Console.WriteLine($"          Ship: {MyShip.GetShipName()}");
            Console.WriteLine();
        }




        // Trade methods

        public void Trade()
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
                        BuyMenu();
                        break;
                    case 2:
                        switch (MyShip.GetLocationId())
                        {
                            case 1:
                            case 2:
                            case 3:
                                Console.Clear();
                                SellMenu();
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("We don't care about your junk here. Buy a ship or get lost.");
                                Console.WriteLine();
                                break;
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                                OpSellMenu();
                                break;

                        }
                        break;
                    case 3:
                        break;
                    default:
                        TradeError();
                        break;
                }
            }
            catch (Exception)
            {
                TradeError();
            }
        }

        // distinct selling for outer economies
        private void OpSellMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");

            int optionIndex = 1;

            int optionCase1 = 0;
            int optionCase2 = 0;
            int optionCase3 = 0;
            int optionCase4 = 0;
            int optionCase5 = 0;

            if (MyShip.GetItemQuant(3) > 0)
            {
                Console.WriteLine($"{optionIndex} = Pizza for {MyShip.GetPrice(0)} credits / each");
                optionCase1 = optionIndex++;
            }
            if (MyShip.GetItemQuant(4) > 0)
            {
                Console.WriteLine($"{optionIndex} = Op1Item for {MyShip.GetPrice(-1)} credits / each");
                optionCase2 = optionIndex++;
            }
            if (MyShip.GetItemQuant(5) > 0)
            {
                Console.WriteLine($"{optionIndex} = Op2Item for {MyShip.GetPrice(1)} credits / each");
                optionCase3 = optionIndex++;
            }
            if (MyShip.GetItemQuant(6) > 0)
            {
                Console.WriteLine($"{optionIndex} = Op3Item for {MyShip.GetPrice(0)} credits / each");
                optionCase4 = optionIndex++;
            }
            if (MyShip.GetItemQuant(7) > 0)
            {
                Console.WriteLine($"{optionIndex} = Op4Item for {MyShip.GetPrice(-1)} credits / each");
                optionCase5 = optionIndex++;
            }

            try
            {
                int option = int.Parse(Console.ReadLine());

                // if input matches the corresponding optionCase, statement is executed.
                if (option == optionCase1 && option != 0)
                {
                    OpSellItem(3);
                }
                else if (option == optionCase2 && option != 0)
                {
                    OpSellItem(4);
                }
                else if (option == optionCase3 && option != 0)
                {
                    OpSellItem(5);
                }
                else if (option == optionCase4 && option != 0)
                {
                    OpSellItem(6);
                }
                else if (option == optionCase5 && option != 0)
                {
                    OpSellItem(7);
                }
                else
                {
                    Console.WriteLine("You did not pick a valid option.");
                }
            }
            catch (Exception)
            {
                MainError();
            }
        }

        private void OpSellItem(int itemId)
        {
            Console.WriteLine("How many would you like to sell?");
            int quantity = SetQuantity();

            switch (itemId)
            {
                // case to sell pizza
                case 3:
                    if (MyShip.GetItemQuant(itemId) >= quantity)
                    {
                        // enforces unique economy
                        MyShip.ChangeCredits(MyShip.GetPrice(0) * quantity);
                        // adds to lifetime earnings to be displayed at end of game
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(0) * quantity);
                        // removes sold item(s) from cargo inventory
                        MyShip.ChangeItem(3, -quantity);
                        // removes weight from cargo
                        MyShip.ChangeWeight(150 * -quantity);

                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;

                // case to sell Op1Item item. See above for general case statement notes.
                case 4:
                    if (MyShip.GetItemQuant(itemId) >= quantity)
                    {
                        MyShip.ChangeCredits(MyShip.GetPrice(-1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(-1) * quantity);
                        MyShip.ChangeItem(4, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;
                case 5:
                    if (MyShip.GetItemQuant(itemId) >= quantity)
                    {
                        MyShip.ChangeCredits(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeItem(5, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;
                case 6:
                    if (MyShip.GetItemQuant(itemId) >= quantity)
                    {
                        MyShip.ChangeCredits(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeItem(6, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;
                case 7:
                    if (MyShip.GetItemQuant(itemId) >= quantity)
                    {
                        MyShip.ChangeCredits(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeItem(7, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;

                default:
                    TradeError();
                    break;
            }
            
        }

        // distinct selling for inner economies
        private void SellMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");

            int optionIndex = 1;

            int optionCase1 = 0;
            int optionCase2 = 0;
            int optionCase3 = 0;

            if (MyShip.GetItemQuant(0) > 0)
            {
                Console.WriteLine($"{optionIndex} = Earth Item for {MyShip.GetPrice(0)} credits / each");
                optionCase1 = optionIndex++;
            }
            if (MyShip.GetItemQuant(1) > 0)
            {
                Console.WriteLine($"{optionIndex} = Alpha Centauri Item for {MyShip.GetPrice(-1)} credits / each");
                optionCase2 = optionIndex++;
            }
            if (MyShip.GetItemQuant(2) > 0)
            {
                Console.WriteLine($"{optionIndex} = Mystery Planet Item for {MyShip.GetPrice(1)} credits / each");
                optionCase3 = optionIndex++;
            }

            try
            {
                int option = int.Parse(Console.ReadLine());

                // if input matches the corresponding optionCase, statement is executed.
                if (option == optionCase1 && option != 0)
                {
                    SellItem(0);
                }
                else if (option == optionCase2 && option != 0)
                {
                    SellItem(1);
                }
                else if (option == optionCase3 && option != 0)
                {
                    SellItem(2);
                }
                else
                {
                    Console.WriteLine("You did not pick a valid option.");
                }
            }
            catch (Exception)
            {
                MainError();
            }
        }

        // parameter is input by user to determine which item is being sold.
        private void SellItem(int action)
        {
            Console.WriteLine("How many would you like to sell?");
            int quantity = SetQuantity();

            switch (action)
            {
                // case for earth item
                case 0:
                    // enforces current existence within cargo inventory
                    if (MyShip.GetItemQuant(0) >= quantity)
                    {
                        // enforces unique economy
                        MyShip.ChangeCredits(MyShip.GetPrice(0) * quantity);
                        // adds to lifetime earnings to be displayed at end of game
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(0) * quantity);
                        // removes sold item(s) from cargo inventory
                        MyShip.ChangeItem(0, -quantity);
                        // removes weight from cargo
                        MyShip.ChangeWeight(150 * -quantity);

                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;

                // case to sell ac item. See above for general case statement notes.
                case 1:
                    if (MyShip.GetItemQuant(1) >= quantity)
                    {
                        // enforces unique economy. Notice the -1 modifier as opposed to the other cases.
                        MyShip.ChangeCredits(MyShip.GetPrice(-1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(-1) * quantity);
                        MyShip.ChangeItem(1, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;

                // case to sell mp item. See above for general case statement notes.
                case 2:
                    if (MyShip.GetItemQuant(2) >= quantity)
                    {
                        MyShip.ChangeCredits(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeTotalEarned(MyShip.GetPrice(1) * quantity);
                        MyShip.ChangeItem(2, -quantity);
                        MyShip.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {MyShip.GetCredits()}");
                    }
                    else
                    {
                        SellError();
                    }
                    break;

                default:
                    TradeError();
                    break;
            }
        }

        // used to return integer quantity of an item that will be bought/sold. Called in several menus.
        private int SetQuantity()
        {
                int quantity = 0;
                Console.WriteLine("Enter a number 1 - 10");
                Console.WriteLine();
                return quantity = int.Parse(Console.ReadLine());
        }

        private void BuyMenu()
        {
            if (MyShip.GetLocation() == "Easy Eddie's InterGalactic Garage and Massage Parlor")
                // Eddie's Garage gets its own trade options.
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 = Buy Ship");
                Console.WriteLine("2 = Buy Fuel");
                Console.WriteLine("3 = Upgrade fuel tank");

                Console.WriteLine();

                try
                {
                    int option = Int32.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            BuyShip();
                            break;
                        case 2:
                            BuyFuel();
                            break;
                        case 3:
                            UpgradeFuelTank();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    MainError();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                // automatically names item in form "{location} + item"
                Console.WriteLine($"1 = {MyShip.GetLocation()} item: 175 credits / each");
                Console.WriteLine("2 = Fuel");
                Console.WriteLine();
                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            BuyItem();
                            break;
                        case 2:
                            BuyFuel();
                            break;
                        default:
                            TradeError();
                            break;
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    TradeError();
                }
            }
        }

        private void BuyItem()
        {
            Console.WriteLine();
            Console.WriteLine("How many would you like to buy");
            int quantity = SetQuantity();

            // enforces cargo capacity.
            if (MyShip.GetCargoWeight() <= (MyShip.GetCargoCapacity() - (150 * quantity)) && quantity > 0 && quantity <= 10)
            {
                Console.Clear();
                // displays credit change and prompts user for confirmation.
                Console.WriteLine($"This transaction will leave you with {MyShip.GetCredits() - (175 * quantity)} credits. Proceed?");
                Console.WriteLine();
                Console.WriteLine("1 = Yes, 2 = No");
                Console.WriteLine();

                try
                {
                    int option = Int32.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        // deducts credits
                        MyShip.ChangeCredits(-175 * quantity);
                        // first parameter selects location dependent item
                        MyShip.ChangeItem(MyShip.GetItemID(), quantity);
                        // adds weight to cargo
                        MyShip.ChangeWeight(150 * quantity);

                        Console.Clear();
                        Console.WriteLine($"Item purchased. Current credits = {MyShip.GetCredits()}.");
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                catch (Exception)
                {
                    MainError();
                }
            }
            else
            {
                Console.Clear();
                WeightError();
            }
        }

        private void BuyFuel()
        {
            // variable is equal to the amount needed to top off.
            double fuelToMax = MyShip.GetFuelCapacity() - MyShip.GetFuelLevel();

            // condition bypasses fuel purchase if tank is full.
            if (fuelToMax != 0)
            {
                Console.Clear();
                Console.WriteLine($"Your current fuel: {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine();
                Console.WriteLine($"1 = Fill her up for {Convert.ToInt32(Math.Ceiling((fuelToMax * 1.5)))} credits.");
                Console.WriteLine("2 = 200 fuel units for 400 credits");
                Console.WriteLine("3 = Ask a random stranger for gas money.");

                try
                {
                    int option = Int32.Parse(Console.ReadLine());

                    // if condition ensures that user has enough credits to fill up.
                    if (option == 1 && MyShip.GetCredits() > Convert.ToInt32(Math.Ceiling((fuelToMax * 1.5))))
                    {
                        MyShip.ChangeCredits(-Convert.ToInt32(fuelToMax * 1.5));
                        MyShip.ChangeFuel(Convert.ToInt32(fuelToMax));
                        Console.Clear();
                        Console.WriteLine("Fuel purchased.");
                        Console.WriteLine();
                        Console.WriteLine($"Credits = {MyShip.GetCredits()}");
                        Console.WriteLine($"   Fuel = {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
                        Console.WriteLine();
                    }
                    else if (option == 2 && MyShip.GetCredits() > 400)
                    {
                        MyShip.ChangeCredits(-400);
                        MyShip.ChangeFuel(200);
                        Console.Clear();
                        Console.WriteLine("Fuel purchased.");
                        Console.WriteLine();
                        Console.WriteLine($"Credits = {MyShip.GetCredits()}");
                        Console.WriteLine($"   Fuel = {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
                        Console.WriteLine();
                    }
                    // the block following this if statement gives the user a one in three chance to
                    // increase fuel by one. Useful if stranded, but fuel is greater than zero.
                    else if (option == 3)
                    {
                        bool chance = false;
                        Random rand = new Random();

                        if (rand.Next(0, 3) == 0)
                        {
                            chance = true;
                        }

                        if (chance == true)
                        {
                            Console.Clear();
                            Console.WriteLine("A stranger uncomfortably hands you a credit and leaves abruptly. The fuel station");
                            Console.WriteLine("attendant looks at you funny as you ask for a single credit's worth of fuel.");
                            Console.WriteLine();
                            MyShip.ChangeFuel(1);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Get lost, bum!");
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Credits = {MyShip.GetCredits()}");
                        Console.WriteLine($"   Fuel = {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Insufficient funds");
                        Console.WriteLine();
                    }
                }
                catch (Exception)
                {
                    MainError();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your tank is full.");
                Console.WriteLine();
            }
        }

        // increases current ship's fuel capacity.
        private void UpgradeFuelTank()
        {
            Console.Clear();
            Console.WriteLine("Would you like to add 40 units to your fuel capacity?");
            Console.WriteLine("Cost = 500 credits");
            Console.WriteLine();
            Console.WriteLine("1 = Yes, 2 = No");
            Console.WriteLine();

            try
            {
                int option = Int32.Parse(Console.ReadLine());

                if (option == 1)
                {
                    if (MyShip.GetCredits() > 500)
                    {
                        MyShip.ChangeFuelCapacity(MyShip.GetFuelCapacity() + 40);
                        // sets fuel level to new fuel capacity.
                        MyShip.ChangeFuel(MyShip.GetFuelCapacity() - MyShip.GetFuelLevel());
                        MyShip.ChangeCredits(-500);

                        Console.Clear();
                        Console.WriteLine("Fuel tank upgraded.");
                        Console.WriteLine();
                        Console.WriteLine($"Fuel = {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Insufficient Funds");
                        Console.WriteLine();
                    }

                }
            }
            catch (Exception)
            {
                Console.Clear();
                MainError();
            }

        }

        // only available at Eddie's Garage
        private void BuyShip()
        {
            Console.Clear();
            Console.WriteLine("Which ship would you like to buy?");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 = A helium baloon                 \"Seriously, don't try to take this");
            Console.WriteLine("                                     thing into space. And DEFINITELY do");
            Console.WriteLine("    cost:               10           not try to use warp fuel with it.\"");
            Console.WriteLine("    Fuel capacity:       5");
            Console.WriteLine("    Cargo capacity:    200");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2 = Reasonable Rocketship           \"Comes with a full tank and a 3,000");
            Console.WriteLine("                                     lightyear, one Pu half-life");
            Console.WriteLine("    cost:            4,200           warranty. Conditions apply.\"");
            Console.WriteLine("    Fuel capacity:     350");
            Console.WriteLine("    Cargo capacity:  3,000");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3 = Malaysia Airlines Flight 370    \"The fabric of both space and time are left");
            Console.WriteLine("                                     altered in the wake of this craft's journies");
            Console.WriteLine("    cost:           25,000           into and out of the universe. The passengers");
            Console.WriteLine("    Fuel capacity:  50,000           on board have been asking repeatedly for");
            Console.WriteLine("    Cargo capacity: 20,000           \"peanuts and a ginger ale,\" whatever that means.\"");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Select items 1 - 3, or press 4 to do something");
            Console.WriteLine();

            // this is where the action for ship purchasing happens.
            ShipSelector();
        }

        // called in BuyShip().
        private void ShipSelector()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());

                // case for helium balloon.
                if (option == 1 && MyShip.GetCredits() >= 10)
                {
                    // ensures that current cargo weight is not greater than the amount that the purchased ship can hold.
                    if (MyShip.GetCargoWeight() > 200)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        // sets MyShip's fields.
                        MyShip.ChangeFuelCapacity(5);
                        MyShip.ChangeFuel(5);
                        MyShip.ChangeCargoCapacity(200);
                        MyShip.ChangeCredits(-10);
                        MyShip.ChangeShipName("A helium baloon");
                        Console.Clear();
                        Console.WriteLine("You are now the proud owner of a helium balloon.");
                        Console.WriteLine();
                    }
                }
                else if (option == 2 && MyShip.GetCredits() >= 4200)
                {
                    if (MyShip.GetCargoWeight() > 3000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        MyShip.ChangeFuelCapacity(350);
                        MyShip.ChangeFuel(1000);
                        MyShip.ChangeCargoCapacity(3000);
                        MyShip.ChangeCredits(-4200);
                        MyShip.ChangeShipName("Reasonable Rocketship");
                        Console.Clear();
                        Console.WriteLine("Welcome aboard the Reasonable Rocketship. You got a great deal.");
                        Console.WriteLine();
                    }
                }
                else if (option == 3 && MyShip.GetCredits() >= 25000)
                {
                    if (MyShip.GetCargoWeight() > 20000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        MyShip.ChangeFuelCapacity(50000);
                        MyShip.ChangeFuel(50000);
                        MyShip.ChangeCargoCapacity(20000);
                        MyShip.ChangeCredits(-25000);
                        MyShip.ChangeShipName("Malaysia Airlines Flight 370");
                        Console.Clear();
                        Console.WriteLine("You are now Captain of Malaysia Airlines Flight 370. Don't travel to year 2014. They're looking for you there.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    MainError();
                }
            }
            catch (Exception)
            {
                MainError();
            }
        }



        // Error messages

        private void TradeError()
        {
            Console.WriteLine();
            Console.WriteLine("You did not pick a valid option.");
        }

        private void SellError()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have that item to sell.");
        }

        private void WeightError()
        {
            Console.WriteLine();
            Console.WriteLine("Your cargo is full. Go sell something.");
        }

        static public void MainError()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input.");
            Console.WriteLine();
        }



        // Utility methods

        // checks for end-game conditions before MainMenu() is called again from Program.cs.
        public bool DeathChecker()
        {
            bool dead = false;

            if (MyShip.GetFuelLevel() <= 0)
            {
                Console.Clear();
                Console.WriteLine("You're stranded. Aliens are coming to eat you. Try again.");
                dead = true;
            }
            if (MyShip.GetCredits() <= 0)
            {
                Console.Clear();
                Console.WriteLine("You may have fuel, but you're broke. You are doomed to wander aimlessly about the universe. Try again.");
                dead = true;
            }
            if (MyShip.GetYears() <= 0)
            {
                Console.Clear();
                Console.WriteLine("40 years have passed since you first left Earth. After reflecting on a long, prosperous");
                Console.WriteLine("career in intergalactic trade, you decide to retire in Florida.");
                dead = true;
            }
            if (Dead == true)
            {
                dead = true;
            }

            return dead;
        }

        public void EndScreen()
        {
            Console.WriteLine();
            Console.WriteLine($"         Ending credits: {MyShip.GetCredits()}");
            Console.WriteLine($"Lifetime credits earned: {MyShip.GetTotalEarned()}");
            Console.WriteLine($"         Years traveled: {(40 - MyShip.GetYears()).ToString("F2")}");
            Console.WriteLine();
        }
    }
}
