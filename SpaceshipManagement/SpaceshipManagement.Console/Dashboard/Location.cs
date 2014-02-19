using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceshipManagement.Console.Dashboard
{
    public class Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool ExactlyEqual(Location newLocation)
        {
            return newLocation.X == this.X && newLocation.Y == this.Y;
        }
    }
}
