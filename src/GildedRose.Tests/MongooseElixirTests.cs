using System;
using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    class MongooseElixirTests : BaseItemTests
    {
        protected override string ItemToTest { get { return "Elixir of the Mongoose"; } }
    }
}
