using MyCode;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameBootstrapInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private Transform _towerPoint;
    [SerializeField] private AssetReferenceGameObject _referenceTower;
    [SerializeField] private AssetReferenceScriptableObject _referenceWaveContainer;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameBootstrapInstaller>().FromInstance(this).AsSingle();
        BindTower();
        BindWave();
        Container.Bind<EnemyLocator>().FromNew().AsSingle();
    }

    public async void Initialize()
    {
        await Task.Delay(1000);
        SetupSetting();
        var waveController = Container.Resolve<WaveController>();
        waveController.Initialize();
    }

    private void SetupSetting()
    {
        Application.targetFrameRate = 60;
    }

    private async void BindWave()
    {
        WaveContainer waveContainer = await AssetLoader.Load<WaveContainer>(_referenceWaveContainer);
        Container.Bind<WaveContainer>().FromScriptableObject(waveContainer).AsSingle();
        Container.Bind<WaveController>().FromNew().AsSingle().NonLazy();
    }

    private async void BindTower()
    {
        Tower tower = await AssetLoader.Load<Tower>(_referenceTower);
        tower.transform.position = _towerPoint.transform.position;
        Container.Bind<Tower>().FromInstance(tower).AsSingle();
        Container.Bind<TowerStats>().FromInstance(tower._stats).AsSingle();
    }
}