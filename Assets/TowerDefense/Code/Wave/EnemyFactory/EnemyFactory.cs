using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class EnemyFactory : IEnemyFactory, IService
    {
        private readonly Dictionary<Enemy, Pool<Enemy>> _pools = new Dictionary<Enemy, Pool<Enemy>>();
        private readonly List<Enemy> _enemys = new List<Enemy>(25);

        public Enemy CreateEnemy(Enemy enemy, Transform parent = null)
        {
            if(!_pools.ContainsKey(enemy))
            {
                Pool<Enemy> newPool = new Pool<Enemy>(enemy);
                _pools.Add(enemy, newPool);
            }

            Enemy returnEnmy = _pools[enemy].Get();
            _enemys.Add(returnEnmy);
            return returnEnmy;
        }

        public IReadOnlyList<Enemy> GetAllEnemy()
        {
            return _enemys;
        }
    }
}