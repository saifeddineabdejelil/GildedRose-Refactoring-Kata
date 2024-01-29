using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    // contains constant  behavior in which quality should not be modified
    internal class ConstantStrategy : IGildedRoseStrategy
    {
        public void UpdateQuality(Item item)
        {
            return;
        }
    }
}
