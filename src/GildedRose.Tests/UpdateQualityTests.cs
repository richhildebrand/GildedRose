using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class UpdateQualityTests
    {
        [TestCase("+5 Dexterity Vest")]
        [TestCase("Aged Brie")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Conjured Mana Cake")]
        public void GivenOneOfEachItemType_WhenQualityIs50_NeverReturnQualityOver50(string itemName)
        {
            var maxQuality = 50;
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = maxQuality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.GreaterOrEqual(maxQuality, resultQuality);
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase("Aged Brie")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Conjured Mana Cake")]
        public void GivenOneOfEachItemType_WhenQualityIsNegative_NeverReturnItem(string itemName)
        {
            var negativeQuality = -1;
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = negativeQuality } };

            app.UpdateQuality();

            // Not sure why this should be empty.
            CollectionAssert.IsEmpty(app.Items);
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase("Aged Brie")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Conjured Mana Cake")]
        public void GivenAnItem_WhenItsTheEndOfTheDay_SellInValueShouldDecreaseByOne(string itemName)
        {
            var givenSellinValue = 10;
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = itemName, SellIn = givenSellinValue, Quality = 10 } };

            app.UpdateQuality();
            var resultSellInValue = app.Items.First().SellIn;

            Assert.AreEqual(resultSellInValue, givenSellinValue - 1);
        }
    }
}
