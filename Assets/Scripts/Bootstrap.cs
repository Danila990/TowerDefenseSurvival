using UnityEngine;

namespace MyCode
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerBody _playerBody;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerAbility _playerAbility;
        [SerializeField] private WaveController _waveController;

        private EnemyFactory _enemyFactory;
        private EnemyLocator _enemyLocator;
        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            SetupSetting();
            Create();
            RegisterServices();
        }

        private void Start()
        {
            _playerBody.Init(_player);
            _waveController.Init(_enemyFactory, _playerBody);
        }

        private void Update()
        {
            _waveController.Update();
        }

        private void SetupSetting()
        {
            Application.targetFrameRate = 60;
        }

        private void Create()
        {
            _enemyLocator = new EnemyLocator(_enemyFactory, _playerBody);
            _enemyFactory = new EnemyFactory();
        }

        private void RegisterServices()
        {
            _serviceLocator = new ServiceLocator();
            _serviceLocator.Register(_player);
            _serviceLocator.Register(_playerBody);
            _serviceLocator.Register(_enemyFactory);
        }
    }
}