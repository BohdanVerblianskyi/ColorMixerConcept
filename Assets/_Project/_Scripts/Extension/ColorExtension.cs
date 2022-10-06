using UnityEngine;

namespace _Project._Scripts.Extension
{
    public static class ColorExtension
    {
        public static Color ToNegative(this Color color)
        {
            Color.RGBToHSV(color, out var h, out var s, V: out var v);
            var negativeH = (h + 0.5f) % 1f;
            return Color.HSVToRGB(negativeH, s, v);
        }
    }
}