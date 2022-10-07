using System;

namespace _Project._Scripts
{
    public interface IEndPanel
    {
        Action OnNext { get; set; }
        Action OnRestart { get; set; }
    }
}