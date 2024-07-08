using UnityEngine;
using Zenject;

namespace TowerDefense.Architecture
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBody _playerBody;
        
        [Header("Data")]
        [SerializeField] private WaveContainer _waveContainer;
        [SerializeField] private PlayerData _playerData;

        public override void InstallBindings()
        {
            BindData();
            BindGameplay();
            BindPlayer();
        }

        private void BindData()
        {
            Container.Bind<WaveContainer>().FromScriptableObject(_waveContainer).AsSingle();
        }

        private void BindPlayer()
        {
            Player player = new Player(_playerData.Config);
            Container.Bind<Player>().FromInstance(player).AsSingle();
            Container.Bind<PlayerBody>().FromInstance(_playerBody).AsSingle();
            Container.Bind<PlayerAbility>().FromInstance(_playerBody.GetComponent<PlayerAbility>()).AsSingle();
        }

        private void BindGameplay()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().FromNew().AsSingle();
            Container.Bind<WaveController>().FromNew().AsSingle().NonLazy();
        }
    }
}