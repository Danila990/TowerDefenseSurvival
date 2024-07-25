using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class Bootstrap : LifetimeScope
    {
        [Header("Bootstrap")]
        [SerializeField] private AssetReferenceGameObject _referenceTower;

        private Tower _tower;
        private WaveController _waveController;

        protected override async void Awake()
        {
            autoRun = false;
            base.Awake();

            _tower = await AssetLoader.Load<Tower>(_referenceTower);
            _waveController = GetComponent<WaveController>();
            SetupSetting();
            Build();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_tower);
            builder.RegisterComponent(_tower._stats);
            builder.RegisterComponent(_waveController);
            builder.Register<EnemyLocator>(Lifetime.Singleton);
        }

        private void SetupSetting()
        {
            Application.targetFrameRate = 60;
        }
    }
}