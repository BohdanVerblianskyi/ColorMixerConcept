using System;
using _Project._Scripts.Extension;
using DG.Tweening;
using UnityEngine;


namespace _Project._Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Product : MonoBehaviour, IProduct,IForBlander
    {
        private const float DurationCoefficient = 2f;
        
        [SerializeField] private Material _maiaMaterial;
        [SerializeField] private Blander _blander;

        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        public Color Color => _maiaMaterial.color;

        private void JumpToBlander()
        {
            OnStartFly.Invoke();
            _rigidbody.isKinematic = false;
            var duration = transform.position.Duration(_blander.Position, DurationCoefficient);
            transform.DOJump(_blander.Position, 1, 1, 1);
        }

        private void OnMouseDown()
        {
            JumpToBlander();
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public Action OnStartFly { get; set; }
    }

    
}