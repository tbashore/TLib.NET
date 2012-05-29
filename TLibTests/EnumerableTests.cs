using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class EnumerableTests
    {
        [Test]
        public void Reduce()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            int sum = list.Reduce(0, (int agg, int x) => { return agg + x; });
            Assert.That(sum, Is.EqualTo(21));
        }

        [Test]
        public void Map()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var doubled = list.Map(x => x * 2);
            Assert.That(doubled.First(), Is.EqualTo(2));
            Assert.That(doubled.Last(), Is.EqualTo(12));
        }
    }
}
