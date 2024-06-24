using Zenject;

namespace TDS
{
    public class EnemySpawnerCreator
    {
        private readonly DiContainer _diContainer;
        private readonly WaveController _waveController;

        public EnemySpawnerCreator(DiContainer diContainer, WaveController waveController)
        {
            _diContainer = diContainer;
            _waveController = waveController;
        }

        public EnemySpawnFactory CreateFactory(WaveInfo waveData)
        {
            InjectPool<Enemy> pollEnemy = 
                new InjectPool<Enemy>(waveData._enemyPrefab, _diContainer, waveData._rangeStartPoll);
            return new EnemySpawnFactory(waveData._waveConfig, pollEnemy, _waveController);
        }
    }
}