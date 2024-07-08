using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Enemy))]
    public class MeleeAttackEnemy : EnemyBehaviour
    {
        private Transform _moveTransform;
        private Transform _targetTransform;
        private Timer _timer;

        public override void Init(PlayerBody playerBody, Enemy enemy)
        {
            base.Init(playerBody, enemy);

            _targetTransform = _playerBody.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            _timer = new Timer(_config.AttackDelay);
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _config.AttackRange)
            {
                if (_timer.IsTimerEnd)
                {
                    _timer.Start();
                    _playerBody.TakeDamage(_config.AttackDamage);
                }
            }
            else
            {
                _enemy.SetMoveBehaviour();
            }
        }
    }
}