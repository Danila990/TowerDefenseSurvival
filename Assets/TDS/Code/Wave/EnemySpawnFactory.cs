using System.Collections;
using UnityEngine;

namespace TDS
{
    public class EnemySpawnFactory
    {
        private readonly Pool<Enemy> _poolEnemy;
        private readonly WaveController _waveController;
        private readonly WaveConfig _waveConfig;
        private Coroutine _spawnCoroutine;
        private bool _isStartFactory = false;

        public EnemySpawnFactory(WaveConfig waveConfig, Pool<Enemy> pollEnemy, WaveController wavesController)
        {
            _waveConfig = waveConfig;
            _waveController = wavesController;
            _poolEnemy = pollEnemy;
            _waveController.StartCoroutine(StartFactoryCoroutine());
        }

        public Enemy[] GetAllEnemy()
        {
            return _poolEnemy.GetAll();
        }

        public void PlayFactory()
        {
            if (!_isStartFactory)
            {
                throw new System.Exception("Factory not started");
            }

            StopSpawnCoroutine();
            _spawnCoroutine = _waveController.StartCoroutine(EnemySpawnCoroutine());
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
            if (_spawnCoroutine != null)
            {
                _waveController.StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator StartFactoryCoroutine()
        {
            yield return new WaitForSeconds(_waveConfig.StartAwaitTime);
            _isStartFactory = true;
            PlayFactory();
        }

        private IEnumerator EnemySpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_waveConfig.SpawnDelay);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _poolEnemy.Get();
            _waveController.SetEnemy(enemy);
        }
    }
}