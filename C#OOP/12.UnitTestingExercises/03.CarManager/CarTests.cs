using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Alfa", "159", 8, 70);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_CreatCarWithNullOrEmptyMake_ShouldBeThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, "159", 12, 50));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_CreatCarWithNullOrEmptyModel_ShouldBeThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Alfa", model, 12, 50));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void When_CreatCarWithZeroOrNegativeFuelConsumption_ShouldBeThrowException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Alfa", "159", fuelConsumption, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void When_CreatCarWithZeroOrNegativeFuelCapacity_ShouldBeThrowException(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Alfa", "159", 8, fuelCapacity));
        }

        [Test]
        public void CtorCreatCar()
        {
            Assert.That(car.Make, Is.EqualTo("Alfa"));
            Assert.That(car.Model, Is.EqualTo("159"));
            Assert.That(car.FuelConsumption, Is.EqualTo(8));
            Assert.That(car.FuelCapacity, Is.EqualTo(70));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-7)]
        public void When_RefuelCarWithZeroOrNegativeFuel_ShouldBeThrowException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void When_RefuelCarFuelAmount_ShouldBeIncrease()
        {
            double fuel = 25;
            car.Refuel(fuel);

            Assert.That(car.FuelAmount, Is.EqualTo(fuel));
        }

        [Test]
        public void When_RefuelCarWithFuelGreadenByFuelCapacity()
        {
            double fuel = 75;
            car.Refuel(fuel);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void When_FuelNeedGreathenFuelAmount_ShouldBeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(15555));
        }

        [Test]
        public void When_CarDriveFuelAmaunt_ShouldBeDecrease()
        {
            car.Refuel(50);
            double distance = 140;
            double fuelNeeded = (distance / 100.00) * car.FuelConsumption;
            double carFuelAmount = car.FuelAmount;
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(carFuelAmount - fuelNeeded));
        }
    }
}