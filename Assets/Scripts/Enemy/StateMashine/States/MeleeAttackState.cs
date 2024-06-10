using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "MeleeAttackState", menuName = "EnemyState/MeleeAttackState")]
    public class MeleeAttackState : EnemyState
    {
        [SerializeField] private float _decayAttack = 1f;
        [SerializeField] private float _damage = 25f;

        private IDamageable _damageable;
        private Timer _timer;

        public override void Init(EnemyStateMashine enemyStateMashine, Enemy enemy)
        {
            base.Init(enemyStateMashine, enemy);

            _timer = new Timer(_decayAttack);
            _damageable = enemy.GetTarget().GetComponent<IDamageable>();
        }

        public override void Tick()
        {
            if (_timer.IsTimerEnd)
            {
                _timer.Start();
                _damageable.TakeDamage(_damage);
            }
        }
    }
}