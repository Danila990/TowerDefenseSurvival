using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner
    {
        private readonly WaveController _waveController;
        private readonly IEnemyFactory _enemyFactory;
        private readonly WaveData _waveData;
        private Coroutine _spawnCoroutine;
        private bool _isStartFactory = false;

        public EnemySpawner(WaveData waveData, WaveController wavesController, IEnemyFactory enemyFactory)
        {
            _waveData = waveData;
            _waveController = wavesController;
            _enemyFactory = enemyFactory;
            Coroutines.StartRountine(StartFactoryCoroutine());
        }

        public void PlayFactory()
        {
            if (!_isStartFactory)
            {
                throw new System.Exception("Factory not started");
            }

            StopSpawnCoroutine();
            _spawnCoroutine = Coroutines.StartRountine(EnemySpawnCoroutine());
        }

        public void StopFactory()
        {
            if (!_isStartFactory)
            {
                throw new System.Exception("Factory not started");
            }

            StopSpawnCoroutine();
        }

        private void StopSpawnCoroutine()
        {
            Coroutines.StopRountine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        private IEnumerator StartFactoryCoroutine()
        {
            yield return new WaitForSeconds(_waveData.WaveConfig.StartAwaitTime);
            _isStartFactory = true;
            PlayFactory();
        }

        private IEnumerator EnemySpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_waveData.WaveConfig.SpawnDelay);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.CreateEnemy(_waveData.EnemyData.Prefab);
            enemy.SetConfig(_waveData.EnemyData.Config);
            _waveController.SetEnemy(enemy);
        }
    }
}