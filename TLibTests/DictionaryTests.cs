using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TLib;

namespace TLibTests
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void GetOrAdd()
        {
            var d = new Dictionary<string, StockStatus>() {
                {"AAPL", new StockStatus { Price = 530.12m, Position = "Sell" }},
                {"GOOG", new StockStatus { Price = 123.5m, Position = "Buy" }}
            };

            d.GetOrAdd("AAPL").Position = "Buy";
            d.GetOrAdd("YHOO").Price = 1.99m;
            Console.Out.WriteLine(d.ToString<string, StockStatus>());

            Assert.That(d["AAPL"].Position, Is.EqualTo("Buy"), "Incorrect position.");
            Assert.That(d.Keys, Has.Count.EqualTo(3), "Incorrect number of keys.");
            Assert.That(d["YHOO"].Price, Is.EqualTo(1.99m), "Incorrect price.");
        }

        class StockStatus
        {
            public decimal Price { get; set; }
            public string Position { get; set; }

            public override string ToString()
            {
                return string.Format("{{ Price: {0}, Position: {1} }}", Price, Position ?? "None");
            }
        }
    }
}
