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

        public void Construct(IEnumerable<IForBlander> forBlenders, IButton button)
        {
            _cover.Construct(forBlenders);
            button.OnClick += Play;
            _shake.Construct();
        }

        public Action<Color> OnEndMix { get; set; }

        public Vector3 Position => _shake.Position;

        private void Play()
        {
            transform.DOShakeRotation(2f, 2f).onComplete += OnCompleteMix;
        }

        private void OnCompleteMix()
        {
            var color = _shake.ToMix();
            OnEndMix?.Invoke(color);
        }
    }
}