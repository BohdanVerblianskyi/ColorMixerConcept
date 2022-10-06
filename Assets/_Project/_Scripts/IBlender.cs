using System;
using UnityEngine;

namespace _Project._Scripts
{
    public interface IBlender
    {
        Action<Color> OnEndMix { get; set; }
    }
}