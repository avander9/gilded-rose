using GildedRose.Console;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
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

        [Fact]
        public void DecreaseRemainingDays()
        {
            target.UpdateQuality();

            testItem.SellIn.ShouldBe(9);
        }

        [Fact]
        public void DecreaseQuality()
        {
            target.UpdateQuality();

            testItem.Quality.ShouldBe(19);
            testItem.Price.ShouldBe(36.1M);
        }
    }
}