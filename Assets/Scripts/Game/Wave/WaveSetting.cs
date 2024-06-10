using System.Collections;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "WaveSetting", menuName = "Data/WaveSetting")]
    public class WaveSetting : ScriptableObject
    {
        [SerializeField] private Vector2Int _spawnRange;

        public Vector2Int GetSpawnRange()
        {
            return _spawnRange;
        }
    }
}