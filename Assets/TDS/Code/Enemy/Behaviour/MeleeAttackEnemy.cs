using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(Enemy))]
    public class MeleeAttackEnemy : EnemyBehaviour
    {
        private Transform _moveTransform;
        private Transform _targetTransform;
        private Timer _timer;

        public override void Init(PlayerBody playerBody, Enemy enemy, EnemyStat enemyStat)
        {
            base.Init(playerBody, enemy, enemyStat);

            _targetTransform = _playerBody.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            _timer = new Timer(_enemyStat.AttackDelay);
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _enemyStat.AttackRange)
            {
                if (_timer.IsTimerEnd)
                {
                    _timer.Start();
                    _playerBody.TakeDamage(_enemyStat.AttackDamage);
                }
            }
            else
            {
                _enemy.SetMoveBehaviour();
            }
        }
    }
}