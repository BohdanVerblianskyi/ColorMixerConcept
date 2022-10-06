using UnityEngine;

namespace _Project._Scripts.Extension
{
    public static class Vector3Extension
    {
        public static float Duration(this Vector3 start, Vector3 end, float coefficient)
        {
            return Vector3.Distance(start, end) * coefficient;
        }
    }
}