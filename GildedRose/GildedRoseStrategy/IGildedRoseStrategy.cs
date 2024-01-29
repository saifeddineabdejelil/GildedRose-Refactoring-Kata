using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    internal  interface IGildedRoseStrategy
    {
        void UpdateQuality(Item item);
    }
}
