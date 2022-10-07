using System;
using UnityEngine;

namespace _Project._Scripts.Extension
{
    public static class ColorExtension
    {
        public static int PercentageOfStairs(this Color a, Color b)
        {
            var red = Mathf.Abs(a.r - b.r);
            var green = Mathf.Abs(a.g - b.g);
            var blue = Mathf.Abs(a.b - b.b);

            var deltaColor = 0f;
            deltaColor += DeltaColor(red, green);
            deltaColor += DeltaColor(green, blue);
            deltaColor += DeltaColor(blue, red);
            deltaColor /= 3f;

            return (int)Math.Round(((1f - deltaColor) * 100f));
        }

        private static float DeltaColor(float a, float b)
        {
            return Mathf.Sqrt(a * a + b * b);
        }
    }
}