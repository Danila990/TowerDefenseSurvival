using MyCode.Database;
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
        [SerializeField] private GameDatabase _gameDatabase;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent<IGameDatabase>(_gameDatabase);
            _gameDatabase.Initialize();
            builder.RegisterComponent(_tower);
            builder.RegisterComponent(_tower._stats);
            builder.RegisterComponent(_waveController);
            builder.Register<EnemyLocator>(Lifetime.Singleton);
        }

        private void Start()
        {
            SetupSetting();
        }

        private void SetupSetting()
        {
            Application.targetFrameRate = 60;
        }
    }
}