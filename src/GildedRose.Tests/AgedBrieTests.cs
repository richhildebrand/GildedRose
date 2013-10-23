using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class AgedBrieTests : BaseItemTests
    {
        protected override string ItemToTest { get { return "Aged Brie"; } }

        private void BreeShouldIncreaseOneQuality(int quality, int sellIn)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality + 1);
        }

        private void BreeShouldIncreaseTwoQuality(int quality, int sellIn)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality + 2);
        }

        [Test]
        public override void GivenTenQuality_WithTwentySellIn_Then()
        {
            BreeShouldIncreaseOneQuality(10, 20);
        }
  
        [Test]
        public override void GivenTenQuality_WithNineSellIn_Then()
        {
            BreeShouldIncreaseOneQuality(10, 9);
        }

        [Test]
        public override void GivenThirtyQuality_WithNegativeSellIn_Then()
        {
            BreeShouldIncreaseTwoQuality(30, -1);
        }
    }
}
