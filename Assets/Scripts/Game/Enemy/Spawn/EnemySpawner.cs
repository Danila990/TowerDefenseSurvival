using UnityEngine;
using Zenject;

namespace TD
{
    public class EnemySpawner
    {
        private EnemySpawnData _enemySpawnData;
        private Vector3 _center;

        public EnemySpawner(EnemySpawnData enemySpawnData)
        {
            _enemySpawnData = enemySpawnData;
        }

        [Inject]
        private void Construct(EnemySpawnData enemySpawnData, Tower tower)
        {
            _enemySpawnData = enemySpawnData;
            _center = tower.transform.position;
        }

        public void SpawnObject()
        {

        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_enemySpawnData._spawnRange.x, _enemySpawnData._spawnRange.y);
            float x = _center.x + distance * Mathf.Cos(angle);
            float z = _center.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _center.y, z);
        }
    }

    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Data/EnemySpawnData")]
    public class EnemySpawnData : ScriptableObject
    {
        [field: SerializeField] public Vector2Int _spawnRange { get; private set; }
    }
}