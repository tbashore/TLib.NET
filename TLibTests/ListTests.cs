using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void Partition()
        {
            var list = new List<int>() { 1, 2, 3, 10, 20, 30, 100, 200, 300 };

            foreach (List<int> sub in list.Partition(3))
            {
                Console.Out.WriteLine(sub.ToString<int>());
                Assert.That(sub, Has.Count.EqualTo(3), "Incorrect list length.");
            }
        }

        [Test]
        public void PopFirst()
        {
            var list = new List<string>() { "first", "second", "third" };

            var first = list.PopFirst();
            Assert.That(first, Is.EqualTo("first"), "Incorrect element returned.");
            Assert.That(list, Has.Count.EqualTo(2), "Incorrect length.");
        }

        [Test]
        public void PopLast()
        {
            var list = new List<string>() { "first", "second", "third" };

            var last = list.PopLast();
            Assert.That(last, Is.EqualTo("third"), "Incorrect element returned.");
            Assert.That(list, Has.Count.EqualTo(2), "Incorrect length.");
        }

        [Test]
        public void Join()
        {
            var list = new List<string>() { "first", "second", "third" };
            var joined = list.Join(",");
            Assert.That(joined, Has.Length.EqualTo(18), "Incorrect length.");
        }

        [Test]
        public void Distinct()
        {
            var list = new List<string>() { "one", "two", "one", "three", "three" };
            var distinct = list.Distinct();
            Assert.AreEqual(new[] { "one", "two", "three" }, distinct);
        }
    }
}
