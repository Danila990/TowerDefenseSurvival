using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public interface IEnemyFactory
    {
        public Enemy CreateEnemy(Enemy enemy, Vector3 position);
        public IReadOnlyList<Enemy> GetAllEnemy();
    }
}