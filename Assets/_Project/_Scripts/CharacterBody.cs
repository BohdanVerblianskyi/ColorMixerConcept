using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts
{
    public class CharacterBody : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private List<Mesh> _meshes;

        private void Awake()
        {
            _skinnedMeshRenderer.sharedMesh = _meshes[Random.Range(0, _meshes.Count - 1)];
        }
    }
}