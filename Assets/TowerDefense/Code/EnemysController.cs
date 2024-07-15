using System;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public class EnemysController
    {
        [SerializeField] private WaveController _waveController;

        private EnemyFactory _enemyFactory;
        private EnemyLocator _enemyLocator;

        public void Init()
        {
            PlayerBody playerBody = ServiceLocator.Instance.Get<PlayerBody>();
            _waveController.Init(_enemyFactory, playerBody);
            _enemyLocator = new EnemyLocator(_enemyFactory, playerBody);
        }

        public void Update()
        {
            _waveController.Update();
        }

        public void RegisterServices(ServiceLocator serviceLocator)
        {
            _enemyFactory = new EnemyFactory();
            serviceLocator.Register(_enemyFactory);
        }
    }
}
