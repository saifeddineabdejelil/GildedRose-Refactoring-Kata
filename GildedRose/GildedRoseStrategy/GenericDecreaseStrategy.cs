using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    // contains generic behavior to decrease quality by 1 and by 2 when sell in <= 0 
    internal class GenericDecreaseStrategy : IGildedRoseStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = item.SellIn > 0 ? Utilities.UpdateQualityValue(item.Quality, -1) :
                    Utilities.UpdateQualityValue(item.Quality, -2);

            item.SellIn = Utilities.DecreaseSellinValue(item.SellIn);
        }
    }
}
