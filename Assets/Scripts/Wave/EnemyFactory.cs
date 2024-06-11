using System;

namespace TD
{
    public class EnemyFactory
    {
        private readonly ZenjectPool<Enemy> _enemyPoll;
        private Timer _spawnTimer;
        private Timer _startTimer;
        private Timer _endTimer;

        public bool IsReadySpawn => _spawnTimer.IsTimerEnd && _startTimer.IsTimerEnd && !_endTimer.IsTimerEnd;

        public EnemyFactory(IObjectPollFactory objectPollFactory, EnemyFactoryData factoryData)
        {
            _enemyPoll = objectPollFactory.CreateZenjectPoll(factoryData._enemyPrefab);
            _spawnTimer = new Timer(factoryData.SpawnDelay);
            _startTimer = new Timer(factoryData.TimeToStart, true);
            _endTimer = new Timer(factoryData.TimeToStop, true);
        }

        public Enemy Create()
        {
            if (!IsReadySpawn)
            {
                throw new Exception($"Not ready to spawn enemy");
            }

            _spawnTimer.Start();
            return _enemyPoll.Create();
        }
    }
}