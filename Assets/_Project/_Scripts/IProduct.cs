using UnityEngine;

namespace _Project._Scripts
{
    public interface IProduct
    {
        Color Color { get; }
        void TurnOff();
    }
}