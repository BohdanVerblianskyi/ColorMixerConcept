using System;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class MixButton : MonoBehaviour,IButton
    {
        [SerializeField] private Transform _clickPoint;
    
        public Action OnClick { get; set;}
    
        private bool _isClick;
        private Vector3 _startPosition;
        private Vector3 _clickPosition;

        private void Awake()
        {
            _startPosition = transform.position;
            _clickPosition = _clickPoint.position;
        }

        private void OnMouseDown()
        {
            const float duration = 0.4f;
            Debug.Log(1);
            transform.DOMove(_clickPosition, duration).onComplete += OnCompleteClick;
        }

        private void OnCompleteClick()
        {
            const float duration = 0.4f;
            OnClick?.Invoke();
            transform.DOMove(_startPosition, duration);
        }
    }
}