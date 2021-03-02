using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceTrack.Models;
using System;

namespace RaceTrackTest
{
    [TestClass]
    public class UnitTest1
    {
        Truck truck;
        Car car;

        [TestMethod]
        public void WhenTruckHasNoStrapAndLiftedMoreThanFiveInchesInspectionFails()
        {
            //arrange
            truck = new Truck
            {
                TowStrap = false,
                LiftHeight = 6
            };

            //act
            var allowed = truck.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenTruckHasNoStrapAndLiftedLessThanOrEqualToFiveInchesInspectionFails()
        {
            //arrange
            truck = new Truck
            {
                TowStrap = false,
                LiftHeight = 4
            };

            //act
            var allowed = truck.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenTruckHasStrapAndLiftedLessThanOrEqualToFiveInchesInspectionPasses()
        {
            //arrange
            truck = new Truck
            {
                TowStrap = true,
                LiftHeight = 4
            };

            //act
            var allowed = truck.AllowOnTrack(0);

            //assert
            Assert.IsTrue(allowed);
        }

        [TestMethod]
        public void WhenTruckInspectionPassesButTrackCountReachedLimit()
        {
            //arrange
            truck = new Truck
            {
                TowStrap = true,
                LiftHeight = 4
            };

            //act
            var allowed = truck.AllowOnTrack(5);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenTruckHasStrapAndLiftedMoreThanFiveInchesInspectionFails()
        {
            //arrange
            truck = new Truck
            {
                TowStrap = true,
                LiftHeight = 6
            };

            //act
            var allowed = truck.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenCarHasNoStrapAndTireWearMoreThanEightyFivePercentInspectionFails()
        {
            //arrange
            car = new Car
            {
                TowStrap = false,
                TireWear = 86
            };

            //act
            var allowed = car.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenCarHasNoStrapAndTireWearLessThanEightyFivePercentInspectionFails()
        {
            //arrange
            car = new Car
            {
                TowStrap = false,
                TireWear = 84
            };

            //act
            var allowed = car.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenCarHasStrapAndTireWearMoreThanEightyFivePercentInspectionFails()
        {
            //arrange
            car = new Car
            {
                TowStrap = true,
                TireWear = 86
            };

            //act
            var allowed = car.AllowOnTrack(0);

            //assert
            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void WhenCarHasStrapAndTireWearLessThanEightyFivePercentInspectionPasses()
        {
            //arrange
            car = new Car
            {
                TowStrap = true,
                TireWear = 84
            };

            //act
            var allowed = car.AllowOnTrack(0);

            //assert
            Assert.IsTrue(allowed);
        }

        [TestMethod]
        public void WhenCarInspectionPassesButTrackCountReachedLimit()
        {
            //arrange
            car = new Car
            {
                TowStrap = true,
                TireWear = 84
            };

            //act
            var allowed = car.AllowOnTrack(5);

            //assert
            Assert.IsFalse(allowed);
        }
    }
}
