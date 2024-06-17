using UnityEngine;
using Zenject;

namespace Code.TowerDefense.Architecture
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrap>().FromNew().AsSingle();
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerAbility>().FromInstance(_player.GetComponent<PlayerAbility>()).AsSingle();
            Container.Bind<WaveFactoryCreator>().FromNew().AsSingle();
            Container.Bind<WaveController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}