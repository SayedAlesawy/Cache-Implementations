using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Tests
{
    [TestClass()]
    public class LRUCacheTests
    {
        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Test1()
        {
            int Capacity = 2;

            LRUCache<int, int> Cache = new LRUCache<int, int>(Capacity);
            int ret = 0;

            Cache.Put(1, 1);
            Cache.Put(2, 2);

            ret = Cache.Get(1); //returns 1
            Assert.AreEqual(ret, 1);

            Cache.Put(3, 3); //evicts key 2

            ret = Cache.Get(2); //returns (not found)

            Cache.Put(4, 4); //evicts key 1

            ret = Cache.Get(1); //returns (not found)

            ret = Cache.Get(3); //returns 3
            Assert.AreEqual(ret, 3);

            ret = Cache.Get(4); //returns 4
            Assert.AreEqual(ret, 4);
        }

        [TestMethod()]
        public void Test2()
        {
            int Capacity = 3;

            LRUCache<int, int> Cache = new LRUCache<int, int>(Capacity);
            int ret = 0;

            Cache.Put(0, 1);
            Cache.Put(1, 2);
            Cache.Put(2, 3);

            ret = Cache.Get(0); //returns 1
            Assert.AreEqual(ret, 1);

            ret = Cache.Get(1); //returns 2
            Assert.AreEqual(ret, 2);

            ret = Cache.Get(2); //returns 3
            Assert.AreEqual(ret, 3);

            Cache.Put(2, 4);
            ret = Cache.Get(2); //returns 4
            Assert.AreEqual(ret, 4);

            Cache.Put(3, 5);
            ret = Cache.Get(3); //returns 4
            Assert.AreEqual(ret, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Test3()
        {
            int Capacity = 3;

            LRUCache<int, int> Cache = new LRUCache<int, int>(Capacity);
            int ret = 0;

            Cache.Put(0, 1);
            Cache.Put(1, 2);
            Cache.Put(2, 3);

            ret = Cache.Get(0); //returns 1
            Assert.AreEqual(ret, 1);

            ret = Cache.Get(1); //returns 2
            Assert.AreEqual(ret, 2);

            ret = Cache.Get(2); //returns 3
            Assert.AreEqual(ret, 3);

            Cache.Put(2, 4);
            ret = Cache.Get(2); //returns 4
            Assert.AreEqual(ret, 4);

            Cache.Put(3, 5); //evicts key 0

            ret = Cache.Get(0); //returns not found
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Test4()
        {
            int Capacity = 3;

            LRUCache<int, string> Cache = new LRUCache<int, string>(Capacity);
            string ret = "";

            Cache.Put(0, "Val0");
            Cache.Put(1, "Val1");
            Cache.Put(2, "Val2");

            ret = Cache.Get(0); //returns Val0
            Assert.AreEqual(ret, "Val0");

            ret = Cache.Get(1); //returns Val1
            Assert.AreEqual(ret, "Val1");

            ret = Cache.Get(2); //returns Val2
            Assert.AreEqual(ret, "Val2");

            Cache.Put(2, "Val3");
            ret = Cache.Get(2); //returns 4
            Assert.AreEqual(ret, "Val3");

            Cache.Put(3, "Val4"); //evicts key 0

            ret = Cache.Get(0); //returns not found
        }
    }
}