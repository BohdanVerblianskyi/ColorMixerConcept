using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project._Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Image _wishImige;
        [SerializeField] private GameObject _cloud;
        [SerializeField] private Transform _body;

        public void Construct(Sprite wish)
        {
            _cloud.SetActive(false);
            MoveToTable();
            _wishImige.sprite = wish;
        }

        private void MoveToTable()
        {
            _body.DOMove(transform.position, 1f).onComplete += ShowClaud;
        }

        private void ShowClaud()
        {
            _cloud.SetActive(true);
        }
    }
}