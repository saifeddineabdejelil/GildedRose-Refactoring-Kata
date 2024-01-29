using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    internal class StrategyItemMapping
    {
        // dictionnay to link each item by strategy to update quality
        internal static Dictionary<string, IGildedRoseStrategy> itemStrategiesMapping =
             new Dictionary<string, IGildedRoseStrategy>(){
                {"Aged Brie", new NormalIncreaseStrategy ()},
                {"Backstage passes to a TAFKAL80ETC concert", new HybridIncreaseStrategy()},
                {"Sulfuras, Hand of Ragnaros", new ConstantStrategy()}};

    }
}
