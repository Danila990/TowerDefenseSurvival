using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace TD
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AssetReferenceGameObject _towerRefence;
        [SerializeField] private TowerStats _towerStats;
        [SerializeField] private WaveSetting _waveSetting;

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
                .FromNewScriptableObject(_waveSetting)
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
                .FromNewScriptableObject(_towerStats)
                .AsSingle();

            Tower tower = await AddressablesLoader.LoadInstantiate<Tower>(_towerRefence);
            Container
                .Bind<Tower>()
                .FromInstance(tower)
                .AsSingle();
        }
    }
}