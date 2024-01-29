using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    // contains hybrid behavior to increase quality by different methods linked to sellin value
    internal class HybridIncreaseStrategy : IGildedRoseStrategy
    {
        public void UpdateQuality(Item item)
        {
            switch (item.SellIn)
            {
                case <= 0:
                    item.Quality = 0;
                    break;
                case < 6:
                    item.Quality = Utilities.UpdateQualityValue(item.Quality, 3);
                    break;
                case < 11:
                    item.Quality = Utilities.UpdateQualityValue(item.Quality, 2);
                    break;

                default:
                    item.Quality = Utilities.UpdateQualityValue(item.Quality, 1);
                    break;
            }
            item.SellIn = Utilities.DecreaseSellinValue(item.SellIn);
        }
    }
}
