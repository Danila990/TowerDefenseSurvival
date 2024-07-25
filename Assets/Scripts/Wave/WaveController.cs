using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace MyCode
{
    public class WaveController : IInitializable
    {
        private readonly Vector2 _rangeSpawn = new Vector2(15, 25);
        private readonly Vector3 _spawnPoint;
        private readonly WaveContainer _waveContainer;
        private readonly DiContainer _diContainer;
        private WaveFactory[] _waveFactoryArray;

        public WaveController(DiContainer diContainer, Tower tower, WaveContainer waveContainer)
        {
            _diContainer = diContainer;
            _waveContainer = waveContainer;
            _spawnPoint = tower.transform.position;
        }

        public void Initialize()
        {
            CreateFactorys();
        }

        private void CreateFactorys()
        {
            WaveData[] waveDatas = _waveContainer.GetWaveDatas();
            _waveFactoryArray = new WaveFactory[waveDatas.Length];
            for (int i = 0; i < waveDatas.Length; i++)
            {
                InjectPool<Enemy> injectPool = new InjectPool<Enemy>(waveDatas[i].EnemyPrefab, _diContainer);
                _waveFactoryArray[i] = new WaveFactory(injectPool, waveDatas[i].WaveConfig, waveDatas[i].UpgradeWaveItems);
                _waveFactoryArray[i].OnCreateEnemy += SpawnEnemy;
            }
        }

        private void SpawnEnemy(Enemy enemy)
        {
            enemy.transform.position = GetRandomPointAroundTower();
        }

        private Vector3 GetRandomPointAroundTower()
        {
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(_rangeSpawn.x, _rangeSpawn.y);
            float x = _spawnPoint.x + distance * Mathf.Cos(angle);
            float z = _spawnPoint.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _spawnPoint.y, z);
        }

        private void OnDisable()
        {
            foreach (var waveFactory in _waveFactoryArray)
            {
                waveFactory.OnCreateEnemy -= SpawnEnemy;
                waveFactory.Dispose();
            }
        }
    }
}