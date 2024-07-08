using UnityEngine;

namespace TowerDefense
{
    public interface IEnemyFactory
    {
        public Enemy CreateEnemy(Enemy enemy, Transform parent = null);
    }
}