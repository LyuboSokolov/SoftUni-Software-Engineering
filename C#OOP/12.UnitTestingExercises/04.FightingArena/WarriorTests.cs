
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior firstWarrior;

        [SetUp]
        public void Setup()
        {
            firstWarrior = new Warrior("Pesho", 20, 100);
        }

        [Test]
        [TestCase("", 20, 100)]
        [TestCase(null, 20, 100)]
        [TestCase("   ", 20, 100)]
        [TestCase("Pesho", 0, 100)]
        [TestCase("Pesho", -20, 100)]
        [TestCase("Pesho", 20, -5)]
        public void CtorCreatWarrior_WhenWarriorDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => firstWarrior = new Warrior(name, damage, hp));
        }

        [Test]
        public void CtorCreateWarrior_WhenDataIsValid()
        {
            string name = "Pesho";
            int damage = 2;
            int hp = 50;
            firstWarrior = new Warrior(name, damage, hp);

            Assert.That(firstWarrior.Name, Is.EqualTo(name));
            Assert.That(firstWarrior.Damage, Is.EqualTo(damage));
            Assert.That(firstWarrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void When_WarriorHpLessThenMinAttackHp_ThrowException(int hp)
        {
            firstWarrior = new Warrior("Pesho", 20, hp);
            Warrior secondWarrior = new Warrior("Gogi", 25, 250);
            Assert.Throws<InvalidOperationException>(() => firstWarrior.Attack(secondWarrior));

        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void When_SecondWarriorHpLessThenMinAttackHp_ThrowException(int hp)
        {
            firstWarrior = new Warrior("Pesho", 20, 100);
            Warrior secondWarrior = new Warrior("Gogi", 25, hp);
            Assert.Throws<InvalidOperationException>(() => firstWarrior.Attack(secondWarrior));

        }

        [Test]
        public void When_WarriorHpLessThenDamageSecondWarrior_ThrowException()
        {
            firstWarrior = new Warrior("Pesho", 20, 100);
            Warrior secondWarrior = new Warrior("Gogi", 101, 25);
            Assert.Throws<InvalidOperationException>(() => firstWarrior.Attack(secondWarrior));

        }

        [Test]
        public void When_SecondWarriorAttackFirstWarrior_FirstWarriorHp_ShouldBedecrease()
        {
            firstWarrior = new Warrior("Pesho", 20, 100);
            Warrior secondWarrior = new Warrior("Gogi", 20, 150);
            int firstWarriorHp = firstWarrior.HP - secondWarrior.Damage;
            firstWarrior.Attack(secondWarrior);

            Assert.That(firstWarrior.HP, Is.EqualTo(firstWarriorHp));
        }


        [Test]
        public void When_FirsdWarriorAttackSecondWarrior_SecondWarriorHp_ShouldBeEqualToZero()
        {
            firstWarrior = new Warrior("Pesho", 160, 100);
            Warrior secondWarrior = new Warrior("Gogi", 20, 150);
            firstWarrior.Attack(secondWarrior);

            Assert.That(secondWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void When_FirsdWarriorAttackSecondWarrior_SecondWarriorHp_ShouldBeDecrease()
        {
            firstWarrior = new Warrior("Pesho", 100, 100);
            Warrior secondWarrior = new Warrior("Gogi", 20, 150);
            int secondWarriorHp = secondWarrior.HP - firstWarrior.Damage;
            firstWarrior.Attack(secondWarrior);

            Assert.That(secondWarrior.HP, Is.EqualTo(secondWarriorHp));
        }

    }
}