using System;
using System.Collections;
using UnityEngine;

namespace MyCode
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "MyCode/Wave/WaveData")]
    public class WaveData : ScriptableObject
    {
        [field: SerializeField] public Enemy EnemyPrefab {  get; private set; }
        [field: SerializeField] public WaveConfig WaveConfig { get; private set; }
        [field: SerializeField] public UpgradeWave[] UpgradeWaveItems { get; private set; }
    }
}