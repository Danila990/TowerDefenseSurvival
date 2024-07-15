using System.Collections;
using System.Collections.Generic;

namespace MyCode
{
    public abstract class TargetAbility : Ability
    {
        protected EnemyLocator _enemyLocator;
        protected List<Timer> _timers;

        public void Construct(EnemyLocator enemyLocator)
        {
            _enemyLocator = enemyLocator;
            _timers = new List<Timer>();
            Coroutines.StartRountine(Tick());
        }

        public abstract IEnumerator Tick();
    }
}