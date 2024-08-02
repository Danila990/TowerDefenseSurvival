using System;
using UnityEngine;

[Serializable]
public class StatsBase
{
    public event Action OnDied = () => { };

    [SerializeField] protected int _health = 50;
    [SerializeField] protected int _maxHealth = 50;

    private int _increaseMaxHealth = 0;

    public int Health => _health;
    public int MaxHealth => _maxHealth + _increaseMaxHealth;

    public virtual void ResetStats()
    {
        _health = MaxHealth;
    }

    public virtual void ReduceHealth(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            _health = 0;
            OnDied.Invoke();
        }
    }

    public virtual void AddIncreaseMaxHealth(int value)
    {
        _increaseMaxHealth += value;
        if (_health > _maxHealth)
            ReduceHealth(_health - _maxHealth);
    }
}
