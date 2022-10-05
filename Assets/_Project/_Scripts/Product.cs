using System;
using DG.Tweening;
using UnityEngine;


namespace _Project._Scripts
{
    public class Product : MonoBehaviour, IProduct
    {
        [SerializeField] private Material _maiaMaterial;
        [SerializeField] private Blander _blander;
        [SerializeField] private float _duration;

        public Color Color => _maiaMaterial.color;

        private void JumpToBlander()
        {
            transform.DOJump(_blander.Position, 1, 1, _duration);
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