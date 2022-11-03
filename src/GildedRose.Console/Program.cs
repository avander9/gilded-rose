﻿using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {

                Items[i].SellIn--;
                int sellInValue = Items[i].SellIn < 0 ? 2 : 1;

                if (Items[i].Name != "Aged Brie" && Items[i].Quality > 0)
                    Items[i].Quality = Items[i].Quality - sellInValue < 0 ? 0 : Items[i].Quality - sellInValue;
                else if (Items[i].Quality < 50 && Items[i].Name == "Aged Brie")
                    Items[i].Quality = Items[i].Quality + sellInValue > 50 ? 50 : Items[i].Quality + sellInValue;

                Items[i].Price = Math.Round(Items[i].Quality * 1.9M, 2);
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
    }
}
