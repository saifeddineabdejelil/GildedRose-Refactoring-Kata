using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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
                var isagedbrie = item.Name == "Aged Brie";
                var isbackstage = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                var issulfuras = item.Name == "Sulfuras, Hand of Ragnaros";
                var genericItem = !isagedbrie && !isbackstage && !issulfuras;
                if (genericItem)
                {
                    // first system generic posetive sellin decrease quality by 1 ; 0 or negative sell in decrease quality by 2
                    item.Quality = item.SellIn > 0 ? UpdateQualityValue(item.Quality, -1) :
                     UpdateQualityValue(item.Quality, -2);

                    item.SellIn = DecreaseSellinValue(item.SellIn);

                }
                else if (isagedbrie)
                {
                    // item like aged brie update quality system : increase by on when sell in postive else increase by 2
                    if (item.SellIn > 0) item.Quality = UpdateQualityValue(item.Quality, 1);
                    else item.Quality = UpdateQualityValue(item.Quality, 2);
                    item.SellIn = DecreaseSellinValue(item.SellIn);
                }
                else if (isbackstage)
                {
                    // items like backstage have hybrid system to update quality.
                    switch (item.SellIn)
                    {
                        case <= 0:
                            item.Quality = 0;
                            break;
                        case < 6:
                            item.Quality = UpdateQualityValue(item.Quality, 3);
                            break;
                        case < 11:
                            item.Quality = UpdateQualityValue(item.Quality, 2);
                            break;

                        default:
                            item.Quality = UpdateQualityValue(item.Quality, 1);
                            break;
                    }
                     item.SellIn = DecreaseSellinValue(item.SellIn);

                }
                // do nothing for items like sulfuras
                else return;

            }
        }

        // Method to decrease the value of sell in by 1 day
        private static int DecreaseSellinValue(int sellinValue)
        {
            return sellinValue - 1;
        }

        // Method to update quality value by value sent which include test linked to quality value
        private static int UpdateQualityValue(int qualityValue, int updateStep)
        {
            var updatedQualityValue = qualityValue + updateStep;
            if (updatedQualityValue > 50) updatedQualityValue = 50;
            else if (updatedQualityValue < 0) updatedQualityValue = 0;
            return updatedQualityValue;
        }
    }
}
