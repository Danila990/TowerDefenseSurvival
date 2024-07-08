using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TowerDefense
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer _diContainer;
        private Dictionary<Enemy, InjectPool<Enemy>> _pools = new Dictionary<Enemy, InjectPool<Enemy>>();

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Enemy CreateEnemy(Enemy enemy, Transform parent = null)
        {
            if(!_pools.ContainsKey(enemy))
            {
                InjectPool<Enemy> newPool = new InjectPool<Enemy>(enemy, _diContainer);
                _pools.Add(enemy, newPool);
            }

            return _pools[enemy].Get();
        }
    }
}