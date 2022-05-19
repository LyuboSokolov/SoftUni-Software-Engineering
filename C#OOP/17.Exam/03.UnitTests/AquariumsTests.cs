namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("OOP", 25);
        }

        [Test]
        public void NameNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(null, 25));
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(string.Empty, 25));
        }

        [Test]
        public void NameValid()
        {
            Assert.That(aquarium.Name, Is.EqualTo("OOP"));
        }

        [Test]
        public void When_CapacityIsLessThenZero()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Gogi", -1));
        }

        [Test]
        public void When_CapacityIsValid()
        {
            Assert.That(aquarium.Capacity, Is.EqualTo(25));
        }

        [Test]
        public void WhenCapacityIsFull()
        {
            aquarium = new Aquarium("Gogi", 1);
            aquarium.Add(new Fish("fish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Gogiriba")));
        }

        [Test]
        public void WhenCapacityHaveMoreSpace()
        {

            aquarium.Add(new Fish("fish"));

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenRemoveMissingFish()
        {

            aquarium.Add(new Fish("fish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("pepi"));
        }

        [Test]
        public void WhenRemoveValidFish()
        {

            aquarium.Add(new Fish("fish"));
            aquarium.RemoveFish("fish");
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void WhenSellFishInvalidNameFish()
        {

            aquarium.Add(new Fish("fish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("pepi"));
        }

        [Test]
        public void WhenSellFishIsValidNameFish()
        {


            Fish fish = new Fish("Gogi");
            aquarium.Add(fish);
            aquarium.SellFish("Gogi");
            Assert.That(fish.Available, Is.False);
        }

        [Test]
        public void WhenSellFishIsValidNameFishs()
        {


            Fish fish = new Fish("Gogi");
            aquarium.Add(fish);

            Assert.That(aquarium.SellFish("Gogi"), Is.EqualTo(fish));
        }

        [Test]
        public void WhenReport()
        {
            Fish firstFish = new Fish("Gogi");
            Fish secondFish = new Fish("Dimitricho");
            List<Fish> fishes = new List<Fish>();
            fishes.Add(firstFish);
            fishes.Add(secondFish);
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);

            string fishNames = string.Join(", ", fishes.Select(f => f.Name));
            string report = $"Fish available at {aquarium.Name}: {fishNames}";

            Assert.That(aquarium.Report,Is.EqualTo(report));
        }


    }
}
