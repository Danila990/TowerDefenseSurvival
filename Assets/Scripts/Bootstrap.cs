using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class Bootstrap : LifetimeScope
    {
        [Header("Bootstrap")]
        [SerializeField] private Tower _tower;
        //[SerializeField] private PlayerAbility _playerAbility;
        [SerializeField] private WaveController _waveController;

        private EnemyFactory _enemyFactory;
        private EnemyLocator _enemyLocator;
        private ServiceLocator _serviceLocator;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_tower);
            builder.RegisterComponent(_tower._stats);
            builder.RegisterComponent<IEnemyFactory>(_enemyFactory);
        }

        private void Start()
        {
            SetupSetting();
            Create();
        }

        private void Update()
        {
            _waveController.Update();
        }

        private void SetupSetting()
        {
            Application.targetFrameRate = 60;
        }

        private void Create()
        {
            //_enemyLocator = new EnemyLocator(_enemyFactory, _playerBody);
            _enemyFactory = new EnemyFactory();
        }
    }
}