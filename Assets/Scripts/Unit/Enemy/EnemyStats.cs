using System;
using UnityEngine;

[Serializable]
public class EnemyStats : StatsBase
{
    [SerializeField] private int _damage = 15;
    [SerializeField] private int _armor = 0;
    [SerializeField] private float _attackDelay = 1f;
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _moveSpeed = 1f;

    private int _increaseDamage = 0;
    private int _increaseArmor = 0;
    private float _increaseMoveSpeed = 0;

    public int Damage => _damage + _increaseDamage;
    public int Armor => _armor + _increaseArmor;
    public float MoveSpeed => _moveSpeed + _increaseMoveSpeed;
    public float AttackRange => _attackRange;
    public float AttackDelay => _attackDelay;

    public override void ResetStats()
    {
        base.ResetStats();

        _increaseDamage = 0;
        _increaseArmor = 0;
        _increaseMoveSpeed = 0;
    }

    public void AddIncreaseDamage(int damage) => _increaseDamage += damage;
    public void AddIncreaseArmor(int armor) => _increaseArmor += armor;
    public void AddIncreaseMoveSpeed(int speed) => _increaseMoveSpeed += speed;
}
