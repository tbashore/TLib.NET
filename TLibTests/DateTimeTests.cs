using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class DateTimeTests
    {
        [Test]
        public void Between()
        {
            DateTime middle = DateTime.Today;
            DateTime start = middle.AddDays(-2);
            DateTime end = middle.AddDays(2);

            Assert.That(middle.Between(start, end), Is.True);
            Assert.That(middle.Between(end, start), Is.True, "Should have allowed reversed range.");
            Assert.That(start.Between(middle, end), Is.False);
            Assert.That(end.Between(start, middle), Is.False);
            Assert.That(start.Between(start, end), Is.True, "Not inclusive.");
            Assert.That(end.Between(start, end), Is.True, "Not inclusive.");
        }
    }
}
