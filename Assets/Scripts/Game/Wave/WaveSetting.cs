using System.Collections;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "WaveSetting", menuName = "Data/WaveSetting")]
    public class WaveSetting : ScriptableObject
    {
        [SerializeField] private Vector2Int spawnRange;

        public Vector2Int GetSpawnRange()
        {
            return spawnRange;
        }
    }
}