﻿using System.Collections.Generic;

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
            // try to put item name top in if conditions one by one
            foreach (var item in Items)
            {
                // create boolean variables to make conditions more readable
                var isagedbrie = item.Name == "Aged Brie";
                var isbackstage = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                var issulfuras = item.Name == "Sulfuras, Hand of Ragnaros";
                var genericItem = !isagedbrie && !isbackstage && !issulfuras;
                if (genericItem) // first if condition decrease quantity when item not (sulfuras, agedbrie, sulfuras) and quality >0
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
                // old else changed by two if ( it was else if not agedBrie and not backstage) 
                // replaced by two if for aged Brie, backstage
                // the old behavior increase quality by 1 and check if backstage continue to increase
                if (isagedbrie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
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
                }
                // here the old one check if it is not sulfuras so I changed to check quality updating method linked to rest of items
                if (isagedbrie || isbackstage || genericItem)
                {
                    item.SellIn = item.SellIn - 1;
                }
                // 
                if (item.SellIn < 0)
                {
                    // try to put item name logic in if condition and keep the check in sellin value for now
                    if (issulfuras || isbackstage || genericItem)
                    {
                        if (genericItem)
                        {
                            if (item.Quality > 0)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                        else if (isbackstage)
                        {
                            item.Quality = 0;
                        }
                    }
                    else if (isagedbrie)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
