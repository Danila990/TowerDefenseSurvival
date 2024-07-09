using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyLocator
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly Transform _playerBody;

        private Enemy _closestEnemy;
        private Enemy _farthestEnemy;

        private List<Enemy[]> _enemies = new List<Enemy[]>();
        private Timer _timer;

        public EnemyLocator(IEnemyFactory enemyFactory, PlayerBody playerBody)
        {
            _enemyFactory = enemyFactory;
            _playerBody = playerBody.transform;
            Coroutines.StartRountine(Tick());
            _timer = new Timer(0.3f);
        }

        private IEnumerator Tick()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                UpdateEnemys();
                _farthestEnemy = FindFarthestEnemy();
                _closestEnemy = FindClosestEnemy();
            }
        }

        public bool TryGetClosestEnemy(out Enemy closestEnemy)
        {
            if (_closestEnemy == null)
            {
                closestEnemy = null;
                return false;
            }

            closestEnemy = _closestEnemy;
            return true;
        }

        public bool TryGetfarthestEnemy(out Enemy farthestEnemy)
        {
            if(_farthestEnemy == null)
            {
                farthestEnemy = null;
                return false;
            }

            farthestEnemy = _farthestEnemy;
            return true;
        }

        private Enemy FindClosestEnemy()
        {
            Enemy closestEnemy = null;
            float minDistance = float.MaxValue;

            foreach (Enemy[] enemyArray in _enemies)
            {
                foreach (Enemy enemy in enemyArray)
                {
                    float distanceToPlayer = Vector3.Distance(_playerBody.position, enemy.transform.position);
                    if (distanceToPlayer < minDistance && enemy.gameObject.activeInHierarchy)
                    {
                        minDistance = distanceToPlayer;
                        closestEnemy = enemy;
                    }
                }
            }

            _closestEnemy = closestEnemy;
            return closestEnemy;
        }

        private Enemy FindFarthestEnemy()
        {
            Enemy farthestEnemy = null;
            float maxDistance = 0f;
            foreach (Enemy[] enemyArray in _enemies)
            {
                foreach (Enemy enemy in enemyArray)
                {
                    float distanceToPlayer = Vector3.Distance(_playerBody.position, enemy.transform.position);
                    if (distanceToPlayer > maxDistance && enemy.gameObject.activeInHierarchy)
                    {
                        maxDistance = distanceToPlayer;
                        farthestEnemy = enemy;
                    }
                }
            }

            _farthestEnemy = farthestEnemy;
            return farthestEnemy;
        }

        private void UpdateEnemys()
        {
            if (!_timer.IsTimerEnd)
            {
                return;
            }

            _timer.Start();
            _enemies = _enemyFactory.GetAllEnemy();
        }
    }
}