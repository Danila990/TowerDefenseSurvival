using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace TD.Architecture
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Tower")]
        [SerializeField] private AssetReferenceGameObject _towerRefence;
        [SerializeField] private TowerStats _towerStats;
        [Header("SpawnEnemy")]
        [SerializeField] private EnemySpawnData _enemySpawnData;

        public override void InstallBindings()
        {
            BindTower();
            BindSpawnEnemy();
        }

        private void BindSpawnEnemy()
        {
            EnemySpawner enemySpawner = new EnemySpawner(_enemySpawnData);
            Container
                .Bind<EnemySpawner>()
                .FromInstance(enemySpawner)
                .AsSingle();
        }

        private async void BindTower()
        {
            Tower tower = await AssetLoader.LoadInstantiate<Tower>(_towerRefence);
            Container
                .Bind<TowerStats>()
                .FromNewScriptableObject(_towerStats)
                .AsSingle();

            Container
                .Bind<Tower>()
                .FromInstance(tower)
                .AsSingle();
        }
    }
}