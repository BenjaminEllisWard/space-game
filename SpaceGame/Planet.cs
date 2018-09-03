using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Planet
    {
        double xCoord;
        double yCoord;
        //TODO figure out why PlanetName, ItemID, and PlanetID have to be public.
        public string PlanetName;
        public int ItemID = 0;
        public int PlanetID = 1;
                                       //  0    1    2    3    4    5    6    7    8    9    10   11
        private int[] Price = new int[] { 325, 150, 400, 300, 150, 475, 150, 600, 475, 150, 600, 475 };    // used with PlanetID to enforce unique economies



        // constructors

        public Planet()
        {
            xCoord = 0;
            yCoord = 0;
            PlanetName = "Earth";
            ItemID = 0;
            PlanetID = 1;
        }

        public Planet(double xCoord, double yCoord, string planetName, int itemID, int planetID)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.PlanetName = planetName;
            this.ItemID = itemID;
            this.PlanetID = planetID;
        }



        // utility methods

        public string GetPlanetName()
        {
            return this.PlanetName;
        }

        // calculates distance to be used when traveling.
        public double DistanceToPlanet(Planet otherPlanet)
        {
            double xDiff = this.xCoord - otherPlanet.xCoord;
            double yDiff = this.yCoord - otherPlanet.yCoord;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            return distance;
        }

        // used by ship class to return current location name.
        public static Planet Earth()
        {
            return new Planet(0, 0, "Earth", 0, 1);
        }

        public int GetPrice(int index)
        {
            return Price[index];
        }
    }
}
