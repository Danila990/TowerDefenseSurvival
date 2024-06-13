using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TD
{
    [CreateAssetMenu(fileName = "EnemyDataContainer", menuName = "Database/Enemy/EnemyDataContainer")]
    public class EnemyDataContainer : ScriptableObject
    {
        [SerializeField] private EnemyData[] _enemyDatas;

        public EnemyData GetEnemyData(EnemyType enemyType)
        {
            foreach (EnemyData data in _enemyDatas)
            {
                if (data._enemyType.Equals(enemyType))
                {
                    return Instantiate(data);
                }
            }

            throw new NullReferenceException($"Get data: {enemyType} is null");
        }

        public EnemyData[] GetEnemyData(EnemyType[] enemyType)
        {
            EnemyData[] enemyDatas = new EnemyData[enemyType.Length];
            for (int i = 0; i < enemyDatas.Length; i++)
            {
                enemyDatas[i] = GetEnemyData(enemyType[i]);
            }

            return enemyDatas;
        }
    }

    [CreateAssetMenu(fileName = "EnemyData", menuName = "Database/Enemy/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private AssetReferenceGameObject _referencePrefab;
        [SerializeField] private EnemyStats _enemyStats;

        [field: SerializeField] public EnemyType _enemyType { get; private set; }

        public async Task<Enemy> GetPrefab()
        {
            return await AddressablesLoader.Load<Enemy>(_referencePrefab);
        }

        public EnemyStats GetStats()
        {
            return _enemyStats;
        }
    }
}