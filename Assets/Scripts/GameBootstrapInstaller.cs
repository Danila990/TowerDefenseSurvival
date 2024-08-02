using MyCode;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameBootstrapInstaller : MonoInstaller
{
    [SerializeField] private Transform _towerPoint;
    [SerializeField] private AssetReferenceGameObject _referenceTower;
    [SerializeField] private AssetReferenceScriptableObject _referenceWaveContainer;

    public override async void InstallBindings()
    {
        await BindTower();
        await BindWave();
        Initialize();
    }

    private void Initialize()
    {
        SetupSetting();
        var waveController = Container.Resolve<WaveController>();
        waveController.Initialize();
    }

    private void SetupSetting()
    {
        Application.targetFrameRate = 60;
    }

    private async Task BindWave()
    {
        WaveContainer waveContainer = await AssetLoader.Load<WaveContainer>(_referenceWaveContainer);
        Container.Bind<WaveContainer>().FromScriptableObject(waveContainer).AsSingle();
        Container.Bind<WaveController>().FromNew().AsSingle().NonLazy();
    }

    private async Task BindTower()
    {
        Tower tower = await AssetLoader.Load<Tower>(_referenceTower);
        tower.transform.position = _towerPoint.transform.position;
        Container.Bind<Tower>().FromInstance(tower).AsSingle();
        Container.Bind<TowerStats>().FromInstance(tower._stats).AsSingle();
    }
}