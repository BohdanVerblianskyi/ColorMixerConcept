using System;
using UnityEngine;

namespace _Project._Scripts
{
    [Serializable]
    public class WishfulColor
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _color;

        public Color Color => _color;
        public Sprite Sprite => _sprite;
    }
}