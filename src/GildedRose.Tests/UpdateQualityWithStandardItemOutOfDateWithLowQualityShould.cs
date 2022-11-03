using GildedRose.Console;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class UpdateQualityWithStandardItemOutOfDateWithLowQualityShould
    {
        const string DEXTERITY_VEST = "+5 Dexterity Vest";
        private readonly Program target = new Program();
        private Item testItem;

        [TestMethod]
        public void DecreaseQualityOfTwoToZero()
        {
            testItem = new Item { SellIn = 0, Quality = 1, Name = DEXTERITY_VEST, };
            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 0);
        }

        [TestMethod]
        public void DecraseQualityOnlyToZero()
        {
            testItem = new Item { SellIn = 0, Quality = 1, Name = DEXTERITY_VEST, };
            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 0);
        }

        [TestMethod]
        public void DisallowNegativeQuality()
        {
            testItem = new Item { SellIn = 0, Quality = 0, Name = DEXTERITY_VEST, };
            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            Assert.AreEqual(testItem.Quality, 0);
            Assert.AreEqual(testItem.Price, 0);
        }
    }
}