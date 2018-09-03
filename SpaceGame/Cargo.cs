﻿using System;
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

        //itemID = 0 , itemID's used as parameters throughout project
        private int EarthItem = 0;
        //itemID = 1
        private int AcItem = 0;
        //itemID = 2
        private int MpItem = 0;
        //itemID = 3
        private int Pizza = 0;
        //itemID = 4
        private int Op1Item = 0;
        //itemID = 5
        private int Op2Item = 0;
        //itemID = 6
        private int Op3Item = 0;
        //itemID = 7
        private int Op4Item = 0;



        // constructors
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



        // cargo checks/sets

        public int GetCargoCapacity() => this.CargoCapacity;

        public int GetCargoWeight() => this.CargoWeight;

        public int GetCredits() => this.Credits;

        public int GetTotalEarned() => this.TotalCreditsEarned;

        // if buying, argument is negative int. Positive if selling.
        public void ChangeCredits(int purchasePrice)
        {
            this.Credits += purchasePrice;
        }

        // if buying, argument is negative int. Positive if selling.
        internal void ChangeTotalEarned(int v)
        {
            this.TotalCreditsEarned += v;
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
                case 3:
                    this.Pizza += quantity;
                    break;
                case 4:
                    this.Op1Item += quantity;
                    break;
                case 5:
                    this.Op2Item += quantity;
                    break;
                case 6:
                    this.Op3Item += quantity;
                    break;
                case 7:
                    this.Op4Item += quantity;
                    break;
                default:
                    Console.WriteLine($"Fix this bug: Passed arguments for cargo.ChangeItem(string item, int quantity) were {itemID} and {quantity}.");
                    break;
            }
        }

        public void CheckCargo()
        {
            Console.Clear();
            Console.WriteLine("Cargo Summary:");
            Console.WriteLine();
            Console.WriteLine($"        Cargo Weight: {this.CargoWeight}/{this.CargoCapacity}");
            Console.WriteLine();
            Console.WriteLine($"         Earth Items: {this.EarthItem}");
            Console.WriteLine($"Alpha Centauri Items: {this.AcItem}");
            Console.WriteLine($"Mystery Planet Items: {this.MpItem}");
            Console.WriteLine();
            if (Pizza > 0)
            {
            Console.WriteLine($"               Pizza: {this.Pizza}");
            }
            if (Op1Item > 0)
            {
            Console.WriteLine($"             Op1Item: {this.Op1Item}");
            }
            if (Op2Item > 0)
            {
            Console.WriteLine($"             Op2Item: {this.Op2Item}");
            }
            if (Op3Item > 0)
            {
                Console.WriteLine($"             Op3Item: {this.Op3Item}");
            }
            if (Op4Item > 0)
            {
                Console.WriteLine($"             Op4Item: {this.Op4Item}");
            }
            Console.WriteLine();
            
        }

        // used to ensure adequate quantity exists before selling. See MainMenu.SellItem().
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
                case 3:
                    return this.Pizza;
                case 4:
                    return this.Op1Item;
                case 5:
                    return this.Op2Item;
                case 6:
                    return this.Op3Item;
                case 7:
                    return this.Op4Item;
                // TODO put a number that does not reference any real itemID just to return something for default case. Check for a better way to do this.
                default:
                    return 999;
            }
        }

        internal void ChangeCargoCapacity(int cargoCapacity)
        {
            CargoCapacity = cargoCapacity;
        }
    }
}
