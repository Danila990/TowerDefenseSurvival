using UnityEngine;
using Zenject;

namespace TDS.Architecture
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBody _playerBody;
        [SerializeField] private Player _player;
        [SerializeField] private WaveSetting _waveSetting;

        public override void InstallBindings()
        {
            BindData();
            BindGameplay();
        }

        private void BindData()
        {
            Container.Bind<Player>().FromNewScriptableObject(_player).AsSingle();
            Container.Bind<WaveSetting>().FromNewScriptableObject(_waveSetting).AsSingle();
        }

        private void BindGameplay()
        {
            Container.Bind<PlayerBody>().FromInstance(_playerBody).AsSingle();
            Container.Bind<PlayerAbility>().FromInstance(_playerBody.GetComponent<PlayerAbility>()).AsSingle();
            Container.Bind<EnemySpawnerCreator>().FromNew().AsSingle();
            Container.Bind<WaveController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}