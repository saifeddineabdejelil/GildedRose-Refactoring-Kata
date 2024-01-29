using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            
            foreach (var item in Items)
            {
                // group the treatments linked to each item under the item name condition

                var isagedbrie = item.Name == "Aged Brie";
                var isbackstage = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                var issulfuras = item.Name == "Sulfuras, Hand of Ragnaros";
                var genericItem = !isagedbrie && !isbackstage && !issulfuras;
                if (genericItem)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = UpdateQualityValue(item.Quality, -1);
                    }
                    item.SellIn = DecreaseSellinValue(item.SellIn);
                    if (item.Quality > 0)
                    {
                        if (item.SellIn < 0) item.Quality = UpdateQualityValue(item.Quality, -1);
                    }
                }
                // here we need just to group treatments refactoring will be done after.
                if (isagedbrie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = UpdateQualityValue(item.Quality, 1);
                    }
                    item.SellIn = DecreaseSellinValue(item.SellIn);
                    if (item.Quality < 50)
                    {
                        if (item.SellIn < 0) item.Quality = UpdateQualityValue(item.Quality, 1); 
                    }
                }
                if (isbackstage)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = UpdateQualityValue(item.Quality, 1);

                        if (item.SellIn < 11)
                        {
                            item.Quality = UpdateQualityValue(item.Quality, 1);
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = UpdateQualityValue(item.Quality, 1);

                        }
                    }
                    item.SellIn = DecreaseSellinValue(item.SellIn);
                    if (item.SellIn < 0) item.Quality = 0;
                }
               
            }
        }

        // Method to decrease the value of sell in by 1 day
        private static int DecreaseSellinValue(int sellinValue)
        {
            return sellinValue - 1;
        }

        // Method to update quality value by value sent.
        private static int UpdateQualityValue(int qualityValue, int updateStep)
        {
            return qualityValue + updateStep;
        }
    }
}
