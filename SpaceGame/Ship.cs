using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Ship
    {
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

        public void ChangeFuel(int fuel) // argument is positive when buying fuel, negative when traveling.
        {
            this.Fuel += fuel;

            if (this.Fuel > this.FuelCapacity)  // enforces fuel capacity
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
