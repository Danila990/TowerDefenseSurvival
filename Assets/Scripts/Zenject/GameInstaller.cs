using UnityEngine;
using Zenject;

namespace TD
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private TowerHealth _towerHealth;
        [SerializeField] private WavesSetting _wavesSetting;

        public override void InstallBindings()
        {
            BindTower();
            BindWave();
        }

        private void BindWave()
        {
            Container
                .Bind<IObjectPollFactory>()
                .To<ObjectPollFactory>()
                .AsSingle();

            Container
                .Bind<WavesSetting>()
                .FromNewScriptableObject(_wavesSetting)
                .AsSingle();

            Container.
                Bind<WavesController>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        private void BindTower()
        {
            Container
                .Bind<TowerHealth>()
                .FromNewScriptableObject(_towerHealth)
                .AsSingle();

            Container
                .Bind<Tower>()
                .FromInstance(_tower)
                .AsSingle();
        }
    }
}