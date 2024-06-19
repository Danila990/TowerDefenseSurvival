using System;
using System.Collections.Generic;

namespace Code.TowerDefense
{
    public class AbilityGroup : IAbilityGroup
    {
        protected List<IAbility> _abilities = new List<IAbility>();

        public void AddAbility(IAbility ability)
        {
            _abilities.Add(ability);
            ability.Init();
        }

        public void UpgradeAbilityType()
        {
            throw new System.NotImplementedException();
        }
    }
}