using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class HelperMethods
    {

        public static float Validate(float currentValue, float minValue, float maxValue, 
                        float defaultValue)
        {
            if (currentValue < minValue || currentValue > maxValue)
                return defaultValue;

            return currentValue;
        }
        public static int Validate(int currentValue, int minValue, int maxValue,
                        int defaultValue)
        {
            if (currentValue < minValue || currentValue > maxValue)
                return defaultValue;

            return currentValue;
        }

    }
}
