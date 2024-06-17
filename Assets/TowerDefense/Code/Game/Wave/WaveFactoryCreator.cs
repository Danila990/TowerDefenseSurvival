using Zenject;

namespace Code.TowerDefense
{
    public class WaveFactoryCreator
    {
        private readonly DiContainer _diContainer;
        private readonly WaveController _waveController;

        public WaveFactoryCreator(DiContainer diContainer, WaveController waveController)
        {
            _diContainer = diContainer;
            _waveController = waveController;
        }

        public WaveEnemyFactory CreateFactory(WaveData waveData)
        {
            return new WaveEnemyFactory(_diContainer, waveData, _waveController);
        }
    }
}