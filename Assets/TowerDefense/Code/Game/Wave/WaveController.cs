using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace Code.TowerDefense
{
    public class WaveController : MonoBehaviour
    {
        private readonly List<WaveEnemyFactory> _waveFactorys = new List<WaveEnemyFactory>();
        private WaveFactoryCreator _waveFactoryCreator;
        private WavesSetting _wavesSetting;
        private Vector2 _rangeSpawn;
        private Vector3 _spawnPoint;

        [Inject]
        private void Construct(WaveFactoryCreator waveFactoryCreator, Player player, WavesSetting wavesSetting)
        {
            _waveFactoryCreator = waveFactoryCreator;
            _spawnPoint = player.transform.position;
            _wavesSetting = wavesSetting;
            _rangeSpawn = wavesSetting._rangeSpawn;
        }

        private void Awake()
        {
            CreateFactorys();
            StartFactorys();
        }

        public void SetEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPointAroundTower();
            enemy.Activate();
        }

        public void StartFactorys()
        {
            foreach (WaveEnemyFactory waveEnemyFactory in _waveFactorys)
            {
                waveEnemyFactory.StartFactory();
            }
        }

        public void PlayFactorys()
        {
            foreach (WaveEnemyFactory waveEnemyFactory in _waveFactorys)
            {
                waveEnemyFactory.PlayFactory();
            }
        }

        public void StopFactorys()
        {
            foreach (WaveEnemyFactory waveEnemyFactory in _waveFactorys)
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

        private void CreateFactorys()
        {
            foreach (WaveData waveData in _wavesSetting.GetWaveDatas())
            {
                WaveEnemyFactory waveEnemyFactory = _waveFactoryCreator.CreateFactory(waveData, this);
                _waveFactorys.Add(waveEnemyFactory);
            }
        }
    }
}