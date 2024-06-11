using UnityEngine;
using Zenject;

namespace TD
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private TowerHealth _towerHealth;
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