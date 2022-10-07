using System;
using System.Collections.Generic;
using _Project._Scripts.Extension;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class Cover : MonoBehaviour
    {
        [SerializeField] private Transform _pointWhereMove;
        [SerializeField] private float _duration = 2;

        private float _closeTime;
        private bool _isOpen;
        private Vector3 _startPosition;

        public void Construct(IEnumerable<IForBlander> forBlenders)
        {
            foreach (var forBlender in forBlenders)
            {
                forBlender.OnStartJump += Open;
            }

            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_isOpen && _closeTime < Time.time)
            {
                Close();
                _isOpen = false;
            }
        }

        private void Open()
        {
            const float waitClose = 1f;
            
            _closeTime = Time.time + waitClose;

            if (_isOpen)
            {
                return;
            }

            _isOpen = true;

            var endPosition = _pointWhereMove.position;

            var duration = transform.position.Duration(endPosition, _duration);
            transform.DOMove(endPosition, duration);
        }
        
        private void Close()
        {
            var duration = transform.position.Duration(_startPosition, _duration);
            transform.DOMove(_startPosition, duration);
        }
    }
}