using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public abstract class Ability : ScriptableObject
    {
        protected EnemyLocator _enemyLocator;
        protected PlayerAbility _playerAbility;

        public virtual void Init(PlayerAbility playerAbility, EnemyLocator enemyLocator)
        {
            _enemyLocator = enemyLocator;
            _playerAbility = playerAbility;
        }

        public abstract void Upgrade();
        public abstract IEnumerator Tick();
    }
}