using System.Collections;
using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class WaveEnemyFactory
    {
        private readonly WaveData _waveData;
        private readonly ZenjectPool<Enemy> _poolEnemy;
        private readonly WaveController _waveController;
        private Timer _endTimer;
        private bool _isStartFactory = false;

        public WaveEnemyFactory(DiContainer diContainer, WaveData waveData, WaveController wavesController)
        {
            _waveController = wavesController;
            _waveData = waveData;
            _poolEnemy = new ZenjectPool<Enemy>(_waveData._enemyPrefab, diContainer);
        }

        public void StartFactory()
        {
            if(_isStartFactory)
            {
                throw new System.Exception("The factory settings are already running");
            }

            _poolEnemy.CreateStartPool(1);
            _waveController.StartCoroutine(StartFactoryCoroutine());
            _isStartFactory = true;
        }

        public void PlayFactory()
        {
            if (!_isStartFactory)
            {
                throw new System.Exception("Factory not started");
            }

            _waveController.StartCoroutine(EnemySpawnCoroutine());
        }

        public void StopFactory()
        {
            if (!_isStartFactory)
            {
                throw new System.Exception("Factory not started");
            }

            _waveController.StopAllCoroutines();
        }

        private IEnumerator StartFactoryCoroutine()
        {
            yield return new WaitForSeconds(_waveData._startDelay);
            _endTimer = new Timer(_waveData._waveDuration, true);
            PlayFactory();
        }

        private IEnumerator EnemySpawnCoroutine()
        {
            while (!_endTimer.IsTimerEnd)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_waveData._spawnDelay);
            }

            yield return null;
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _poolEnemy.Get();
            _waveController.SetEnemy(enemy);
        }
    }
}