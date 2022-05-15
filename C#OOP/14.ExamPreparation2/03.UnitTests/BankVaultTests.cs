using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankValut;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "123");
        }

        [Test]
        public void When_AddItemWithMissingCell_ShouldBeException()
        {
            Assert.Throws<ArgumentException>(() => bankValut.AddItem("missingCell", item));
        }

        [Test]
        public void When_AddItemInAlreadyTakenCell_ShouldBeException()
        {
            bankValut.AddItem("A2",item);
            Assert.Throws<ArgumentException>(() => bankValut.AddItem("A2", new Item("Gogi", "55555")));
        }

        [Test]
        public void When_AddItemWithSameId_ShoulBeException()
        {
            bankValut.AddItem("A1", new Item("Gogi", "55555"));
            bankValut.AddItem("A4", item);

            Assert.Throws<InvalidOperationException>(() => bankValut.AddItem("A3", new Item("Pesho", "55555")));
        }

        [Test]
        public void When_AddItemWithCorrectData_ShouldBeOneItemNotNull()
        {
           bankValut.AddItem("A1", item);

            Assert.That(bankValut.VaultCells["A1"], Is.Not.EqualTo(null));
        }

        [Test]
        public void When_RemoveItemWithMissingCell_ShouldBeException()
        {
            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem("missingCell", item));
        }

        [Test]
        public void When_RemoveItemButItemInCellIsDefferent_ShouldBeException()
        {
            bankValut.AddItem("A1", new Item("Gogi", "55555"));

            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem("A1", item));
        }

        [Test]
        public void When_RemoveItemWithCorrectData()
        {
            bankValut.AddItem("A1", item);
            Item insertItem = bankValut.VaultCells["A1"];

            bankValut.RemoveItem("A1", item);

            Assert.That(bankValut.VaultCells["A1"], Is.Not.EqualTo(insertItem));
        }
    }

}