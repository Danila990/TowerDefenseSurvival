using System;

namespace TowerDefense
{
    [Serializable]
    public struct EnemyConfig
    {
        public float AttackDamage;
        public float AttackDelay;
        public float AttackRange;
        public float MoveSpeed;
        public float Health;
    }
}