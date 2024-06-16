using Zenject;

namespace Code.TowerDefense
{
    public class Bootstrap : IInitializable
    {
        private WaveController _wavesController;

        [Inject]
        private void Construct(WaveController wavesController)
        {
            _wavesController = wavesController;
        }

        public void Initialize()
        {
            _wavesController.Initialize();
        }
    }
}