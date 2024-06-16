using UnityEngine;

namespace Code.TowerDefense
{
    [RequireComponent(typeof(Enemy))]
    public class MeleeAttackEnemy : EnemyBehaviour
    {
        private float _rangeAttack;
        private float _damage;
        private Transform _moveTransform;
        private Transform _targetTransform;
        private Timer _timer;

        public override void Init(Player player, Enemy enemy)
        {
            base.Init(player, enemy);

            _targetTransform = _player.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            EnemyStats enemyStats = _enemy._stats;
            _timer = new Timer(enemyStats.AttackDelay);
            _rangeAttack = enemyStats.AttackRange;
            _damage = enemyStats.AttackDamage;
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _rangeAttack)
            {
                if (_timer.IsTimerEnd)
                {
                    _timer.Start();
                    _player.TakeDamage(_damage);
                }
            }
            else
            {
                _enemy.SetMoveBehaviour();
            }
        }
    }
}