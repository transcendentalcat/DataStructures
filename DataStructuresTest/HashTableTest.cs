using System;
using System.Collections.Generic;
using System.Data;
using DataStructures.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable = new HashTable(10);

        [TestInitialize]
        public void CreateTestHashTable()
        {
            hashTable = new HashTable(10);
            hashTable.Add("1", "testString1");
        }

        [TestMethod]
        public void Add_ShouldContainAddedItem()
        {
            var key = "2";
            var item = "testString2";
            hashTable.Add(key, item);

            Assert.IsTrue(hashTable.Contains(key));
            Assert.AreEqual(item, hashTable[key]);
            Assert.AreEqual(2, hashTable.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void Add_AddValueByAnExistingKey_DuplicateNameException()
        {
            hashTable.Add("1", "newValue");
        }

        [TestMethod]
        public void Indexator_Get_GetElementByExistingKey_ReturnValue()
        {
            var expectedValue = "testString1";
            var resultValue = hashTable["1"];
            Assert.AreEqual(expectedValue, resultValue);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Indexator_Get_GetElementByNotExistingKey_KeyNotFoundException()
        {
            var value = hashTable["3"];
        }

        [TestMethod]
        public void Indexator_Set_SetNullValue_RemoveValue()
        {
            hashTable["1"] = null;
            Assert.IsFalse(hashTable.Contains("1"));
            Assert.AreEqual(0, hashTable.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void Indexator_Set_SetValueByAnExistingKey_DuplicateNameException()
        {
            hashTable["1"] = "newValue";
        }

        [TestMethod]
        public void Indexator_Set_SetValueByNotExistingKey_ShouldContainNewKeyValuePair()
        {
            var key = "2";
            var item = "testString2";
            hashTable[key] = item;

            Assert.IsTrue(hashTable.Contains(key));
            Assert.AreEqual(item, hashTable[key]);
            Assert.AreEqual(2, hashTable.Size);
        }

        [TestMethod]
        public void Contains_GetExistingKey_ReturnTrue()
        {
            Assert.IsTrue(hashTable.Contains("1"));
        }

        [TestMethod]
        public void Contains_GetNotExistingKey_ReturnFalse()
        {
            Assert.IsFalse(hashTable.Contains("2"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TryGet_GetElementByNotExistingKey_KeyNotFoundException()
        {
            object result;
            hashTable.TryGet("3", out result);
        }

        [TestMethod]
        public void TryGet_GetElementByExistingKey_SetOutParameterAsValueReturnTrue()
        {
            object value;
            var result = hashTable.TryGet("1", out value);
            Assert.IsTrue(result);
            Assert.AreEqual(value, hashTable["1"]);
        }

        [TestMethod]
        public void Remove_RemoveValue()
        {
            Assert.IsTrue(hashTable.Contains("1"));
            hashTable.Remove("1");
            Assert.IsFalse(hashTable.Contains("1"));
            Assert.AreEqual(0, hashTable.Size);
        }
    }
}
