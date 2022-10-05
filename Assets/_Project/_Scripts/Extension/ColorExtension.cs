using UnityEngine;

namespace _Project._Scripts.Extension
{
    public static class ColorExtension
    {
        public static Color ToNegative(this Color color)
        {
            Color.RGBToHSV(color, out float H, out float S, out float V);
            var negativeH = (H + 0.5f) % 1f;
            return  Color.HSVToRGB(negativeH, S, V);
        }
    }
}