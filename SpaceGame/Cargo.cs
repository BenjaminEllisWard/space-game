using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Cargo
    {
        private int Credits = 1000;
        private int TotalCreditsEarned = 0;

        private int CargoCapacity = 1000;
        private int CargoWeight = 0;

        //itemID = 0 , itemID's used as parameters throughout program
        private int EarthItem = 0;
        //itemID = 1
        private int AcItem = 0;
        //itemID = 2
        private int MpItem = 0;


        public Cargo()
        {
            this.Credits = 100000; //TODO reset to 1000 for actual build
            this.CargoCapacity = 1000;
            this.CargoWeight = 0;
            this.EarthItem = 0;
            this.AcItem = 0;
            this.MpItem = 0;
        }

        public Cargo(int credits, int cargoCapacity, int cargoWeight, int earthItem, int acItem, int mpItem)
        {
            this.Credits = credits;
            this.CargoCapacity = cargoCapacity;
            this.CargoWeight = cargoCapacity;
            this.EarthItem = earthItem;
            this.AcItem = acItem;
            this.MpItem = mpItem;
        }

        public int GetCargoCapacity()
        {
            return this.CargoCapacity;
        }

        public int GetCargoWeight()
        {
            return this.CargoWeight;
        }

        public int GetCredits()
        {
            return this.Credits;
        }

        // if buying, argument is negative int. Positive if selling.
        public void ChangeCredits(int purchasePrice)
        {
            this.Credits += purchasePrice;
        }

        // if buying, argument is positive int. Negative if selling.
        public void ChangeWeight(int weight) 
        {
            this.CargoWeight += weight;
        }

        // if buying, quantity argument is positive int. Negative if selling.
        public void ChangeItem(int itemID, int quantity)
        {
            switch (itemID)
            {
                case 0:
                    this.EarthItem += quantity;
                    break;
                case 1:
                    this.AcItem += quantity;
                    break;
                case 2:
                    this.MpItem += quantity;
                    break;
                default:
                    Console.WriteLine($"Fix this bug: Passed arguments for cargo.ChangeItem(string item, int quantity) were {itemID} and {quantity}.");
                    break;
            }
        }

        public void CheckCargo()
        {
            Console.WriteLine("Cargo Summary:");
            Console.WriteLine();
            Console.WriteLine($"        Cargo Weight: {this.CargoWeight}/{this.CargoCapacity}");
            Console.WriteLine();
            Console.WriteLine($"         Earth Items: {this.EarthItem}");
            Console.WriteLine($"Alpha Centauri Items: {this.AcItem}");
            Console.WriteLine($"Mystery Planet Items: {this.MpItem}");
        }

        public int GetItemQuant(int itemID)
        {
            switch (itemID)
            {
                case 0:
                    return this.EarthItem;
                case 1:
                    return this.AcItem;
                case 2:
                    return this.MpItem;
                    // TODO put a number that does not reference any real itemID just to return something for default case. Check for a better way to do this.
                default:
                    return 999;
            }
        }

        internal void ChangeTotalEarned(int v)
        {
            this.TotalCreditsEarned += v;
        }

        internal void ChangeCargoCapacity(int cargoCapacity)
        {
            CargoCapacity = cargoCapacity;
        }
    }
}
