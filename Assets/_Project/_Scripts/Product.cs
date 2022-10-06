using System;
using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Product : MonoBehaviour, IProduct, IForBlander
    {
        [SerializeField] private Material _maiaMaterial;

        public Action OnStartJump { get; set; }
        
        private Rigidbody _rigidbody;
        private Vector3 _fallPosition;

        public void Construct(Vector3 fallPosition)
        {
            _fallPosition = fallPosition;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        public Color Color => _maiaMaterial.color;

        private void JumpToBlander()
        {
            OnStartJump?.Invoke();
            _rigidbody.isKinematic = false;
            transform.DOJump(_fallPosition, 1, 1, 1);
        }

        private void OnMouseDown()
        {
            JumpToBlander();
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

      
    }
}