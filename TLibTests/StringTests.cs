using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void Truncate()
        {
            var s = "The quick brown fox jumped over the lazy dog.";

            Assert.That(s.Truncate(9), Has.Length.EqualTo(9), "Incorrect length.");
            Assert.That(s.Truncate(100), Has.Length.EqualTo(s.Length), "Incorrect length.");            
        }

        [Test]
        public void With()
        {
            Assert.That("The {0} brown fox {1}.".With("quick", "jumped"), Is.EqualTo("The quick brown fox jumped."), "");
        }
    }
}
