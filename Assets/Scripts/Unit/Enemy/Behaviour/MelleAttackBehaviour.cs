using System;
using UnityEngine;

public class MelleAttackBehaviour : IEnemyBehaviour
{
    public event Action OnComplete;

    private Timer _timer;
    private IDamageable _damageable;
    private int _damage;

    public MelleAttackBehaviour(IDamageable damageable)
    {
        _damageable = damageable;
    }

    public void Enter(EnemyStats enemyStats)
    {
        _damage = enemyStats.Damage;
        _timer = new Timer(enemyStats.AttackDelay);
    }

    public void Tick()
    {
        if (_damageable.IsAlive)
        {
            if (_timer.IsTimerEnd)
            {
                _timer.Start();
                _damageable.TakeDamage(_damage);
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
