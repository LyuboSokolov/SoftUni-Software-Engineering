using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;


        [SetUp]
        public void Setup()
        {
            database = new Database();

        }

        [Test]
        public void When_CreateDatabaseWithEmptyConstructor()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_CreateDatabaseWithExceededConstuctor()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);


            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void When_CreateDatabaseWithConstructorWithElements()
        {
            int[] arr = { 1, 2, 3 };
            database = new Database(arr);
            Assert.That(database.Count, Is.EqualTo(arr.Length));
        }



        [Test]
        public void When_AddElementInFreeSpaceNumber_ShouldBeAddToArray()
        {
            database.Add(3);
            database.Add(4);
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_AddElementNotFreeSpaceInArray_ShouldBeThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void When_RemoveElementEmptyArray_ShouldBeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void When_RemoveElementArray_ShouldBeCounterDecrease()
        {
            database = new Database(1, 2, 3);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_RemoveElementArray_ShouldBeLastElementMissing()
        {
            database = new Database(1, 2, 3);
            database.Remove();
            int[] arr = database.Fetch();

            CollectionAssert.DoesNotContain(arr, 3);
        }

        [Test]
        public void When_FetchCreateCopyArray_ShouldBeCopy()
        {
            database = new Database(1, 2, 3);
            int[] firstCopy = database.Fetch();
            database.Add(4);
            int[] secondCopy = database.Fetch();

            CollectionAssert.AreNotEqual(firstCopy,secondCopy);
        }

    }
}