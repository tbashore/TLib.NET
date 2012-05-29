using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class SetTests
    {
        [Test]
        public void Union()
        {
            var s1 = new Set<string>() { "Apple", "Banana", "three" };
            var s2 = new Set<string>() { "one", "Banana", "Apple" };

            var s3 = s1.Union(s2);
            Console.Out.WriteLine(s3);

            Assert.That(s3, Has.Count.EqualTo(4), "Incorrect number of elements.");
        }

        [Test]
        public void Intersection()
        {
            var s1 = new Set<string>() { "Apple", "Banana", "three" };
            var s2 = new Set<string>() { "one", "Banana", "Apple" };

            var s3 = s1.Intersection(s2);
            Console.Out.WriteLine(s3);

            Assert.That(s3, Has.Count.EqualTo(2), "Incorrect number of elements.");
            Assert.That(s3, Has.Member("Banana"), "Missing element");
        }

        [Test]
        public void Difference()
        {
            var s1 = new Set<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var s2 = new Set<int>() { 2, 4, 6, 8, 10 };

            var s3 = s1.Difference(s2);
            Console.Out.WriteLine(s3);

            Assert.That(s3, Has.Count.EqualTo(s1.Count - s2.Count), "Incorrect number of elements.");
            Assert.That(s3, Has.No.Member(10), "Element should have been eliminated.");
            Assert.That(s3, Has.Member(9), "Missing element.");
        }

        [Test]
        public void Complement()
        {
            var s1 = new Set<int>() { 1, 2, 3, 4, 5 };
            var s2 = new Set<int>() { 2, 4, 5, 6, 8, 10 };

            var s3 = s1.Complement(s2);
            Console.Out.WriteLine(s3);

            Assert.That(s3, Has.Count.EqualTo(2), "Incorrect number of elements.");
            Assert.That(s3, Has.Member(1), "Missing element.");
            Assert.That(s3, Has.No.Member(10), "Element should not be present.");
        }

        [Test]
        public void CartesianProduct()
        {
            var s1 = new Set<string>() { "Apple", "Banana", "Coconut" };
            var s2 = new Set<string>() { "one", "two", "three" };

            var s3 = s1.CartesianProduct(s2, (string k1, string k2) => { return k1 + k2; });
            Console.Out.WriteLine(s3.ToString());

            Assert.That(s3, Has.Count.EqualTo(s1.Count * s2.Count), "Incorrect number of elements.");
            Assert.That(s3, Has.Member("Appleone"), "Missing element.");

            var b1 = new Set<int>() { 1, 2, 4, 8 };
            var b2 = new Set<int>() { 2 };

            var b3 = b1.CartesianProduct(b2, (int x, int y) => { return x * y; });
            Console.Out.WriteLine(b3);

            Assert.That(b3, Has.Member(16), "Missing element.");
        }
    }
}
