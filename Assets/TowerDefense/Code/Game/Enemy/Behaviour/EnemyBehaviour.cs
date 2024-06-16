using UnityEngine;

namespace Code.TowerDefense
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        protected Enemy _enemy;
        protected Player _player;

        public virtual void Init(Player player, Enemy enemy)
        {
            _enemy = enemy;
            _player = player;
        }

        public abstract void Enter();
        public abstract void Tick();
    }
}