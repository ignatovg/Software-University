using System;
using NUnit.Framework;
using P01_Database;

namespace Tests
{
    public class DatabaseTests
    {
       // [Test]
        public void ConstructorShouldSaveIntegers()
        {
            int[] expectedArr = new int[] { 1, 2, 0, 0, 0 };

            var database = new Database(new[] { 1, 2 });
            Assert.That(database.Fetch(), Is.EqualTo(expectedArr));

        }

      //  [Test]
        public void ConstructrorShouldTrownExecprion()
        {
            int[] testArr = new int[20];

            Assert.That(() => new Database(testArr), Throws.InvalidOperationException);
        }

       // [Test]
        public void AddMethodShouldAddElement()
        {
            int[] expectedArr = new int[] { 1, 2, 3, 4, 0 };

            var database = new Database(new int[] { 1, 2, 3 });
            database.Add(4);
            Assert.That(database.Fetch(), Is.EqualTo(expectedArr));
        }

        //[Test]
        public void AddMethodShouldTrownException()
        {

            var database = new Database(new int[] { 1, 2, 3, 4 });
            database.Add(4);
            Assert.That(() => database.Add(5), Throws.InvalidOperationException);
        }

       // [Test]
        public void RemoveMethodShouldRemoveLastElement()
        {
            int[] expectedArr = new int[] { 1, 2, 3, 0, 0 };

            var database = new Database(new int[] { 1, 2, 3, 5, 5 });
            database.Remove();
            database.Remove();
            Assert.That(database.Fetch(), Is.EqualTo(expectedArr));
        }

       // [Test]
        public void RemoveMethodShouldRemoveAllElements()
        {
            int[] expectedArr = new int[] { 0, 0, 0, 0, 0 };

            var database = new Database(new int[] { 1, 2, 3, 5, 5 });
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            Assert.That(database.Fetch(), Is.EqualTo(expectedArr));
        }

       // [Test]
        public void RemoveMethodShouldTrownExeption()
        {
            var database = new Database(new int[] { 1, 2, 3, 5, 5 });
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            Assert.That(()=> database.Remove(),Throws.InvalidOperationException);
        }

        //[Test]
       // [TestCase(3)]
       // [TestCase(4)]
       // [TestCase(5)]
        public void AddNumbersInDatabaseIncreaseCount(int number)
        {
            var database = new Database();
            database.Add(number);
            
            Assert.That(database.Fetch(),Is.EqualTo(new int[]{3,0,0,0,0}));
        }

    }
}
