using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class RandomTests
    {
        [Test]
        public void NextDateTime()
        {
            var r = new Random();

            var today = DateTime.Today.Date;
            var tomorrow = today.AddDays(1);

            for (var i = 0; i < 100; i++)
            {
                Assert.That(r.NextDateTime(today, tomorrow), Is.InRange(today, tomorrow));
                Assert.That(r.NextDateTime(today, today), Is.EqualTo(today));
            }
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDateTimeFails()
        {
            var r = new Random();

            var today = DateTime.Today.Date;
            var tomorrow = today.AddDays(1);

            Console.Out.WriteLine(r.NextDateTime(tomorrow, today));
        }

        public enum SomeCode
        {
            Undefined = 0,
            First = 1,
            Middle = 125,
            Last = 1000
        }

        [Test]
        public void NextEnum()
        {
            var r = new Random();

            for (var i = 0; i < Enum.GetValues(typeof(SomeCode)).Length * 100; i++)
            {
                Assert.That(r.NextEnum<SomeCode>(), Is.InRange(SomeCode.Undefined, SomeCode.Last));
            }
        }

        [Test]
        public void NextEnumInRange()
        {
            var r = new Random();

            for (var i = 0; i < Enum.GetValues(typeof(SomeCode)).Length * 100; i++)
            {
                Assert.That(r.NextEnum(SomeCode.Undefined, SomeCode.Last), Is.InRange(SomeCode.Undefined, SomeCode.Last));
                Assert.That(r.NextEnum(SomeCode.First, SomeCode.Last), Is.InRange(SomeCode.First, SomeCode.Last));
                Assert.That(r.NextEnum(SomeCode.Middle, SomeCode.Middle), Is.EqualTo(SomeCode.Middle));
            }
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextEnumInRangeFails()
        {
            var r = new Random();

            r.NextEnum(SomeCode.Last, SomeCode.First);
        }

        [Test]
        public void NextEnumInRangeExcept()
        {
            var r = new Random();

            for (var i = 0; i < Enum.GetValues(typeof(SomeCode)).Length * 100; i++)
            {
                Assert.That(r.NextEnum(SomeCode.Undefined, SomeCode.Last, SomeCode.Middle), Is.InRange(SomeCode.Undefined, SomeCode.Last).And.Not.EqualTo(SomeCode.Middle));
                Assert.That(r.NextEnum(SomeCode.First, SomeCode.Last, SomeCode.Last), Is.InRange(SomeCode.First, SomeCode.Middle));
            }
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextEnumInRangeExceptFails()
        {
            var r = new Random();

            r.NextEnum(SomeCode.Middle, SomeCode.Middle, SomeCode.Middle);
        }
    }
}
