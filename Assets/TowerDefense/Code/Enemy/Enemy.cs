using UnityEngine;
using Zenject;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviour _moveBehaviour;
        [SerializeField] private EnemyBehaviour _attackBehaviour;
        [SerializeField] private EnemyConfig _config;

        private EnemyBehaviour _currentBehaviour;
        private PlayerBody _playerBody;
        private bool _isInit = false;

        public EnemyConfig Config => _config;

        [Inject]
        private void Construct(PlayerBody playerBody)
        {
            _playerBody = playerBody;
        }

        private void Update()
        {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Tick();
            }
        }

        public void TakeDamage(float damage)
        {
            _config.Health -= damage;
            if(_config.Health <= 0)
            {
                _config.Health = 0;
                gameObject.SetActive(false);
            }
        }

        public void SetConfig(EnemyConfig config)
        {
            _config = config;
        }

        public void SetMoveBehaviour()
        {
            _currentBehaviour = _moveBehaviour;
            _currentBehaviour.Enter();
        }

        public void SetAttackBehaviour()
        {
            _currentBehaviour = _attackBehaviour;
            _currentBehaviour.Enter();
        }

        public void Activate()
        {
            if(!_isInit)
            {
                _moveBehaviour.Init(_playerBody, this);
                _attackBehaviour.Init(_playerBody, this);
                _isInit = true;
            }

            SetMoveBehaviour();
        }
    }
}