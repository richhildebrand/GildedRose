using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class SulfuraseTests : BaseItemTests 
    {
        protected override string ItemToTest { get { return "Sulfuras, Hand of Ragnaros"; } }

        // I was thinking of trying an inheritance model, 
        // we could overload the tests that are differet for each
        // item, but I can't figure out how to do naming, so it might be bad idea.
        private void SulfurasShouldNeverDecreaseInQuality()
        {
            var startingQuality = 10;
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = 10, Quality = startingQuality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, startingQuality);
        }

        // Something like this?
        [Test]
        public override void GivenTenQuality_WithTwentySellIn_Then()
        {
            SulfurasShouldNeverDecreaseInQuality();
        }
    }
}
