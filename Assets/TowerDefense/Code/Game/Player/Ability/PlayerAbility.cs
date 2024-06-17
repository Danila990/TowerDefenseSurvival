using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class PlayerAbility : MonoBehaviour, IInitializable
    {
        private Dictionary<Type, IAbilityGroup> _abilityControllers;

        public void Initialize()
        {
            _abilityControllers = new Dictionary<Type, IAbilityGroup>()
            {
                {typeof(AOEAbility), new AOEGroup()},
                {typeof(BulletAbility), new BulletGroup()}
            };
        }

        public void AddAbility<T>(IAbility ability) where T : IAbility
        {
            IAbilityGroup abilityGroup = GetAbilityGroup<T>();
            abilityGroup.AddAbility(ability);
        }

        private IAbilityGroup GetAbilityGroup<T>() where T : IAbility
        {
            var type = typeof(T);
            if (!_abilityControllers.ContainsKey(type))
            {
                throw new NullReferenceException($"Ability Group: {typeof(T)} is null");
            }

            return _abilityControllers[type];
        }
    }
}