using UnityEngine;

namespace TDS
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        protected Enemy _enemy;
        protected PlayerBody _playerBody;
        protected EnemyStat _enemyStat;

        public virtual void Init(PlayerBody playerBody, Enemy enemy, EnemyStat enemyStat)
        {
            _enemy = enemy;
            _playerBody = playerBody;
            _enemyStat = enemyStat;
        }

        public abstract void Enter();
        public abstract void Tick();
    }
}