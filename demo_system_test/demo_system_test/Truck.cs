using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test
{
    public class Truck : ICar
    {
        public string GetNoOfDoors()
        {
            return "2";
        }

        public string GetNoOfWheels()
        {
            return "4";
        }
    }
}
