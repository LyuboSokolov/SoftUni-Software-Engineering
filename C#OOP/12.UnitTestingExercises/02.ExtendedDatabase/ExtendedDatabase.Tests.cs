using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            person = new Person(12345, "Pesho");
            database = new ExtendedDatabase(person);
        }

        [Test]
        public void When_CreateDatabaseWithOnePerson()
        {
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_CreateDatabaseWithExceededPerson()
        {
            Person[] persons = new Person[17];
            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(persons));
        }

        [Test]
        public void When_CreateDatabaseWithThreePersons()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"{i}");
            }
            database = new ExtendedDatabase(persons);
            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void When_AddPersonExceededDatabase_ShouldBeThrowException()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"{i}");
            }
            database = new ExtendedDatabase(persons);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(123, "Gogi")));
        }

        [Test]
        public void When_AddPersonWithSameName_ShouldBeThrowException()
        {
            Person firstPerson = new Person(123, "Gogi");
            Person secondPerson = new Person(1234, "Gogi");
            database.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));
        }
        [Test]
        public void When_AddPersonWithSameId_ShouldBeThrowException()
        {
            Person firstPerson = new Person(123, "Peshoo");
            Person secondPerson = new Person(123, "Gogi");
            database.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));
        }
        [Test]
        public void When_AddPersonCounter_ShouldBeIncrease()
        {
            person = new Person(1234, "Dimitricho");
            database.Add(person);

            Assert.That(database.Count, Is.EqualTo(2));
        }
        [Test]
        public void When_RemovePersonEmptyDatabase_ShouldBeThrowExceptio()
        {
            database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void When_RemovePersonDatabase_ShoudBeCounterDecre()
        {
            database = new ExtendedDatabase(new Person(123, "Yori"), new Person(23, "Gogi"));
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByEmptyUserName_ShouldBeThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }

        [Test]
        public void When_FindByMissingUserName_ShouldBeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Dimitrichko"));
        }

        [Test]
        public void When_FindByUserName_ShouldBeReturnPerson()
        {
            Person firstPerson = new Person(123, "Gogi");
            Person secondPerson = new Person(23, "Maxi");
            database.Add(firstPerson);
            database.Add(secondPerson);
            Assert.That(database.FindByUsername("Maxi") == secondPerson);
        }

        [Test]
        public void When_FindByNegativeId_ShoudBeThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void When_FindByMissingId_ShouldBeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(00));
        }

        [Test]
        public void When_FindById_ShouldBeReturnPerson()
        {
            Person secondPerson = new Person(23, "Maxi");
            database.Add(secondPerson);

            Assert.That(database.FindById(23) == secondPerson);
        }
    }
}