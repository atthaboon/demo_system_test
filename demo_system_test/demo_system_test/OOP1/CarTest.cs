using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test
{
    [TestFixture]
    public class CarTest
    {
        [Test]
        public void Car_GetWheel_returnSSSS()
        {
            var car1 = new Car();

            var acutualWheels = car1.GetNoOfWheels();

            Assert.AreEqual("I have 4", acutualWheels);
        }

        [Test]
        public void Truck_GetWheel_returnSSSS()
        {
            ICar truck1 = new Truck();

            var acutualWheels = truck1.GetNoOfWheels();

            Assert.AreEqual("4", acutualWheels);
        }
    }
}
