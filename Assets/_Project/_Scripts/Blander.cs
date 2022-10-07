using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class Blander : MonoBehaviour, IBlender
    {
        [SerializeField] private Shake _shake;
        [SerializeField] private Cover _cover;

        public Action<Color> OnEndMix { get; set; }
        public Vector3 Position => _shake.Position;

        public void Construct(IEnumerable<IForBlander> forBlenders, IButton button)
        {
            _cover.Construct(forBlenders);
            button.OnClick += Play;
            _shake.Construct();
        }

        private void Play()
        {
            const float duration = 2f;
            transform.DOShakeRotation(duration, 2f).onComplete += OnCompleteShake;
        }

        private void OnCompleteShake()
        {
            if (_shake.TryMix(out var color))
            {
                OnEndMix?.Invoke(color);
            }
        }
    }
}