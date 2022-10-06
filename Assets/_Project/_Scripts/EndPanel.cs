using System;
using System.Globalization;
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

        private void Show(Color actual)
        {
            _panel.SetActive(true);
            _actual.color = actual;
            _wishful.color = _wishfulColor;
            _text.text = CompareColors(actual, _wishfulColor).ToString(CultureInfo.InvariantCulture);
        }

        private int CompareColors(Color colorA, Color colorB)
        {
            var red = Mathf.Abs(colorA.r - colorB.r);
            var green = Mathf.Abs(colorA.g - colorB.g);
            var blue = Mathf.Abs(colorA.b - colorB.b);

            var deltaColor = 0f;
            deltaColor += Mathf.Sqrt(red * red + green * green);
            deltaColor += Mathf.Sqrt(green * green + blue * blue);
            deltaColor += Mathf.Sqrt(blue * blue + red * red);
            deltaColor /= 3f;

            return (int)Math.Round(((1f - deltaColor) * 100f));
        }
    }
}