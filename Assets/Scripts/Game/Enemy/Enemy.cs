using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TD
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private readonly BaseStateMashine _stateMashine;

        public EnemyStats _stats { get; private set; }
        public Transform _target { get; private set; }

        public bool IsAlive => gameObject.activeSelf;

        [Inject]
        private void Construct(Tower tower)
        {
            _target = tower.transform;
        }

        private void Awake()
        {
            _stateMashine.AddState(new MovementState(GetComponent<NavMeshAgent>(), this));
            _stateMashine.AddState(new AttackState(this, _target.GetComponent<IDamageable>()));
            _stateMashine.Enter();
        }

        public void SetupStats(EnemyStats stats)
        {
            _stats = stats;
        }

        public void TakeDamage(float damage)
        {

        }
    }
}