using System;
using UnityEngine;

namespace Code.TowerDefense
{
    [CreateAssetMenu(fileName = "WavesSetting", menuName = "TowerDefense/WavesSetting")]
    public class WavesSetting : ScriptableObject
    {
        [SerializeField] private WaveData[] _waveDatas;
        [field: SerializeField] public Vector2 _rangeSpawn { get; private set; } = new Vector2Int(25, 35);

        public WaveData[] GetWaveDatas()
        {
            return _waveDatas;
        }
    }

    [Serializable]
    public class WaveData
    {
        [field: SerializeField] public Enemy _enemyPrefab { get; private set; }
        [field: SerializeField] public float _startDelay { get; private set; }  = 0;
        [field: SerializeField] public float _waveDuration { get; private set; } = 300f;
        [field: SerializeField] public float _spawnDelay { get; private set; } = 1f;
    }
}