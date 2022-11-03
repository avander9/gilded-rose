using GildedRose.Console;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class UpdateQualityWithStandardItemOutOfDateShould
    {
        private readonly Program target = new Program();
        private readonly Item testItem;

        public UpdateQualityWithStandardItemOutOfDateShould()
        {
            testItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 20
            };

            target.Items = new List<Item> { testItem };
        }

        [TestMethod]
        public void DecreaseRemainingDays()
        {
            target.UpdateQuality();

            Assert.AreEqual(testItem.SellIn, -1);
        }

        [TestMethod]
        public void DecreaseQualityTwiceAsFast()
        {
            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 18);
            Assert.AreEqual(testItem.Price, 34.2M);

        }
    }
}