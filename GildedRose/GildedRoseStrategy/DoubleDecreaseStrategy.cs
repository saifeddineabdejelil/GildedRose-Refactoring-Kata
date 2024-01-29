using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    // contains double decrease behavior to decrease quality (twice as fast as generic) by 2 and by 4 when sell in <= 0 
    internal class DoubleDecreaseStrategy : IGildedRoseStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = item.SellIn > 0 ? Utilities.UpdateQualityValue(item.Quality, -2) :
                    Utilities.UpdateQualityValue(item.Quality, -4);

            item.SellIn = Utilities.DecreaseSellinValue(item.SellIn);
        }
    }
}
