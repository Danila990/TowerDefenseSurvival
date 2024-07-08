using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using Zenject;

namespace TowerDefense
{
    public class PlayerAbility : MonoBehaviour, IInitializable
    {
        [SerializeField] private BulletAbility _testability;

        private Dictionary<Type, IAbilityGroup> _abilityControllers;

        public void Initialize()
        {
            _abilityControllers = new Dictionary<Type, IAbilityGroup>()
            {
                {typeof(AOEAbility), new AbilityGroup()},
                {typeof(BulletAbility), new AbilityGroup()}
            };

            AddAbility<BulletAbility>(_testability);
        }

        public void AddAbility<T>(IAbility ability)
        {
            IAbilityGroup abilityGroup = GetAbilityGroup<T>();
            abilityGroup.AddAbility(ability);
        }

        private IAbilityGroup GetAbilityGroup<T>()
        {

            var type = typeof(T);
            if (!_abilityControllers.ContainsKey(type))
            {
                _abilityControllers.Add(type, new AbilityGroup());
            }

            return _abilityControllers[type];
        }
    }
}