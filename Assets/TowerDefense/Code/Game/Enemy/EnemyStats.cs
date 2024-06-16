using System;

namespace Code.TowerDefense
{
    [Serializable]
    public class EnemyStats
    {
        public float AttackDamage = 25f;
        public float AttackDelay = 1f;
        public float AttackRange = 3f;
        public float MoveSpeed = 1f;
        public float Health = 50f;
    }
}