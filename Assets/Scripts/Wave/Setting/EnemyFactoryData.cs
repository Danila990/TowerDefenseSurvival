using System;
using UnityEngine;

namespace TD
{
    [Serializable]
    public class EnemyFactoryData
    {
        [field: SerializeField] public Enemy _enemyPrefab { get; private set; }

        public float TimeToStart = 0;
        public float TimeToStop = 300f;
        public float SpawnDelay = 1f;
    }
}