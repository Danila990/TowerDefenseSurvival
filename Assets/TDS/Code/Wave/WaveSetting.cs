using System;
using UnityEngine;

namespace TDS
{
    [CreateAssetMenu(fileName = "WaveSetting", menuName = "TDS/WaveSetting")]
    public class WaveSetting : ScriptableObject
    {
        [SerializeField] private WaveInfo[] _waveDatas;

        public WaveInfo[] GetWaveDatas()
        {
            return _waveDatas;
        }
    }

    [Serializable]
    public class WaveInfo
    {
        [field: SerializeField] public Enemy _enemyPrefab { get; private set; }
        [field: SerializeField] public int _rangeStartPoll { get; private set; }
        [field: SerializeField] public WaveConfig _waveConfig{ get; private set; }
    }

    [Serializable]
    public struct WaveConfig
    {
        public float StartAwaitTime;
        public float SpawnDelay;
    }
}