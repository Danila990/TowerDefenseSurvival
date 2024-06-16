using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviour _moveBehaviour;
        [SerializeField] private EnemyBehaviour _attackBehaviour;

        private EnemyBehaviour _currentBehaviour;
        private Player _player;
        private bool _isInit = false;

        [field: SerializeField] public EnemyStats _stats {  get; private set; }

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
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
    }
}