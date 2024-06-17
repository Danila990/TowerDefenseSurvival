using System;
using System.Collections.Generic;

namespace Code.TowerDefense
{
    public class BulletGroup : IAbilityGroup
    {
        protected Dictionary<Type, List<BulletAbility>> _abilityTypes = new Dictionary<Type, List<BulletAbility>>();

        public void AddAbility<T>(T ability) where T : IAbility
        {
            _abilityTypes.Add(typeof(T), new List<BulletAbility>());
        }

        public void UpgradeAbilityType<T>() where T : IAbility
        {
            throw new System.NotImplementedException();
        }
    }
}