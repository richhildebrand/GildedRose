using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    abstract class BaseItemTests
    {
        abstract protected string ItemToTest { get; }

        [Test]
        public virtual void GivenThirtyQuality_WithNegativeSellIn_Then()
        {
            ItemShouldDecreaseTwoQuality(30, -1);
        }

        [Test]
        public virtual void GivenFiftyQuality_WithTwentySellIn_ThenItemQualityShouldBeLessThan51()
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = 20, Quality = 50 } };
            
            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.Less(resultQuality, 51);
        }

        [Test]
        public virtual void GivenTenQuality_WithTwentySellIn_Then()
        {
            ItemShouldDecreaseOneQuality(10, 20);
        }

        [Test]
        public virtual void GivenTenQuality_WithNineSellIn_Then()
        {
            ItemShouldDecreaseOneQuality(10, 9);
        }

        [Test]
        public virtual void GivenTenQuality_WithFourSellIn_Then()
        {
            ItemShouldDecreaseOneQuality(10, 4);
        }

        private void ItemShouldDecreaseTwoQuality(int quality, int sellin)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellin, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality-2);
        }

        private void ItemShouldDecreaseOneQuality(int quality, int sellIn) {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultSellInValue = app.Items.First().Quality;

            Assert.AreEqual(resultSellInValue, quality - 1);
        }
    }
}
