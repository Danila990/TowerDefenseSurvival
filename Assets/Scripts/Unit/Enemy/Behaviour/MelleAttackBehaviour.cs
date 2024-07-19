using System;

public class MelleAttackBehaviour : IEnemyBehaviour
{
    public event Action OnComplete;

    private Timer _timer;
    private IDamageable _damageable;
    private EnemyStats _enemyStats;

    public MelleAttackBehaviour(IDamageable damageable)
    {
        _damageable = damageable;
    }

    public void Enter(EnemyStats enemyStats)
    {
        _timer = new Timer(enemyStats.AttackDelay);
    }

    public void Tick()
    {
        if (_damageable.IsAlive)
        {
            if (_timer.IsTimerEnd)
            {
                _timer.Start();
                _damageable.TakeDamage(_enemyStats.Damage);
            }
        }
        else
        {
            OnComplete?.Invoke();
        }
    }

    public void Exit()
    {
        
    }
}
