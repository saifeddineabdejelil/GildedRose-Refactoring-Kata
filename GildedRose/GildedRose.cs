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
                        item.Quality = item.Quality - 1;
                    }
                    item.SellIn = item.SellIn - 1;
                    if (item.Quality > 0)
                    {
                        if (item.SellIn < 0) item.Quality = item.Quality - 1;
                    }
                }
                // here we need just to group treatments refactoring will be done after.
                if (isagedbrie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                    item.SellIn = item.SellIn - 1;
                    if (item.Quality < 50)
                    {
                        if (item.SellIn < 0) item.Quality = item.Quality + 1;
                    }
                }
                if (isbackstage)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.SellIn < 11)
                        {
                            item.Quality = item.Quality + 1;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = item.Quality + 1;

                        }
                    }
                    item.SellIn = item.SellIn - 1;
                    if (item.SellIn < 0) item.Quality = 0;
                }
               
            }
        }
    }
}
