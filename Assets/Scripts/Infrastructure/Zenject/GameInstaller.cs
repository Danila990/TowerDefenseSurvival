using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace TD
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AssetReferenceGameObject towerRefence;
        [SerializeField] private TowerStats towerStats;
        [SerializeField] private WaveSetting waveSetting;

        public override void InstallBindings()
        {
            BindGame();
            BindTower();
            BindWave();
        }

        private void BindGame()
        {
            Container
                .Bind<GameManager>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<IObjectPollFactory>()
                .To<ObjectPollFactory>()
                .AsSingle();
        }

        private void BindWave()
        {
            Container
                .Bind<WaveSetting>()
                .FromNewScriptableObject(waveSetting)
                .AsSingle();

            Container
                .Bind<WaveController>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private async void BindTower()
        {
            Container
                .Bind<TowerStats>()
                .FromNewScriptableObject(towerStats)
                .AsSingle();

            Tower tower = await AddressablesLoader.LoadInstantiate<Tower>(towerRefence);
            Container
                .Bind<Tower>()
                .FromInstance(tower)
                .AsSingle();
        }
    }
}