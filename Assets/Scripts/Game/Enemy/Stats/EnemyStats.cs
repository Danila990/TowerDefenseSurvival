using System;
using UnityEngine;

namespace TD
{
    [Serializable]
    public class EnemyStats
    {
        [SerializeField] private float _health;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackDamage;

        public float GetHealth()
        {
            return _health;
        }

        public float GetMoveSpeed()
        {
            return _moveSpeed;
        }

        public float GetAttackSpeed()
        {
            return _attackSpeed;
        }

        public float GetAttackRange()
        {
            return _attackRange;
        }

        public float GetAttackDamage()
        {
            return _attackDamage;
        }
    }
}