using UnityEngine;

namespace TowerDefense
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        protected Enemy _enemy;
        protected PlayerBody _playerBody;
        protected EnemyConfig _config => _enemy.Config;

        public virtual void Init(PlayerBody playerBody, Enemy enemy)
        {
            _enemy = enemy;
            _playerBody = playerBody;
        }

        public abstract void Enter();
        public abstract void Tick();
    }
}