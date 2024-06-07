
namespace TD
{
    public class AttackState : IState
    {
        private readonly IDamageable _damageable;
        private readonly Enemy _enemy;
        private Timer _timer;

        public bool IsComplete => !_damageable.IsAlive;

        public AttackState(Enemy enemy, IDamageable damageable)
        {
            _damageable = damageable;
            _enemy = enemy;
        }

        public void Enter()
        {
            _timer = new Timer(_enemy._stats.GetAttackSpeed());
        }

        public void UpdateState()
        {
            if (_timer.IsTimerEnd)
            {
                _timer.Start();
                _damageable.TakeDamage(_enemy._stats.GetAttackDamage());
            }
        }
    }
}