using UnityEngine;

namespace _Project._Scripts
{
    public class Blander : MonoBehaviour
    {
        [SerializeField] private Transform _center;
        
        public Vector3 Position => _center.position;
    }
}