using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Blander _blander;
        [SerializeField] private EndPanel _endPanel;
        [SerializeField] private MixButton _button;
        [SerializeField] private List<Product> _proudcts;
        [SerializeField] private Wish _wish;
        [SerializeField] private Character _character;

        private void Start()
        {
            _proudcts.ForEach(p => p.Construct(_blander.Position));
            _blander.Construct(_proudcts, _button);
            _character.Construct(_wish.WishfulColor.Sprite);
            _endPanel.Construct(_wish.WishfulColor.Color, _blander);

            var game = new Game(_endPanel, _wish);
        }
    }
}