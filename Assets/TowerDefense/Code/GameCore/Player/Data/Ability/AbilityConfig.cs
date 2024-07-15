using System;

namespace MyCode
{
    [Serializable]
    public class AbilityConfig
    {
        public float Damage = 15f;
        public float AttackRange = 5f;
        public float AttackDelay = 1f;
        public float AbilityDelay = 0.05f;
        public int Priority = 0;
    }
}