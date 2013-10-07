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
        public virtual void GivenTenQuality_WithTwentySellIn_Then()
        {
            ItemShouldDecreaseOneQuality();
        }

        [Test]
        public void GivenTenQuality_WithNineSellIn_Then()
        {
            ItemShouldDecreaseOneQuality();
        }

        private void ItemShouldDecreaseOneQuality() {
            var givenSellinValue = 10;
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = givenSellinValue, Quality = 10 } };

            app.UpdateQuality();
            var resultSellInValue = app.Items.First().SellIn;

            Assert.AreEqual(resultSellInValue, givenSellinValue - 1);
        }
    }
}
