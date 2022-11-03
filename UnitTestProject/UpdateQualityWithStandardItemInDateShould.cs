using GildedRose.Console;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class UpdateQualityWithStandardItemInDateShould
    {
        private readonly Program target = new Program();
        private readonly Item testItem;

        public UpdateQualityWithStandardItemInDateShould()
        {
            testItem = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            target.Items = new List<Item> { testItem };
        }

        [TestMethod]
        public void DecreaseRemainingDays()
        {
            target.UpdateQuality();

            Assert.AreEqual(testItem.SellIn, 9);
        }

        [TestMethod]
        public void DecreaseQuality()
        {
            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 19);
            Assert.AreEqual(testItem.Price, 36.1M);
        }
    }
}