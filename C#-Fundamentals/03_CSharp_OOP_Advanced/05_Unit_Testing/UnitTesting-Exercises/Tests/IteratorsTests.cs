using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IteratorsTests
    {
        [Test]
        [TestCase(new int[]{1,2,34})]
        [TestCase(new int[]{1})]
        [TestCase(new int[]{0})]
        [TestCase(new int[]{-1,-3,-4})]
        public void TestCreateValid(int[] values)
        {
            var expectedList = values;

            var listIterator = new ListyIterator<int>();
            listIterator.Create(expectedList);

            FieldInfo fieldInfo = typeof(ListyIterator<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(IReadOnlyList<int>));

            var actualList = (IReadOnlyList<int>)fieldInfo.GetValue(listIterator);

            Assert.That(actualList, Is.EquivalentTo(expectedList));
        }

        [Test]
        public void MoveMethodShouldMoveIndexWith1()
        {
            
            ListyIterator<int> listyIterator = new ListyIterator<int>();
            listyIterator.Create(1,2,3,4,5);

            FieldInfo currentindexInfo = typeof(ListyIterator<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));

                currentindexInfo.SetValue(listyIterator,0);

            listyIterator.Move();

            int index = (int) currentindexInfo.GetValue(listyIterator);
            
            Assert.That(index,Is.EqualTo(1));
            
        }

        [Test]
        public void MoveMethodShouldReturnFalse()
        {

            var listIterator = new  ListyIterator<int>();
            listIterator.Create(1,2,3,4,5);

            FieldInfo currentIndexInfo = typeof(ListyIterator<int>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));
            currentIndexInfo.SetValue(listIterator,5);

            
            Assert.That(listIterator.Move,Is.False);
        }

        [Test]
        public void PrintMethodShouldPrintCollection()
        {
            ListyIterator<int> listyIterator = new ListyIterator<int>();

            FieldInfo fieldInfo = typeof(ListyIterator<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(IReadOnlyList<int>));

            fieldInfo.SetValue(listyIterator,new List<int>{1,2,3});

            var actualCollection = (IReadOnlyList<int>)fieldInfo.GetValue(listyIterator);

            listyIterator.Print();
        }

        [Test]
        public void PrintMethodShouldThrownException()
        {
            ListyIterator<int> listyIterator = new ListyIterator<int>();

            FieldInfo fieldInfo = typeof(ListyIterator<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(IReadOnlyList<int>));

            fieldInfo.SetValue(listyIterator, new List<int> { });

            var actualCollection = (IReadOnlyList<int>)fieldInfo.GetValue(listyIterator);

           Assert.That(()=> listyIterator.Print(),Throws.InvalidOperationException); 
        }
    }
}
