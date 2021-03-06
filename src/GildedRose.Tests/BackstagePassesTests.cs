﻿using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class BackstagePassesTests : BaseItemTests
    {
        protected override string ItemToTest { get { return "Backstage passes to a TAFKAL80ETC concert"; } }


        private void BackStagePassShouldIncreaseThreeQuality(int quality, int sellin)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellin, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality + 3);
        }

        private void BackStatePassShouldBeZeroQuality(int quality, int sellin)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellin, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, 0);
        }

        private void BackStagePassShouldIncreaseTwoQuality(int quality, int sellIn)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality + 2);
        }

        private void BackStagePassShouldIncreaseOneQuality(int quality, int sellIn)
        {
            var app = new GildedRose.Console.Program();
            app.Items = new List<Item> { new Item { Name = ItemToTest, SellIn = sellIn, Quality = quality } };

            app.UpdateQuality();
            var resultQuality = app.Items.First().Quality;

            Assert.AreEqual(resultQuality, quality + 1);
        }

        [Test]
        public override void GivenTenQuality_WithTwentySellIn_Then()
        {
            BackStagePassShouldIncreaseOneQuality(10, 20);
        }
  
        [Test]
        public override void GivenTenQuality_WithNineSellIn_Then()
        {
            BackStagePassShouldIncreaseTwoQuality(10, 9);
        }

        [Test]
        public override void GivenTenQuality_WithFourSellIn_Then()
        {
            BackStagePassShouldIncreaseThreeQuality(10, 4);
        }

        [Test]
        public override void GivenThirtyQuality_WithNegativeSellIn_Then()
        {
            BackStatePassShouldBeZeroQuality(30, -1);
        }
    }
}
