using System.Collections;
using UnityEngine;

namespace TD
{
    public abstract class EnemyState : ScriptableObject
    {
        private EnemyStateMashine _enemyStateMashine;
        protected Enemy _enemy;

        public virtual void Init(EnemyStateMashine enemyStateMashine, Enemy enemy)
        {
            _enemy = enemy;
            _enemyStateMashine = enemyStateMashine;
        }

        public abstract void Tick();

        protected void NextState()
        {
            _enemyStateMashine.NextState();
        }

        protected void PreviousState()
        {
            _enemyStateMashine.PreviousState();
        }
    }
}