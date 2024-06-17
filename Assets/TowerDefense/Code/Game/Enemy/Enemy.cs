using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviour _moveBehaviour;
        [SerializeField] private EnemyBehaviour _attackBehaviour;
        [SerializeField] private EnemyStats _stats;

        private EnemyBehaviour _currentBehaviour;
        private Player _player;
        private bool _isInit = false;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void Update()
        {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Tick();
            }
        }


        public void Activate()
        {
            if(!_isInit)
            {
                _moveBehaviour.Init(_player, this);
                _attackBehaviour.Init(_player, this);
                _isInit = true;
            }

            SetMoveBehaviour();
        }

        public EnemyStats GetStats()
        {
            return _stats;
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
    }
}