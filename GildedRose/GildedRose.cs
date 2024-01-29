using GildedRose.GildedRoseStrategy;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
                // by item name we will get the strategy to update quality linked and execute the update
                var updateQualityStrategy = StrategyItemMapping.itemStrategiesMapping.TryGetValue(item.Name, out var qualityStrategy) ?
                        qualityStrategy : new GenericDecreaseStrategy();
                updateQualityStrategy.UpdateQuality(item);
            }
        }
    }
}
