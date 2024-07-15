
namespace MyCode
{
    public class EnemySpawner
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly WaveData _waveData;
        private Timer _spawnTimer;
        private bool _isAwaitTime = true;

        public EnemySpawner(WaveData waveData , IEnemyFactory enemyFactory)
        {
            _waveData = waveData;
            _enemyFactory = enemyFactory;
            _spawnTimer = new Timer(waveData.WaveConfig.StartAwaitTime, true);
            _isAwaitTime = true;
        }

        public bool CheckSpawn()
        {
            if (_isAwaitTime)
            {
                if (_spawnTimer.IsTimerEnd)
                {
                    _isAwaitTime = false;
                    _spawnTimer = new Timer(_waveData.WaveConfig.SpawnDelay);
                }
            }
            else
            {
                if (_spawnTimer.IsTimerEnd)
                {
                    return true;
                }
            }

            return false;
        }

        public Enemy SpawnEnemy()
        {
            _spawnTimer.Start();
            Enemy enemy = _enemyFactory.CreateEnemy(_waveData.EnemyPrefab);
            return enemy;
        }
    }
}