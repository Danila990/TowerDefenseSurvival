using System;
using UnityEngine;

[Serializable]
public class EnemyStats : StatsBase
{
    [SerializeField] private int _damage = 15;
    [SerializeField, Range(0, 10)] private int _armor = 0;
    [SerializeField, Range(0.1f, 2f)] private float _attackDelay = 1f;
    [SerializeField, Range(2f, 6f)] private float _attackRange = 2f;
    [SerializeField, Range(0.6f, 1.5f)] private float _moveSpeed = 1f;
    [SerializeField] private int _income = 25;

    private int _increaseDamage = 0;
    private int _increaseArmor = 0;

    public int Damage => _damage + _increaseDamage;
    public int Armor => _armor + _increaseArmor;
    public float MoveSpeed => _moveSpeed;
    public float AttackRange => _attackRange;
    public float AttackDelay => _attackDelay;
    public int Income => _increaseDamage;

    public void AddIncreaseDamage(int damage) => _increaseDamage = damage;
    public void AddIncreaseArmor(int armor) => _increaseArmor = armor;
}
