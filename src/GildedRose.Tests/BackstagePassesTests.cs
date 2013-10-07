using System;
using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class BackstagePassesTests : BaseItemTests
    {
        protected override string ItemToTest { get { return "Backstage passes to a TAFKAL80ETC concert"; } }
    }
}
