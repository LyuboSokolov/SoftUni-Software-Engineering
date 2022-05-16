using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver unitDriver;
        private UnitCar unitCar;
        

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            unitCar = new UnitCar("Alfa", 150, 2000);
            unitDriver = new UnitDriver("Pesho", unitCar);

        }

        [Test]
        public void AddNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }


        [Test]
        public void AddExistDriver()
        {
            raceEntry.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.AddDriver(new  UnitDriver("Pesho",new UnitCar("ad",123,123))));
        }

        [Test]
        public void AddValidDriver()
        {
            raceEntry.AddDriver(unitDriver);

            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void CalculateAverageHorsePowerWithCountLessThenMinimum()
        {
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }


        [Test]
        public void CalculateAverageHorsePowerWithCorrectData()
        {
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(new UnitDriver("asdas", new UnitCar("Asd", 250, 2500)));
            double average = (unitCar.HorsePower + 250) / 2;

            Assert.That(raceEntry.CalculateAverageHorsePower, Is.EqualTo(average));
        }


    }
}