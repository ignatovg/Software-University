using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using NUnit.Framework;
using P01_BojoDatabase;

namespace Tests
{
    [TestFixture]
    public class BojoDatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 4 })]
        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { })]

        public void TestValidContructor(int[] values)
        {

            object db = new Database(values);

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));

            IEnumerable<int> fieldValuues = ((int[])fieldInfo.GetValue(db)).Take(values.Length);


            Assert.That(fieldValuues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] values = new int[17];

            Assert.That(() => new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(-12)]
        [TestCase(500)]
        [TestCase(2)]

        public void TestAddMethodValid(int value)
        {
            Database db = new Database();

            db.Add(value);

            FieldInfo valuesInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int[]));
            FieldInfo currentIndexInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));

            int firstValue = ((int[])valuesInfo.GetValue(db)).First();
            Assert.That(firstValue, Is.EqualTo(value));

            int valuesCount = (int)currentIndexInfo.GetValue(db);
            Assert.That(valuesCount, Is.EqualTo(1));

        }

        public void TestAddMethodInvalid()
        {
            Database db = new Database();

            FieldInfo currentIndexInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));

            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { -1 })]
        public void TestRemoveMethodValid(int[] vaulues)
        {
            Database db = new Database();

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));

            fieldInfo.SetValue(db, vaulues);

            FieldInfo currentIndexInfo = typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));

            currentIndexInfo.SetValue(db, vaulues.Length);

            db.Remove();

            int[] actualValues = (int[])fieldInfo.GetValue(db);
            int[] buffer = new int[actualValues.Length - vaulues.Length - 1];

            vaulues = vaulues.Take(vaulues.Length - 1).Concat(buffer).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(vaulues));

        }
    }
}
