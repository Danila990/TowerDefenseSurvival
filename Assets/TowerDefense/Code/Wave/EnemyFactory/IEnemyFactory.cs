using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public interface IEnemyFactory
    {
        public Enemy CreateEnemy(Enemy enemy, Transform parent = null);
        public IReadOnlyList<Enemy> GetAllEnemy();
    }
}