using System;

namespace HurriKane.Material.Design.Api.Extensions
{
    public static class IntExtensions
    {
        public static bool WithinRange(this int rangeValue, int minimum = 1, int maximum = 12)
        {
            if (rangeValue == -1)
                return false;

            if (rangeValue >= minimum && rangeValue <= maximum)
            {
                return true;
            }

            throw new IndexOutOfRangeException($"The range supplied is exceeded (min: {minimum}, max: {maximum}): {rangeValue} ");
        }
    }
}