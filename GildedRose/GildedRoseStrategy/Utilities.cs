using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.GildedRoseStrategy
{
    internal class Utilities
    {
        internal static int DecreaseSellinValue(int sellinValue)
        {
            return sellinValue - 1;
        }

        // Method to update quality value by value sent which include test linked to quality value
        internal static int UpdateQualityValue(int qualityValue, int updateStep)
        {
            var updatedQualityValue = qualityValue + updateStep;
            if (updatedQualityValue > 50) updatedQualityValue = 50;
            else if (updatedQualityValue < 0) updatedQualityValue = 0;
            return updatedQualityValue;
        }
    }
}
