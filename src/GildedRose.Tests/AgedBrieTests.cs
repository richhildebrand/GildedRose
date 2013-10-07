using System;
using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class AgedBrieTests : BaseItemTests
    {
        protected override string ItemToTest { get { return "Aged Brie"; } }
    }
}
