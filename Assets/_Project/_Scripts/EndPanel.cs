using System;
using System.Globalization;
using System.Threading.Tasks;
using _Project._Scripts.Extension;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project._Scripts
{
    public class EndPanel : MonoBehaviour, IEndPanel
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _actual;
        [SerializeField] private Image _wishful;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonRestart;

        public Action OnNext { get; set; }
        public Action OnRestart { get; set; }

        private Color _wishfulColor;

        public void Construct(Color wishful, IBlender blender)
        {
            _buttonNext.onClick.AddListener(() => OnNext?.Invoke());
            _buttonRestart.onClick.AddListener(() => OnRestart?.Invoke());

            _wishfulColor = wishful;
            blender.OnEndMix += Show;
        }

        private async void Show(Color actual)
        {
            await Task.Delay(1000);
            _panel.SetActive(true);
            _actual.color = actual;
            _wishful.color = _wishfulColor;
            var percentageOfStairs = actual.PercentageOfStairs(_wishfulColor);

            const int minPercentageOfStairs = 90;
            if (percentageOfStairs < minPercentageOfStairs)
            {
                _buttonNext.gameObject.SetActive(false);
            }
            
            _text.text = percentageOfStairs.ToString(CultureInfo.InvariantCulture);
        }
    }
}