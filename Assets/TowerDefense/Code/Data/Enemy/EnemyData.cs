using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "TowerDefense/Prefab/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private EnemyConfig _config;

        public EnemyConfig Config => _config;
        public Enemy Prefab => _prefab;
    }
}