using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TowerDefense
{
    public class PlayerAbility : MonoBehaviour
    {
        [SerializeField] private BulletAbility _testability;

        private Dictionary<Type, List<Ability>> _abilitys = new Dictionary<Type, List<Ability>>();
        private EnemyLocator _enemyLocator;

        [Inject]
        private void Construct(EnemyLocator enemyLocator)
        {
            _enemyLocator = enemyLocator;
        }

        public void Start()
        {
            AddAbility(_testability);
        }

        public void AddAbility(Ability ability)
        {
            List<Ability> abilitys = GetAbilitys(ability);
            abilitys.Add(ability);
            ability.Init(this, _enemyLocator);
        }

        public void UpgradeAbility()
        {

        }

        private List<Ability> GetAbilitys(Ability ability)
        {
            var type = ability.GetType();
            if (!_abilitys.ContainsKey(type))
            {
                _abilitys.Add(type, new List<Ability>());
            }

            return _abilitys[type];
        }
    }
}