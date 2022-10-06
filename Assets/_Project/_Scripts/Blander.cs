using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class Blander : MonoBehaviour
    {
        [SerializeField] private Shake _shake;
        [SerializeField] private Cover _cover;


        public void Construct(IEnumerable<IForBlander> forBlenders, IButton button)
        {
            _cover.Construct(forBlenders);
        }
            
        
        public Action<Color> OnEndMid;
        
        public Vector3 Position => _shake.Position;

        private void Play(Action<Color> end)
        {
            transform.DOShakeRotation(2f,2f).onComplete+= () => _shake.ToMix();
        }
    }
}