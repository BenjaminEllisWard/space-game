using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Cargo
    {
        private int Credits = 1000;
        private int TotalCreditsEarned = 0;

        private int CargoCapacity = 1000;
        private int CargoWeight = 0;

        private int EarthItem = 0; //itemID = 0 , itemID's used as parameters throughout program
        private int AcItem = 0;    //itemID = 1
        private int MpItem = 0;    //itemID = 2


        public Cargo()
        {
            this.Credits = 1000;
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
        public void ChangeCredits(int purchasePrice) // if buying, argument is negative int. Positive if selling.
        {
            this.Credits += purchasePrice;
        }
        public void ChangeWeight(int weight) // if buying, argument is positive int. Negative if selling.
        {
            this.CargoWeight += weight;
        }
        public void ChangeItem(int itemID, int quantity) // if buying, quantity argument is positive int. Negative if selling.
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
                default:
                    return 999;
            }
        }

        internal void ChangeTotalEarned(int v)
        {
            this.TotalCreditsEarned += v;
        }
    }
}
