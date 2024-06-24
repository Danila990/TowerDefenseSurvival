using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace TDS
{
    public class WaveController : MonoBehaviour
    {
        private readonly List<EnemySpawnFactory> _spawnFactorys = new List<EnemySpawnFactory>();
        private readonly Vector2 _rangeSpawn = new Vector2(15, 25);
        private EnemySpawnerCreator _enemySpawnerCreator;
        private WaveSetting _wavesSetting;
        private Vector3 _spawnPoint;

        [Inject]
        private void Construct(EnemySpawnerCreator enemySpawnerCreator, PlayerBody playerBody, WaveSetting wavesSetting)
        {
            _enemySpawnerCreator = enemySpawnerCreator;
            _spawnPoint = playerBody.transform.position;
            _wavesSetting = wavesSetting;
        }

        private void Start()
        {
            CreateSpawnFactorys();
        }

        public List<Enemy[]> GetEnemys()
        {
            List<Enemy[]> enemys = new List<Enemy[]>();
            foreach (EnemySpawnFactory factory in _spawnFactorys)
            {
                enemys.Add(factory.GetAllEnemy());
            }
            return enemys;
        }

        public void SetEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPointAroundTower();
            enemy.Activate();
        }

        public void PlayFactorys()
        {
            foreach (EnemySpawnFactory waveEnemyFactory in _spawnFactorys)
            {
                waveEnemyFactory.PlayFactory();
            }
        }

        public void StopFactorys()
        {
            foreach (EnemySpawnFactory waveEnemyFactory in _spawnFactorys)
            {
                waveEnemyFactory.StopFactory();
            }
        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_rangeSpawn.x, _rangeSpawn.y);
            float x = _spawnPoint.x + distance * Mathf.Cos(angle);
            float z = _spawnPoint.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _spawnPoint.y, z);
        }

        private void CreateSpawnFactorys()
        {
            foreach (WaveInfo waveData in _wavesSetting.GetWaveDatas())
            {
                EnemySpawnFactory waveEnemyFactory = _enemySpawnerCreator.CreateFactory(waveData);
                _spawnFactorys.Add(waveEnemyFactory);
            }
        }
    }
}