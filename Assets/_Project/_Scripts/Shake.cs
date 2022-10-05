using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project._Scripts
{
    public class Shake : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        private List<IProduct> _mixProducts = new List<IProduct>();
        
        public Color ToMix()
        {
            var result = MixColor(_mixProducts.Select(p => p.Color));
            _mixProducts.ForEach(p => p.TurnOff());
            _renderer.material.color = result;
            return result;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IProduct product))
            {
                _mixProducts.Add(product);
            }
        }

        private Color MixColor(IEnumerable<Color> colors)
        {
            var r = colors.Select(c => c.r).Average();
            var g = colors.Select(c => c.g).Average();
            var b = colors.Select(c => c.b).Average();
            return new Color(r, g, b);
        }
    }
}