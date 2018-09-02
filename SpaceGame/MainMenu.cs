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
            Console.WriteLine("1 = Travel, 2 = Trade, 3 = Status Check, 4 = Cargo Check, 5 = Quit Game");
            Console.WriteLine();

            try
            {
                int option;

                switch (option = Int32.Parse(Console.ReadLine()))
                {
                    // TODO check style conventions for spacing in switches.
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
                        Dead = true;
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

        private void CheckStatus()
        {
            Console.Clear();
            Console.WriteLine($"Location: {MyShip.GetLocation()}");
            Console.WriteLine($"    Fuel: {MyShip.GetFuelLevel()}");
            Console.WriteLine($" Credits: {MyShip.GetCredits()}");
            Console.WriteLine($"    Ship: {MyShip.GetShipName()}");
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
                        SellMenu();
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

        // used to return integer quantity of an item that will be bought/sold
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
            {
                BuyShip();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                // automatically names item in form "{location} + item"
                Console.WriteLine($"1 = {MyShip.GetLocation()} item: 175 credits / each");
                Console.WriteLine("2 =       Fuel:  75 credits / 250 units");
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

            // enforces cargo capacity
            if (MyShip.GetCargoWeight() <= (MyShip.GetCargoCapacity() - (150 * quantity)) && quantity > 0 && quantity <= 10)
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
                WeightError();
            }
        }

        private void BuyFuel()
        {
            if (MyShip.GetFuelLevel() < MyShip.GetFuelCapacity())
            {
                MyShip.ChangeCredits(-75);
                MyShip.ChangeFuel(250); // fuel capacity enforced within Ship.ChangeFuel()
                Console.Clear();
                Console.WriteLine("Fuel purchased.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You're tank is full");
            }
            Console.WriteLine($"Credits = {MyShip.GetCredits()}");
            Console.WriteLine($"   Fuel = {MyShip.GetFuelLevel()}/{MyShip.GetFuelCapacity()}");
        }

        // not yet implemented
        private void BuyShip()
        {
            Console.Clear();
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
            ShipSelector();
        }

        private void ShipSelector()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                if (option == 1 && MyShip.GetCredits() >= 10)
                {
                    if (MyShip.GetCargoWeight() > 200)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        MyShip.ChangeFuelCapacity(100);
                        MyShip.ChangeFuel(100);
                        MyShip.ChangeCargoCapacity(200);
                        MyShip.ChangeCredits(-10);
                        MyShip.ChangeShipName("A helium baloon");
                        Console.WriteLine();
                        Console.WriteLine("You are now the proud owner of a helium balloon.");
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
                        MyShip.ChangeFuelCapacity(1500);
                        MyShip.ChangeFuel(1500);
                        MyShip.ChangeCargoCapacity(3000);
                        MyShip.ChangeCredits(-4200);
                        MyShip.ChangeShipName("Reasonable Rocketship");
                        Console.WriteLine();
                        Console.WriteLine("Welcome aboard the Reasonable Rocketship. You got a great deal.");
                    }
                }
                else if (option == 3 && MyShip.GetCredits() >= 15000)
                {
                    if (MyShip.GetCargoWeight() > 20000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        MyShip.ChangeFuelCapacity(9999999);
                        MyShip.ChangeFuel(9999999);
                        MyShip.ChangeCargoCapacity(20000);
                        MyShip.ChangeCredits(-15000);
                        MyShip.ChangeShipName("Malaysia Airlines Flight 370");
                        Console.WriteLine();
                        Console.WriteLine("You are now Captain of Malaysia Airlines Flight 370. Don't travel to year 2014. They're looking for you there.");
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

        private void SellMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");

            // the +1/-1 expressions enforce unique economies among three planets.
            Console.WriteLine($"1 = earthItem for {MyShip.GetPrice(0)} credits");
            Console.WriteLine($"2 = acItem for {MyShip.GetPrice(-1)} credits");
            Console.WriteLine($"3 = mpItem for {MyShip.GetPrice(1)} credits");
            Console.WriteLine();
            try
            {
                SellItem(int.Parse(Console.ReadLine()));
            }
            catch (Exception)
            {
                TradeError();
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
                case 1:
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
                case 2:
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
                case 3:
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

        public bool DeathChecker()
        {
            bool dead = false;

            if (MyShip.GetFuelLevel() <= 0)
            {
               dead = true;
            }
            if (MyShip.GetCredits() <= 0)
            {
                dead = true;
            }
            if (MyShip.GetYears() <= 0)
            {
                dead = true;
            }
            if (Dead == true)
            {
                dead = true;
            }

            return dead;
        }
    }
}
