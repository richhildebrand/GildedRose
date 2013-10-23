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

        private void SulfurasShouldNeverDecreaseInQuality(int quality, int sellIn)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality);
        }

        [Test]
        public override void GivenTenQuality_WithTwentySellIn_Then()
        {
            SulfurasShouldNeverDecreaseInQuality(10, 20);
        }

        [Test]
        public override void GivenTenQuality_WithNineSellIn_Then()
        {
            SulfurasShouldNeverDecreaseInQuality(10, 9);
        }

        [Test]
        public override void GivenTenQuality_WithFourSellIn_Then() {
            SulfurasShouldNeverDecreaseInQuality(10, 4);
        }

        [Test]
        public override void GivenThirtyQuality_WithNegativeSellIn_Then()
        {
            SulfurasShouldNeverDecreaseInQuality(30, -1);
        }
    }
}
