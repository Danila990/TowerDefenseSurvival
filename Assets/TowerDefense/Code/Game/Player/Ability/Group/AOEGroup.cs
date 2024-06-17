using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.TowerDefense
{
    public class AOEGroup : IAbilityGroup
    {
        protected Dictionary<Type, List<AOEAbility>> _abilityTypes = new Dictionary<Type, List<AOEAbility>>();

        public void AddAbility<T>(T ability) where T : IAbility
        {
            _abilityTypes.Add(typeof(T), new List<AOEAbility>());
        }

        public void UpgradeAbilityType<T>() where T : IAbility
        {
            throw new System.NotImplementedException();
        }
    }
}