using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "TowerDefense/Wave/WaveData")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private WaveConfig _waveConfig;

        public EnemyData EnemyData => _enemyData;
        public WaveConfig WaveConfig => _waveConfig;
    }
}