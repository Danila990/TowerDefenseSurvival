using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

namespace MyCode
{
    [Serializable]
    public class WaveController
    {
        [SerializeField] private readonly Vector2 _rangeSpawn = new Vector2(15, 25);
        [SerializeField] private WaveContainer _waveContainer;

        private EnemySpawner[] _spawnFactorys;
        private Tower _playerBody;
        private bool _isSpawned = false;

        public void Init(IEnemyFactory enemyFactory, Tower playerBody)
        {
            _playerBody = playerBody;
            CreateSpawnFactorys(enemyFactory);
            _isSpawned = true;
        }

        public void Update()
        {
            if (!_isSpawned)
            {
                return;
            }

            foreach (EnemySpawner enemySpawner in _spawnFactorys)
            {
                if (enemySpawner.CheckSpawn())
                {
                    SpawnEnemy(enemySpawner.SpawnEnemy());
                }
            }
        }

        public void ChangeSpawnState(bool isSpawned)
        {
            _isSpawned = isSpawned;
        }

        private void SpawnEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPointAroundTower();
            enemy.Init(_playerBody);
            enemy.Activate();
        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_rangeSpawn.x, _rangeSpawn.y);
            float x = _playerBody.transform.position.x + distance * Mathf.Cos(angle);
            float z = _playerBody.transform.position.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _playerBody.transform.position.y, z);
        }

        private void CreateSpawnFactorys(IEnemyFactory enemyFactory)
        {
            WaveData[] waveDatas = _waveContainer.GetWaveDatas();
            _spawnFactorys = new EnemySpawner[waveDatas.Length];
            for (int i = 0; i < waveDatas.Length; i++)
            {
                _spawnFactorys[i] = new EnemySpawner(waveDatas[i], enemyFactory);
            }
        }
    }
}