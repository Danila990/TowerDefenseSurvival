using Zenject;

namespace Code.TowerDefense
{
    public class WaveFactoryCreator
    {
        private readonly DiContainer _diContainer;

        public WaveFactoryCreator(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public WaveEnemyFactory CreateFactory(WaveData waveData, WaveController wavesController)
        {
            return new WaveEnemyFactory(_diContainer, waveData, wavesController);
        }
    }
}