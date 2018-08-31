using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Ship
    {
        // TODO CargoCapacity field exists for both Ship and Cargo classes. Trading calculations use Cargo's, but capacity will need
        // to change depending on ship upgrade in the future. Figure out how this is going to work or remove Ship.CargoCapacity.
        public int CargoCapacity = 1000;
        public int Fuel = 1000;
        public int FuelCapacity = 1000;
        public string ShipName = "Your Starter Ship";
        public Planet Location = Planet.Earth();

        public Ship()
        {
            CargoCapacity = 1000;
            FuelCapacity = 1000;
            ShipName = "Your Starter Ship";
        }

        public Ship(int cargoCapacity, int fuelCapacity, string shipName, Planet location)
        {
            this.CargoCapacity = cargoCapacity;
            this.FuelCapacity = fuelCapacity;
            this.ShipName = shipName;
            this.Location = Planet.Earth();
        }

        public void Travel(Planet destination)
        {
            // Calculates distance to destination and substracts one fuel per distance unit.
            // Will incorporate a fuel efficiency modifier (value changes on speed) in future commit.
            this.Fuel -= Convert.ToInt32(Location.DistanceToPlanet(destination));

            this.Location = destination;
            Console.WriteLine($"Welcome to {destination.PlanetName}.");
        }

        public string GetLocation()
        {
            return Location.PlanetName;
        }

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

        public static Ship GetMyShip()
        {
            return new Ship(0, 0, "Your Starter Ship", Planet.Earth());
        }
    }
}
