using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    // contains generic behavior to increase quality by 1 and by 2 when sell in <= 0 
    internal class NormalIncreaseStrategy : IGildedRoseStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn > 0) item.Quality = Utilities.UpdateQualityValue(item.Quality, 1);
            else item.Quality = Utilities.UpdateQualityValue(item.Quality, 2);
            item.SellIn = Utilities.DecreaseSellinValue(item.SellIn);
        }
    }
}
