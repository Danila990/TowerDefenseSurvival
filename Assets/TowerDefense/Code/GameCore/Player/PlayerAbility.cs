using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

namespace MyCode
{
    public class PlayerAbility
    {
        private readonly Dictionary<string, Ability> _abilitys;


        public void AddAbility(Ability ability)
        {
            GetAbility(ability).Add();
        }

        private Ability GetAbility(Ability ability)
        {
            var name = ability.name;
            if (!_abilitys.ContainsKey(name))
            {
                Ability newAbility = Object.Instantiate(ability);
                _abilitys.Add(name, newAbility);
            }

            return _abilitys[name];
        }
    }
}