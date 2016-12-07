using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test
{
    public class Car
    {
        private int noOfWheels;
        private int noOfDoors;

        public Car()
        {
            this.noOfWheels = 4;
            this.noOfDoors = 4;
        }

        public string GetNoOfWheels()
        {
            return "I have " + noOfWheels;
        }

        public string GetNoOfDoors()
        {
            return "I have " + noOfDoors;
        }
    }
}
