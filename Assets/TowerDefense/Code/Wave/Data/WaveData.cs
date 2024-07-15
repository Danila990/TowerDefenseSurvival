using System;
using System.Collections;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public class WaveData
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private WaveConfig _waveConfig;

        public Enemy EnemyPrefab => _enemyPrefab;
        public WaveConfig WaveConfig => _waveConfig;
    }
}