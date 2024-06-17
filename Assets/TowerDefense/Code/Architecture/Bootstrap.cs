using Zenject;

namespace Code.TowerDefense.Architecture
{
    public class Bootstrap : IInitializable
    {
        private readonly WaveController _wavesController;
        private readonly PlayerAbility _playerAbility;

        public Bootstrap(WaveController wavesController, PlayerAbility playerAbility)
        {
            _wavesController = wavesController;
            _playerAbility = playerAbility;
        }

        public void Initialize()
        {
            _playerAbility.Initialize();
            _wavesController.Initialize();
        }
    }
}