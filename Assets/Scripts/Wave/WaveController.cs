using UnityEngine;
using Random = UnityEngine.Random;
using VContainer;

namespace MyCode
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private Vector2 _rangeSpawn = new Vector2(15, 25);
        [SerializeField] private WaveContainer _waveContainer;

        private WaveFactory[] _waveFactoryArray;
        private Vector3 _spawnPoint;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(IObjectResolver objectResolver, Tower tower)
        {
            _objectResolver = objectResolver;
            _spawnPoint = tower.transform.position;
        }

        private void Start()
        {
            CreateFactorys();
        }

        private void CreateFactorys()
        {
            WaveData[] waveDatas = _waveContainer.GetWaveDatas();
            _waveFactoryArray = new WaveFactory[waveDatas.Length];
            for (int i = 0; i < waveDatas.Length; i++)
            {
                InjectPool<Enemy> injectPool = new InjectPool<Enemy>(waveDatas[i].EnemyPrefab, _objectResolver);
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