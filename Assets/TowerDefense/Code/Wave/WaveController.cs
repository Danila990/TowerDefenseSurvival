using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace TowerDefense
{
    public class WaveController
    {
        private readonly List<EnemySpawner> _spawnFactorys = new List<EnemySpawner>();
        private readonly Vector2 _rangeSpawn = new Vector2(15, 25);
        private IEnemyFactory _enemyFactory;
        private WaveContainer _waveContainer;
        private Vector3 _spawnEnemyPoint;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory, PlayerBody playerBody, WaveContainer waveContainer)
        {
            _enemyFactory = enemyFactory;
            _spawnEnemyPoint = playerBody.transform.position;
            _waveContainer = waveContainer;
            CreateSpawnFactorys();
        }

        public void SetEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPointAroundTower();
            enemy.Activate();
        }

        public void PlaySpawners()
        {
            foreach (EnemySpawner waveEnemyFactory in _spawnFactorys)
            {
                waveEnemyFactory.PlayFactory();
            }
        }

        public void StopSpawners()
        {
            foreach (EnemySpawner waveEnemyFactory in _spawnFactorys)
            {
                waveEnemyFactory.StopFactory();
            }
        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_rangeSpawn.x, _rangeSpawn.y);
            float x = _spawnEnemyPoint.x + distance * Mathf.Cos(angle);
            float z = _spawnEnemyPoint.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _spawnEnemyPoint.y, z);
        }

        private void CreateSpawnFactorys()
        {
            foreach (WaveData waveData in _waveContainer.GetWaveDatas())
            {
                EnemySpawner enemySpawner = new EnemySpawner(waveData, this, _enemyFactory);
                _spawnFactorys.Add(enemySpawner);
            }
        }
    }
}