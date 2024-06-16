using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class SceneDataInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private WavesSetting _wavesSetting;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromNewScriptableObject(_playerData).AsSingle();
            Container.Bind<WavesSetting>().FromNewScriptableObject(_wavesSetting).AsSingle();
        }
    }
}