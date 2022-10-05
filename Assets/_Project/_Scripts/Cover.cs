using DG.Tweening;
using UnityEngine;

namespace _Project._Scripts
{
    public class Cover : MonoBehaviour
    {
        [SerializeField] private Transform _pointWhereMove;
        [SerializeField, Range(0, 1)] private float _time; 
        
        private bool _isOpen;
        private Vector3 _startPosition;
        
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
            var position = _pointWhereMove.position;
            var duration = GetDuration(position);
            
            DOTween.Sequence()
                .Append(transform.DOMove(position, duration))
                .Join(transform.DORotate(new Vector3(45f, 0f, 0f), duration));
        }

        private void Close()
        {
            var duration = GetDuration(_startPosition);
            DOTween.Sequence()
                .Append(transform.DOMove(_startPosition, duration))
                .Join(transform.DORotate(new Vector3(0f, 0f, 0f), duration));
        }

        private float GetDuration(Vector3 position)
        {
            const float coefficient = 2f;
            return Vector3.Distance(transform.position, position) * coefficient;
        }
    }
}
