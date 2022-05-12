
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;


        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }
        [Test]
        public void CtorInitializeWarriars()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void CountIsZero_WhenArenaIsEmpty()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_EnrolledWarriorWhoIsAlreadyEnrolled_ShouldBeThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 20, 35);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Pesho",34,13)));
        }

        [Test]
        public void When_EnrolledWarriorWd_ShouldBeCountIncrease()
        {
            Warrior warrior = new Warrior("Pesho", 20, 35);
            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Pesho";
            Warrior warrior = new Warrior(name, 20, 35);
            arena.Enroll(warrior);

            Assert.That(arena.Warriors.Any(p => p.Name == name), Is.True);
        }

        [Test]
        public void When_FightFirstOrSecondWarriorIsMissingName()
        {
            Warrior firstWarrior = new Warrior("Pesho",3,4);
            Warrior secondWarrior = new Warrior("Gogi",3,4);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho","asdas"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("sda","Pesho"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("sda","adssa"));
        }
        [Test]
        public void When_FightFirstOrSecondWarriorIsAInvalidData()
        {
            int initializeHp = 100;
            Warrior firstWarrior = new Warrior("Pesho", 50, initializeHp);
            Warrior secondWarrior = new Warrior("Gogi", 50, initializeHp);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            arena.Fight("Pesho", "Gogi");

            Assert.That(firstWarrior.HP, Is.EqualTo(initializeHp - secondWarrior.Damage));
            Assert.That(secondWarrior.HP, Is.EqualTo(initializeHp - firstWarrior.Damage));
        }
    }

}
