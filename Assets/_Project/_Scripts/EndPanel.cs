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

        private int CompareColors(Color a, Color b)
        {
            var red = Mathf.Abs(a.r - b.r);
            var green = Mathf.Abs(a.g - b.g);
            var blue = Mathf.Abs(a.b - b.b);

            var deltaColor = 0f;
            deltaColor += DeltaColor(red, green);
            deltaColor += DeltaColor(green, blue);
            deltaColor += DeltaColor(blue, red);
            deltaColor /= 3f;

            return (int)Math.Round(((1f - deltaColor) * 100f));
        }

        private static float DeltaColor(float a, float b)
        {
            return Mathf.Sqrt(a * a + b * b);
        }
    }
}