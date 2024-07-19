using System;

namespace MyCode
{
    [Serializable]
    public struct EnemyConfig
    {
        public int Damage;
        public float AttackDelay;
        public float AttackRange;
        public float MoveSpeed;
        public float Health;
    }
}