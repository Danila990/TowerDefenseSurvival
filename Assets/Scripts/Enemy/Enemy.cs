using UnityEngine;
using Zenject;

namespace TD
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyStateMashine _stateMashine;
        [SerializeField] private float _health;

        private Tower _tower;

        [Inject]
        private void Construct(Tower tower)
        {
            _tower = tower;
        }

        private void Awake()
        {
            _stateMashine.Init(this);
        }

        private void Update()
        {
            _stateMashine.Update();
        }

        public Tower GetTarget()
        {
            return _tower;
        }

        public void TakeDamage(float damage)
        {

        }
    }
}