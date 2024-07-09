using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public interface IEnemyFactory
    {
        public Enemy CreateEnemy(Enemy enemy, Transform parent = null);
        public List<Enemy[]> GetAllEnemy();
    }
}