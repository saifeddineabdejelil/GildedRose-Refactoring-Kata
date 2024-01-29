using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        // to get list of items ( with 1 element ) from an item details
        private static List<Item> CreateItems(string name, int sellin, int quality)
        {
            return new List<Item> { new Item { Name = name, SellIn = sellin, Quality = quality } };
        }
        // create gildedRose object from list of items
        private static GildedRose GetGildedRose(List<Item> listItems)
        {
            return new GildedRose(listItems);
        }
        [Test]
        public void Test_ItemNameWhenCreatingListAndGildedRoseObject()
        {
            var Items = CreateItems("foo", 0, 0);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // name shoud be foo
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void Test_UpdateSellIn_GenericItem()
        {
            // create any item with sellin 7 and quality 7 
            var Items = CreateItems("Generic", 7, 7);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // sellin should be reduced by 1 => 6
            Assert.AreEqual(6, Items[0].SellIn);
        }

        [Test]
        public void Test_UpdateQuality_GenericItem_QualityReducedBy1()
        {
            // create generic item with sellin 7 and quality 7 
            var Items = CreateItems("Generic", 7, 7);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should be reduced by 1 => 6
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_GenericItem_SellinLessOrEqualTo0QualityReducedBy2()
        {
            // create generic item the sell by date has passed (sellin 0) and quality 7 
            var Items = CreateItems("Generic", 0, 7);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should be reduced by 2 =>5
            Assert.AreEqual(5, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_GenericItem_QualityShouldNotBeLessThan0()
        {
            // create generic item with sellin 7 and quality 0 
            var Items = CreateItems("Generic", 7, 0);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should not be reduced by 1 stay 0
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_AgedBrieItem_QualityShouldNotBeMorehan50()
        {
            // create Aged Brie item with quality 50 and sell in 6 days
            var Items = CreateItems("Aged Brie", 6, 50);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should not increase because it is 50
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_ZeroSellinAndQualityShouldNotBeNegative()
        {
            // create generic item with quality 0
            var Items = CreateItems("Generic", 1, 0);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should not be negative => stay 0
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_AgedBrieIncreaseQuality()
        {
            // create Aged Brie item with quality 6 and sell in 6 days
            var Items = CreateItems("Aged Brie", 6, 6);
            GildedRose gildedRose = GetGildedRose(Items);
            gildedRose.UpdateQuality();

            // quality should increase because it is Aged brie => 7
            Assert.AreEqual(7, Items[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_SulfurasKeepSameQuality()
        {
            // create surfurace item with quality 15 and sell in 6 days
            var sulfurasItems = CreateItems("Sulfuras, Hand of Ragnaros", 6, 15);
            GildedRose gildedRose = GetGildedRose(sulfurasItems);
            gildedRose.UpdateQuality();

            // quality surfurace sould not be reduced stay 15
            Assert.AreEqual(15, sulfurasItems[0].Quality);
        }


        [Test]
        public void Test_UpdateQuality_BackstageIncreaseQualityByOneWhenSellinMoreThan10()
        {
            // create Backstage item with quality 15 and sell in 12 days
            var backstageItems = CreateItems("Backstage passes to a TAFKAL80ETC concert", 12, 15);
            GildedRose gildedRose = GetGildedRose(backstageItems);
            gildedRose.UpdateQuality();

            // Backstage item : sellin > 10 quality should be increased by 1 => 16
            Assert.AreEqual(16, backstageItems[0].Quality);
        }


        [Test]
        public void Test_UpdateQuality_BackstageIncreaseQualityByTwoWhenSellinLessOrEqualThan10AndMoreThan5()
        {
            // create Backstage item with quality 15 and sell in 10 days
            var backstageItems = CreateItems("Backstage passes to a TAFKAL80ETC concert", 10, 15);
            GildedRose gildedRose = GetGildedRose(backstageItems);
            gildedRose.UpdateQuality();

            // Backstage item : sellin <= 10 quality should be increased by 2 => 17
            Assert.AreEqual(17, backstageItems[0].Quality);
        }
        [Test]
        public void Test_UpdateQuality_BackstageIncreaseQualityByTwoWhenSellinLessOrEqualThan5()
        {
            // create Backstage item with quality 15 and sell in 5 days
            var backstageItems = CreateItems("Backstage passes to a TAFKAL80ETC concert", 5, 15);
            GildedRose gildedRose = GetGildedRose(backstageItems);
            gildedRose.UpdateQuality();

            // Backstage item : sellin <= 5 quality should be increased by 3 => 18
            Assert.AreEqual(18, backstageItems[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_BackstageSetQuality0WhenSellinLessOrEqualTo0()
        {
            // create Backstage item with quality 15 and sell in 0 days
            var backstageItems = CreateItems("Backstage passes to a TAFKAL80ETC concert", 0, 15);
            GildedRose gildedRose = GetGildedRose(backstageItems);
            gildedRose.UpdateQuality();


            //Backstage Quality drops to 0 after the concert 
            Assert.AreEqual(0, backstageItems[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_ConjuredItemWhenSellinMoreThan0()
        {
            // create conjured item with quality 15 and sell in 5 days
            var conjuredItems = CreateItems("Conjured", 5, 15);
            GildedRose gildedRose = GetGildedRose(conjuredItems);
            gildedRose.UpdateQuality();


            // Quality decrease by 2 
            Assert.AreEqual(13, conjuredItems[0].Quality);
        }

        [Test]
        public void Test_UpdateQuality_ConjuredItemWhenNegativeSellin()
        {
            // create conjured item with quality 15 and sell in 5 days
            var conjuredItems = CreateItems("Conjured", -1, 15);
            GildedRose gildedRose = GetGildedRose(conjuredItems);
            gildedRose.UpdateQuality();


            // Quality decrease by 4 
            Assert.AreEqual(11, conjuredItems[0].Quality);
        }

     }
}
