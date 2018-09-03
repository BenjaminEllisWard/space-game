using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Ship
    {
        // ship fields

        private int Fuel = 10;
        private int FuelCapacity = 10;
        private string ShipName = "Your Starter Ship";
        public Planet Location = Planet.Earth();
        private Cargo Cargo = new Cargo();
        private double YearsLeft = 40;

        // instantiated planets

        private Planet Earth = new Planet();
        private Planet AlphaCentauri = new Planet(0, -4.367, "Alpha Centauri", 1, 2);
        private Planet MysteryPlanet = new Planet(-5, 4, "Mystery Planet", 2, 3);
        private Planet ShipGarage = new Planet(2, 1, "Easy Eddie's InterGalactic Garage and Massage Parlor", 0, 4);
        private Planet PizzaPlanet = new Planet(20, 30, "Pizza Planet", 3, 6);
        private Planet OtherPlanet = new Planet(-20, -30, "Other Planet", 4, 7);
        private Planet OtherPlanet2 = new Planet(-20, 30, "Other Planet2", 5, 8);
        private Planet OtherPlanet3 = new Planet(20, -30, "Other Planet3", 6, 9);
        private Planet OtherPlanet4 = new Planet(45, 45, "Other Planet4", 7, 10);



        // constructors

        public Ship()
        {
            this.Fuel = 10;
            this.FuelCapacity = 10;
            this.ShipName = "Your Starter Ship";
        }

        public Ship(int fuelCapacity, string shipName, Planet location)
        {
            this.FuelCapacity = fuelCapacity;
            this.ShipName = shipName;
            this.Location = Planet.Earth();
        }



        // ship checks/sets

        public string GetLocation()
        {
            return Location.PlanetName;
        }

        public int GetLocationId()
        {
            return Location.PlanetID;
        }

        public string GetShipName() => ShipName;

        public int GetItemID()
        {
            return Location.ItemID;
        }

        public int GetPlanetID()
        {
            return Location.PlanetID;
        }

        public int GetFuelLevel()
        {
            return this.Fuel;
        }

        public int GetFuelCapacity()
        {
            return this.FuelCapacity;
        }

        public int GetCredits()
        {
            return Cargo.GetCredits();
        }

        public double GetYears() => YearsLeft;

        public void ChangeFuelCapacity(int fuelCapacity)
        {
            FuelCapacity = fuelCapacity;
        }

        // argument is positive when buying fuel, negative when traveling.
        public void ChangeFuel(int fuel)
        {
            this.Fuel += fuel;

            // enforces fuel capacity
            if (this.Fuel > this.FuelCapacity)
            {
                this.Fuel = this.FuelCapacity;
            }
        }

        public void ChangeTotalEarned(int v)
        {
            Cargo.ChangeTotalEarned(v);
        }

        internal void ChangeShipName(string shipName)
        {
            ShipName = shipName;
        }

        public int GetTotalEarned()
        {
            return Cargo.GetTotalEarned();
        }



        // travel methods

        public void Travel()
        {
            // prompts user to input warpFactor.
            int warpFactor = WarpSelector();

            Planet destination = PickPlanet(warpFactor);

            // if condition bypasses travel statements if destination is the same as current location.
            if (destination != Location)
            {
                double fuelEfficiency = FuelEfficiencyCalc(warpFactor);
                // dynamically calculates speed based on warpFactor.
                double warpSpeed = Math.Pow(warpFactor, (10.0 / 3.0)) + Math.Pow((10 - warpFactor), (-11.0 / 3.0));

                // Resource burn calculations. Will be used to offer final travel decision to user.
                double fuelReq = Location.DistanceToPlanet(destination) * fuelEfficiency;
                double yearsReq = Location.DistanceToPlanet(destination) / (warpSpeed);

                // User confirmation based on fuel/time required for trip.
                bool decision = ConfirmTravel(yearsReq, fuelReq);

                if (decision == true)
                {
                    // Subtracts fuel based on distance. fuelEfficiency increases (greater fuel reduction) with warpFactor.
                    this.Fuel -= Convert.ToInt32(Math.Floor(Location.DistanceToPlanet(destination) * fuelEfficiency));

                    // Calculation for deducting time off game clock. Deduction increases with warpFactor.
                    this.YearsLeft -= Location.DistanceToPlanet(destination) / (warpSpeed);

                    this.Location = destination;

                    Console.Clear();
                    Console.WriteLine($"Welcome to {destination.PlanetName}.");
                    Console.WriteLine();
                    Console.WriteLine($"         Fuel = {this.Fuel}/{this.FuelCapacity}");
                    Console.WriteLine($"Time traveled = {(40 - YearsLeft).ToString("F2")} years");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        // Selects destination when traveling.
        private Planet PickPlanet(int warpFactor)
        {

            double fuelEfficiency = FuelEfficiencyCalc(warpFactor);
            double warpSpeed = Math.Pow(warpFactor, (10.0 / 3.0)) + Math.Pow((10 - warpFactor), (-11.0 / 3.0));

            // Resource burn calculations. Will be used to determine which locations are displayed for travel.
            double fuelReq1 = Location.DistanceToPlanet(Earth) * fuelEfficiency;
            double yearsReq1 = Location.DistanceToPlanet(Earth) / (warpSpeed);

            double fuelReq2 = Location.DistanceToPlanet(AlphaCentauri) * fuelEfficiency;
            double yearsReq2 = Location.DistanceToPlanet(AlphaCentauri) / (warpSpeed);

            double fuelReq3 = Location.DistanceToPlanet(MysteryPlanet) * fuelEfficiency;
            double yearsReq3 = Location.DistanceToPlanet(MysteryPlanet) / (warpSpeed);

            double fuelReq4 = Location.DistanceToPlanet(ShipGarage) * fuelEfficiency;
            double yearsReq4 = Location.DistanceToPlanet(ShipGarage) / (warpSpeed);

            double fuelReq5 = Location.DistanceToPlanet(PizzaPlanet) * fuelEfficiency;
            double yearsReq5 = Location.DistanceToPlanet(PizzaPlanet) / (warpSpeed);

            double fuelReq6 = Location.DistanceToPlanet(OtherPlanet) * fuelEfficiency;
            double yearsReq6 = Location.DistanceToPlanet(OtherPlanet) / (warpSpeed);

            double fuelReq7 = Location.DistanceToPlanet(OtherPlanet2) * fuelEfficiency;
            double yearsReq7 = Location.DistanceToPlanet(OtherPlanet2) / (warpSpeed);

            double fuelReq8 = Location.DistanceToPlanet(OtherPlanet3) * fuelEfficiency;
            double yearsReq8 = Location.DistanceToPlanet(OtherPlanet3) / (warpSpeed);

            double fuelReq9 = Location.DistanceToPlanet(OtherPlanet4) * fuelEfficiency;
            double yearsReq9 = Location.DistanceToPlanet(OtherPlanet4) / (warpSpeed);


            Console.Clear();
            Console.WriteLine("Where would you like to go?");

            // used to asign a unique value to option cases.
            int optionIndex = 1;

            // each option corresponds to a location.
            int optionCase1 = 0;
            int optionCase2 = 0;
            int optionCase3 = 0;
            int optionCase4 = 0;
            int optionCase5 = 0;
            int optionCase6 = 0;
            int optionCase7 = 0;
            int optionCase8 = 0;
            int optionCase9 = 0;

            // each if statement checks that location is either in range based on current fuel level/years left,
            // and that the requirements do not burn 0 resources (travel to current location). optionIndex then
            // assigns a value (starting at 1) for each case that meets the boolean requirements.
            if (Math.Floor(fuelReq1) < GetFuelLevel() && fuelReq1 != 0)
            {
                Console.WriteLine($"{optionIndex} = {Earth.GetPlanetName()}");
                optionCase1 = optionIndex++;
            }
            if (Math.Floor(fuelReq2) < GetFuelLevel() && fuelReq2 != 0)
            {
                Console.WriteLine($"{optionIndex} = {AlphaCentauri.GetPlanetName()}");
                optionCase2 = optionIndex++;
            }
            if (Math.Floor(fuelReq3) < GetFuelLevel() && fuelReq3 != 0)
            {
                Console.WriteLine($"{optionIndex} = {MysteryPlanet.GetPlanetName()}");
                optionCase3 = optionIndex++;
            }
            if (Math.Floor(fuelReq4) < GetFuelLevel() && fuelReq4 != 0)
            {
                Console.WriteLine($"{optionIndex} = {ShipGarage.GetPlanetName()}");
                optionCase4 = optionIndex++;
            }
            if (Math.Floor(fuelReq5) < GetFuelLevel() && fuelReq5 != 0)
            {
                Console.WriteLine($"{optionIndex} = {PizzaPlanet.GetPlanetName()}");
                optionCase5 = optionIndex++;
            }
            if (Math.Floor(fuelReq6) < GetFuelLevel() && fuelReq6 != 0)
            {
                Console.WriteLine($"{optionIndex} = {OtherPlanet.GetPlanetName()}");
                optionCase6 = optionIndex++;
            }
            if (Math.Floor(fuelReq7) < GetFuelLevel() && fuelReq7 != 0)
            {
                Console.WriteLine($"{optionIndex} = {OtherPlanet2.GetPlanetName()}");
                optionCase7 = optionIndex++;
            }
            if (Math.Floor(fuelReq8) < GetFuelLevel() && fuelReq8 != 0)
            {
                Console.WriteLine($"{optionIndex} = {OtherPlanet3.GetPlanetName()}");
                optionCase8 = optionIndex++;
            }
            if (Math.Floor(fuelReq9) < GetFuelLevel() && fuelReq9 != 0)
            {
                Console.WriteLine($"{optionIndex} = {OtherPlanet4.GetPlanetName()}");
                optionCase9 = optionIndex++;
            }
            Console.WriteLine();

            Planet destination = new Planet();

            try
            {
                int option = int.Parse(Console.ReadLine());

                // if input matches the corresponding optionCase, destination is set to a given planet.
                if (option == optionCase1 && option != 0)
                {
                    destination = Earth;
                }
                else if (option == optionCase2 && option != 0)
                {
                    destination = AlphaCentauri;
                }
                else if (option == optionCase3 && option != 0)
                {
                    destination = MysteryPlanet;
                }
                else if (option == optionCase4 && option != 0)
                {
                    destination = ShipGarage;
                }
                else if (option == optionCase5 && option != 0)
                {
                    destination = PizzaPlanet;
                }
                else if (option == optionCase6 && option != 0)
                {
                    destination = OtherPlanet;
                }
                else if (option == optionCase7 && option != 0)
                {
                    destination = OtherPlanet2;
                }
                else if (option == optionCase8 && option != 0)
                {
                    destination = OtherPlanet3;
                }
                else if (option == optionCase9 && option != 0)
                {
                    destination = OtherPlanet4;
                }
                else
                {
                    Console.WriteLine("You did not pick a valid option.");
                    // if input does not match an option case, the current location is returned. A boolean check in Travel() bypasses remaining travel
                    // functions if destination == Location.
                    destination = Location;
                }
                return destination;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input.");
                // if input does not match an option case, the current location is returned. A boolean check in Travel() bypasses remaining travel
                // functions if destination == Location.
                return Location;
            }
        }

        // Displays travel requirements, user confirms travel.
        private bool ConfirmTravel(double yearsReq, double fuelReq)
        {
            Console.WriteLine($"This trip will leave you with:");
            Console.WriteLine($"          Fuel = {Math.Ceiling((this.Fuel - fuelReq)).ToString("F0")}/{this.FuelCapacity}");
            Console.WriteLine($"Years traveled = {(40 - this.YearsLeft + yearsReq).ToString("F2")} years");
            Console.WriteLine();
            Console.WriteLine("Would you like to proceed?");
            Console.WriteLine("1 = Yes");
            Console.WriteLine("2 = No");
            Console.WriteLine();

            int option = Int32.Parse(Console.ReadLine());

            if (option == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int WarpSelector()
        {
            Console.WriteLine();
            Console.WriteLine("Select your warp speed, Captain.");
            Console.WriteLine("Enter a number 1 - 9.");
            Console.WriteLine();
            try
            {
                int warpFactor = 1;
                warpFactor = int.Parse(Console.ReadLine());
                Console.WriteLine();

                // ensures input is in range and valid.
                if (warpFactor < 1 && warpFactor > 9)
                {
                    Console.Clear();
                    Console.WriteLine("You must enter a valid warp speed.");
                    Console.WriteLine();
                    WarpSelector();
                }

                return warpFactor;
            }
            catch (Exception)
            {
                MainError();
                WarpSelector();
                // TODO is there a way to do this block without returning a value?
                return 1;
            }
        }

        // return value is used to increase fuel required as warpFactor increases.
        private double FuelEfficiencyCalc(int warpFactor)
        {
            double efficiency = Math.Pow(warpFactor, 1.7);
            return efficiency;
        }



        // cargo checks/sets

        public void CheckCargo()
        {
            Cargo.CheckCargo();
        }

        internal int GetCargoCapacity()
        {
            return Cargo.GetCargoCapacity();
        }

        public void ChangeCargoCapacity(int cargoCapacity)
        {
            Cargo.ChangeCargoCapacity(cargoCapacity);
        }

        internal int GetCargoWeight()
        {
            return Cargo.GetCargoWeight();
        }

        internal void ChangeCredits(int purchasePrice)
        {
            Cargo.ChangeCredits(purchasePrice);
        }

        internal void ChangeItem(int itemID, int quantity)
        {
            Cargo.ChangeItem(itemID, quantity);
        }

        internal void ChangeWeight(int weight)
        {
            Cargo.ChangeWeight(weight);
        }

        internal int GetItemQuant(int itemID)
        {
            return Cargo.GetItemQuant(itemID);
        }



        // utility methods

        // used to vary sell prices for items across locations. Modifier is harcoded in MainMenu.SellMenu() and varies between item types.
        public int GetPrice(int modifier)
        {
            return Earth.GetPrice(GetPlanetID() + modifier);
        }

        private void MainError()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Input");
            Console.WriteLine();
        }
    }
}
