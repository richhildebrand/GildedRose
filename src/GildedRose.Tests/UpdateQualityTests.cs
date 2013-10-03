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
        [Test]
        public void GivenOneOfEachItemType_WhenQualityIs50_NeverReturnQualityOver50()
        {
            var app = new GildedRose.Console.Program();
            var quality50Items = new List<Item> {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50},
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 50},
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 50},
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50},
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 50}
            };
            app.Items = quality50Items;

            app.UpdateQuality();
            var itemsWithQualityOver50 = app.Items.Where(i => i.Quality > 50);
            
            CollectionAssert.IsEmpty(itemsWithQualityOver50);
        }
    }
}
