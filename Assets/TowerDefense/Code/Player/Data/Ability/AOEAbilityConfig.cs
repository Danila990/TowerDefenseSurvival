using System;

namespace TowerDefense
{
    [Serializable]
    public class AOEAbilityConfig : AbilityConfig
    {
        public float AOERange = 2f;
        public float AOEDuration = 2f;
    }
}