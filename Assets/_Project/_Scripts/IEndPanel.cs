using System;

namespace _Project._Scripts
{
    public interface IEndPanel
    {
        public Action OnNext { get; set; }
        public Action OnRestart { get; set; }
    }
}