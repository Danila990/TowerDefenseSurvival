using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace TD
{
    public class WavesController : MonoBehaviour
    {
        private Vector3 _spawnPoint;
        private WavesSetting _wavesSetting;
        private IObjectPollFactory _pollFactory;
        private List<EnemyFactory> _enemySpawners = new List<EnemyFactory>();

        [Inject]
        private void Construct(WavesSetting wavesSetting, IObjectPollFactory pollFactory, Tower tower)
        {
            _wavesSetting = wavesSetting;
            _pollFactory = pollFactory;
            _spawnPoint = tower.transform.position;
        }

        private void Awake()
        {
            CreateEnemySpawners();
        }

        private void Update()
        {
            foreach (EnemyFactory spawnEnemyFactory in _enemySpawners)
            {
                if (spawnEnemyFactory.IsReadySpawn)
                {
                    Enemy enemy = spawnEnemyFactory.Create();
                    enemy.transform.position = GetRandomPointAroundTower();
                }
            }
        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_wavesSetting._rangeSpawn.x, _wavesSetting._rangeSpawn.y);
            float x = _spawnPoint.x + distance * Mathf.Cos(angle);
            float z = _spawnPoint.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _spawnPoint.y, z);
        }

        private void CreateEnemySpawners()
        {
            foreach (var settingDatas in _wavesSetting._waves)
            {
                _enemySpawners.Add(new EnemyFactory(_pollFactory, settingDatas));
            }
        }
    }
}