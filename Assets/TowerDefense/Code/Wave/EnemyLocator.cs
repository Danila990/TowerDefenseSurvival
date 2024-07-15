using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MyCode
{
    public class EnemyLocator
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly Transform _playerBody;

        private IReadOnlyList<Enemy> _enemies = new List<Enemy>();
        private Timer _timer;

        public EnemyLocator(IEnemyFactory enemyFactory, PlayerBody playerBody)
        {
            _enemyFactory = enemyFactory;
            _playerBody = playerBody.transform;
            _timer = new Timer(0.3f);
        }

        public Enemy GetEnemy(float attackRange, int priority)
        {
            Enemy closest = null;
            float closestDistance = Mathf.Infinity;
            foreach (Enemy enemy in _enemies)
            {
                float distanceToEnemy = Vector3.Distance(_playerBody.position, enemy.transform.position);
                bool isInRange = distanceToEnemy <= attackRange;
                bool isCloser = distanceToEnemy < closestDistance;
                if (isInRange && isCloser)
                {
                    closest = enemy;
                    closestDistance = distanceToEnemy;
                }
            }

            return closest;
        }
    }
}