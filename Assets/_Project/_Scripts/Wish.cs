using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts
{
    [CreateAssetMenu(fileName = "WishfulColor", menuName = "WishfulColor", order = 0)]
    public class Wish : ScriptableObject
    {
        [SerializeField] private List<WishfulColor> _wishfulColors;
        [SerializeField] private int _level = 0;

        public WishfulColor WishfulColor => _wishfulColors[_level];

        public void MoveNext()
        {
            _level++;

            if (_wishfulColors.Count <= _level)
            {
                _level = 0;
            }
        }
    }
}