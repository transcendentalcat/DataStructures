using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<string> testList;

        [TestInitialize]
        public void CreateTestList()
        {
            testList = new LinkedList<string>(){ "firstTestString", "secondTestString" };           
        }

        [TestMethod]
        public void Add_AddItemToTheTailAndIncreaseLength()
        {
            var emptyTestList = new LinkedList<string>();
            var item = "testString";
            testList.Add(item);
            emptyTestList.Add(item);

            Assert.AreEqual(3, testList.Length);
            Assert.AreEqual(item, testList.ElementAt(2));
            Assert.AreEqual(1, emptyTestList.Length);
            Assert.AreEqual(item, emptyTestList.ElementAt(0));
        }

        [TestMethod]
        public void Remove_GetsExistingItem_DecreaseLengthAndRemoveItem()
        {
            testList.Remove("secondTestString");

            Assert.AreEqual(1, testList.Length);
            Assert.AreEqual("firstTestString", testList.ElementAt(0));
        }

        [TestMethod]
        public void Remove_GetsMissingItem_ListDoesNotChange()
        {
            testList.Remove("seventhTestString");
            Assert.AreEqual(2, testList.Length);
            Assert.AreEqual("firstTestString", testList.ElementAt(0));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAt_IndexGreaterThanListLength_IndexOutOfRangeException()
        {
            testList.AddAt("thirdTestString", 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddAt_IndexLessThanZero_IndexOutOfRangeException()
        {
            testList.AddAt("thirdTestString", -1);
        }

        [TestMethod]
        public void AddAt_IndexZero_AddItemAtTheBegining()
        {
            testList.AddAt("thirdTestString", 0);
            Assert.AreEqual("thirdTestString", testList.ElementAt(0));
            Assert.AreEqual("firstTestString", testList.ElementAt(1));
            Assert.AreEqual("secondTestString", testList.ElementAt(2));
        }

        [TestMethod]
        public void AddAt_ValidIndex_AddItemAtSpecifiedPosition()
        {
            var item = "thirdTestString";

            testList.AddAt(item, 1);

            Assert.AreEqual(3, testList.Length);
            Assert.AreEqual(item, testList.ElementAt(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAt_IndexGreaterThanListLength_IndexOutOfRangeException()
        {
            testList.RemoveAt(3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAt_IndexLessThanZero_IndexOutOfRangeException()
        {
            testList.RemoveAt(-1);
        }

        [TestMethod]
        public void RemoveAt_IndexZero_RemoveFirstElement()
        {
            testList.Add("thirdTestString");
            testList.RemoveAt(0);

            Assert.AreEqual(2, testList.Length);
            Assert.AreEqual("secondTestString", testList.ElementAt(0));
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_RemoveItemAtSpecifiedPosition()
        {
            testList.Add("thirdTestString");
            testList.RemoveAt(1);

            Assert.AreEqual(2, testList.Length);
            Assert.AreEqual("thirdTestString", testList.ElementAt(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ElementAt_IndexGreaterThanListLength_IndexOutOfRangeException()
        {
            var element = testList.ElementAt(2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ElementAt_IndexLessThanZero_IndexOutOfRangeException()
        {
            var element = testList.ElementAt(-1);
        }

        [TestMethod]
        public void ElementAt_IndexZero_ReturnFirstItem()
        {
            var firstElement = testList.ElementAt(0);

            Assert.AreEqual("firstTestString", firstElement);
        }

        [TestMethod]
        public void ElementAt_ValidIndex_ReturnItemAtSpecifiedPossition()
        {
            testList.Add("thirdTestString");
            var secondElement = testList.ElementAt(2);

            Assert.AreEqual("thirdTestString", secondElement);
        }

        [TestMethod]
        public void GetEnumerator_foreachLoopGoesThroughTheElementsOfTheList()
        {
            var expectedList = new System.Collections.Generic.List<int> { 1, 2, 3, 4 };
            var testList2 = new LinkedList<int>();
            testList2.Add(1);
            testList2.Add(2);
            testList2.Add(3);
            testList2.Add(4);
            var result = new System.Collections.Generic.List<int>();
            foreach (var item in testList2)
            {
                result.Add(item);
            }

            CollectionAssert.AreEqual(expectedList, result);
        }
    }
}
