using UnityEngine;
using Zenject;

namespace TD
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameDatabase _database;

        [SerializeField] private Tower _tower;
        [SerializeField] private WavesSetting _wavesSetting;

        public override void InstallBindings()
        {
            BindGameDatabase();
            BindTower();
            BindWave();
        }

        private void BindGameDatabase()
        {
            Container
                .Bind<GameDatabase>()
                .FromScriptableObject(_database)
                .AsSingle();

            Container
                .Bind<TowerData>()
                .FromNewScriptableObject(_database.GetData<TowerData>())
                .AsSingle();
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
                .Bind<Tower>()
                .FromInstance(_tower)
                .AsSingle();
        }
    }
}