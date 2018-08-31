using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        static bool Dead = false;
        static Planet Earth = new Planet();
        static Planet AlphaCentauri = new Planet(0, -4.367, "Alpha Centauri", 1, 2);
        static Planet MysteryPlanet = new Planet(-5, 4, "Mystery Planet", 2, 3);
        static Planet ShipGarage = new Planet(2, 1, "Easy Eddie's InterGalactic Garage and Massage Parlor", 3, 3);
        static Ship MyShip = new Ship();
        Cargo Cargo = new Cargo();

        static void Main(string[] args)
        {
            (new Program()).run();
        }

        // General methods

        private void run()
        {
            while (Dead == false)
            {
                mainMenu();
            }
        }

        private void mainMenu()
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
                        MyShip.Travel(pickPlanet());
                        break;
                    case 2:
                        Trade();
                        break;
                    case 3:
                        CheckStatus();
                        break;
                    case 4:
                        Cargo.CheckCargo();
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
            Console.WriteLine($"Location: {MyShip.GetLocation()}");
            Console.WriteLine($"    Fuel: {MyShip.Fuel}");
            Console.WriteLine($" Credits: {Cargo.GetCredits()}");
        }

        // selects destination when traveling
        private Planet pickPlanet()
        {
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("1 = Earth");
            Console.WriteLine("2 = Alpha Centauri");
            Console.WriteLine("3 = Mystery Planet");

            Planet destination = new Planet();

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    destination = Earth;
                    break;
                case 2:
                    destination = AlphaCentauri;
                    break;
                case 3:
                    destination = MysteryPlanet;
                    break;
                default:
                    Console.WriteLine("You must pick a valid destination.");
                    break;
            }
            return destination;
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
                        tradeError();
                        break;
                }
            }
            catch (Exception)
            {
                tradeError();
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
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine($"1 = {MyShip.GetLocation()} item: 175 credits / each"); // automatically names item in form "{location} + item"
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

        private void BuyItem()
        {
            Console.WriteLine();
            Console.WriteLine("How many would you like to buy");
            int quantity = SetQuantity();

            // enforces cargo capacity
            if (Cargo.GetCargoWeight() <= (Cargo.GetCargoCapacity() - (150 * quantity)) && quantity > 0 && quantity <= 10)
            {
                // deducts credits
                Cargo.ChangeCredits(-175 * quantity);
                // first parameter selects location dependent item
                Cargo.ChangeItem(MyShip.GetItemID(), quantity);
                // adds weight to cargo
                Cargo.ChangeWeight(150 * quantity);

                Console.Clear();
                Console.WriteLine($"Item purchased. Current credits = {Cargo.GetCredits()}.");
            }
            else
            {
                weightError();
            }
        }

        private void BuyFuel()
        {
            if (MyShip.GetFuelLevel() < MyShip.GetFuelCapacity())
            {
                Cargo.ChangeCredits(-75);
                MyShip.ChangeFuel(250); // fuel capacity enforced within Ship.ChangeFuel()
                Console.Clear();
                Console.WriteLine("Fuel purchased.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You're tank is full");
            }
            Console.WriteLine($"Credits = {Cargo.GetCredits()}");
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
            //shipSelector();
        }

        //private void shipSelector()
        //{
        //    try
        //    {
        //        int option = int.Parse(Console.ReadLine());
        //        if (option == 1 && credits >= 10)
        //        {
        //            if (cargoWeight > 200)
        //            {
        //                Console.WriteLine();
        //                Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
        //                Console.WriteLine();
        //            }
        //            else
        //            {
        //                ship = 1;
        //                fuel = 100;
        //                fuelCapacity = 100;
        //                cargoCapacity = 200;
        //                credits -= 10;
        //                Console.WriteLine();
        //                Console.WriteLine("You are now the proud owner of a helium balloon.");
        //            }
        //        }
        //        else if (option == 2 && credits >= 4200)
        //        {
        //            if (cargoWeight > 3000)
        //            {
        //                Console.WriteLine();
        //                Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
        //                Console.WriteLine();
        //            }
        //            else
        //            {
        //                ship = 2;
        //                fuel = 1500;
        //                fuelCapacity = 1500;
        //                cargoCapacity = 3000;
        //                credits -= 4200;
        //                Console.WriteLine();
        //                Console.WriteLine("Welcome aboard the Reasonable Rocketship. You got a great deal.");
        //            }
        //        }
        //        else if (option == 3 && credits >= 15000)
        //        {
        //            if (cargoWeight > 20000)
        //            {
        //                Console.WriteLine();
        //                Console.WriteLine("You have more cargo than this ship can hold. Go sell some stuff and try again.");
        //                Console.WriteLine();
        //            }
        //            else
        //            {
        //                ship = 3;
        //                fuel = 999999999;
        //                fuelCapacity = 999999999;
        //                cargoCapacity = 20000;
        //                credits -= 15000;
        //                Console.WriteLine();
        //                Console.WriteLine("You are now Captain of Malaysia Airlines Flight 370. Don't travel to year 2014. They're looking for you there.");
        //            }
        //        }
        //        else
        //        {
        //            mainError();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        mainError();
        //    }
        //} // not yet implemented

        private void SellMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to sell?");

            // the +1/-1 expressions enforce unique economies among three planets.
            Console.WriteLine($"1 = earthItem for {Earth.GetPrice(MyShip.GetPlanetID())} credits"); 
            Console.WriteLine($"2 = acItem for {Earth.GetPrice(MyShip.GetPlanetID() - 1)} credits");
            Console.WriteLine($"3 = mpItem for {Earth.GetPrice(MyShip.GetPlanetID() + 1)} credits");
            Console.WriteLine();
            try
            {
                SellItem(int.Parse(Console.ReadLine()));
            }
            catch (Exception)
            {
                tradeError();
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
                    if (Cargo.GetItemQuant(0) >= quantity)
                    {
                        // enforces unique economy
                        Cargo.ChangeCredits(Earth.GetPrice(MyShip.GetPlanetID()) * quantity);
                        // adds to lifetime earnings to be displayed at end of game
                        Cargo.ChangeTotalEarned(Earth.GetPrice(0) * quantity);
                        // removes sold item(s) from cargo inventory
                        Cargo.ChangeItem(0, -quantity);
                        // removes weight from cargo
                        Cargo.ChangeWeight(150 * -quantity);

                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {Cargo.GetCredits()}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;

                // case to sell ac item. See above for general case statement notes.
                case 2:
                    if (Cargo.GetItemQuant(1) >= quantity)
                    {
                        // enforces unique economy. Notice the -1 modifier as opposed to the other cases.
                        Cargo.ChangeCredits(Earth.GetPrice(MyShip.GetPlanetID() - 1) * quantity);
                        Cargo.ChangeTotalEarned(Earth.GetPrice(MyShip.GetPlanetID() - 1) * quantity);
                        Cargo.ChangeItem(1, -quantity);
                        Cargo.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {Cargo.GetCredits()}");
                    }
                    else
                    {
                        sellError();
                    }
                    break;

                // case to sell mp item. See above for general case statement notes.
                case 3:
                    if (Cargo.GetItemQuant(2) >= quantity)
                    {
                        Cargo.ChangeCredits(Earth.GetPrice(MyShip.GetPlanetID() + 1) * quantity);
                        Cargo.ChangeTotalEarned(Earth.GetPrice(MyShip.GetPlanetID() + 1) * quantity);
                        Cargo.ChangeItem(2, -quantity);
                        Cargo.ChangeWeight(150 * -quantity);
                        Console.Clear();
                        Console.WriteLine($"Item sold. Credits = {Cargo.GetCredits()}");
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


        // Error messages

        private void tradeError()
        {
            Console.WriteLine();
            Console.WriteLine("You did not pick a valid option.");
        }

        private void sellError()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have that item to sell.");
        }

        private void weightError()
        {
            Console.WriteLine();
            Console.WriteLine("Your cargo is full. Go sell something.");
        }
    }
}
