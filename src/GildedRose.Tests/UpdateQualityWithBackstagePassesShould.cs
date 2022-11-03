using GildedRose.Console;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateQualityWithBackstagePassesShould
    {
        const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        private readonly Program target = new Program();
        private Item testItem;

        [Fact]
        public void DecreaseRemainingDays()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 10,
                Quality = 20
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.SellIn.ShouldBe(9);
        }

        [Fact]
        public void IncreaseQualityByOneWithMoreThanTenDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 11,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(11);
        }

        [Fact]
        public void IncreaseQualityByTwoWithTenDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 10,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(12);
        }

        [Fact]
        public void IncreaseQualityByTwoWithSixDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 6,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(12);
        }

        [Fact]
        public void IncreaseQualityByThreeWithFiveDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 5,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(13);
        }

        [Fact]
        public void IncreaseQualityByThreeWithOneDayRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 1,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(13);
        }

        [Fact]
        public void LoseAllQualityAfterConcert()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 0,
                Quality = 10
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(0);
        }

        [Fact]
        public void LimitQualityToFifty()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 11,
                Quality = 50
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(50);
        }

        [Fact]
        public void LimitQualityToFiftyWithTenDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 10,
                Quality = 49
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(50);
        }

        [Fact]
        public void LimitQualityToFiftyWithFiveDaysRemaining()
        {
            testItem = new Item
            {
                Name = BACKSTAGE_PASS,
                SellIn = 5,
                Quality = 49
            };

            target.Items = new List<Item> { testItem };

            target.UpdateQuality();

            testItem.Quality.ShouldBe(50);
        }
    }
}