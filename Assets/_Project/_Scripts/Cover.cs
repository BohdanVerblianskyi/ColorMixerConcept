using System.Collections;
using System.Collections.Generic;
using _Project._Scripts.Extension;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class Cover : MonoBehaviour
    {
        [SerializeField] private Transform _pointWhereMove;
        [SerializeField, Range(0, 1)] private float _time; 
        [SerializeField] private float _duration = 2;
        
        private bool _isOpen;
        private Vector3 _startPosition;

        public void Construct(IEnumerable<IForBlander> forBlenders)
        {
            foreach (var forBlender in forBlenders)
            {
                forBlender.OnStartFly += Open;
            }
        }
        
        public void Awake()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Open();
            }
            if (Input.GetMouseButtonDown(1))
            {
                Close();
            }
        }
        
        private void Open()
        {
            var endPosition = _pointWhereMove.position;

            var duration = transform.position.Duration(endPosition, _duration);
            transform.DOMove(endPosition, duration).onComplete += Close;
        }

        private void Close()
        {
            var duration = transform.position.Duration(_startPosition, _duration);
            
            DOTween.Sequence()
                .Append(transform.DOMove(_startPosition, duration));
        }

        
    }
}
