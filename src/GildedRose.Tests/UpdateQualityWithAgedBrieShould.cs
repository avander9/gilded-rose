using GildedRose.Console;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class UpdateQualityWithAgedBrieShould
    {
        const string AGED_BRIE = "Aged Brie";
        private readonly Program target = new Program();
        private Item testItem;

        [TestMethod]
        public void DecreaseRemainingDays()
        {
            testItem = new Item
            {
                Name = AGED_BRIE,
                SellIn = 10,
                Quality = 20
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.SellIn, 9);
            Assert.AreEqual(testItem.Price, 39.9M);
        }

        [TestMethod]
        public void IncreaseQualityWhenBelowFifty()
        {
            testItem = new Item
            {
                Name = AGED_BRIE,
                SellIn = 10,
                Quality = 49
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();
            Assert.AreEqual(testItem.Quality, 50);
        }

        [TestMethod]
        public void LimitQualityToFifty()
        {
            testItem = new Item
            {
                Name = AGED_BRIE,
                SellIn = 10,
                Quality = 50
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();
            Assert.AreEqual(testItem.Quality, 50);
        }

        [TestMethod]
        public void IncreaseQualityTwiceAsFastAfterSaleDeadline()
        {
            // Note: Case discovered during characterisation
            testItem = new Item
            {
                Name = AGED_BRIE,
                SellIn = 0,
                Quality = 48
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 50);
        }

        [TestMethod]
        public void LimitQualityToFiftyWhenRateHasDoubled()
        {
            // Note: Case discovered during characterisation
            testItem = new Item
            {
                Name = AGED_BRIE,
                SellIn = 0,
                Quality = 49
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 50);
        }
    }
}