using UnityEngine;
using Zenject;

namespace TDS
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviour _moveBehaviour;
        [SerializeField] private EnemyBehaviour _attackBehaviour;
        [SerializeField] private EnemyStat _stats;

        private EnemyBehaviour _currentBehaviour;
        private PlayerBody _playerBody;
        private bool _isInit = false;

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
                _moveBehaviour.Init(_playerBody, this, _stats);
                _attackBehaviour.Init(_playerBody, this, _stats);
                _isInit = true;
            }

            SetMoveBehaviour();
        }
    }
}