using System;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace MyCode
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private IEnemyBehaviour _currentBehaviour;
        private IEnemyBehaviour _attackBehaviour;
        private IEnemyBehaviour _moveBehaviour;
        private Tower _tower;

        [field: SerializeField] public EnemyStats _stats { get; private set; }

        public bool IsAlive => gameObject.activeInHierarchy;

        private void Update()
        {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Tick();
            }
        }

        [Inject]
        public void Construct(Tower tower)
        {
            _tower = tower;
        }

        private void Awake()
        {
            _moveBehaviour = new NavMeshMoveBehaviour(_tower.transform.position, transform, GetComponent<NavMeshAgent>());
            _attackBehaviour = new MelleAttackBehaviour(_tower);
        }

        private void OnEnable()
        {
            SetMoveBehaviour();
        }

        public void TakeDamage(int damage)
        {
            _stats.ReduceHealth(damage);
        }

        private void SetMoveBehaviour()
        {
            SetupNewBehavior(_moveBehaviour, () => { SetAttackBehaviour(); });
        }

        private void SetAttackBehaviour()
        {
            SetupNewBehavior(_attackBehaviour, () => { _currentBehaviour = null; });
        }

        private void SetupNewBehavior(IEnemyBehaviour newBehaviour, Action action = null)
        {
            if (newBehaviour == null)
                return;

            _currentBehaviour?.Exit();
            _currentBehaviour = newBehaviour;
            _currentBehaviour.Enter(_stats);
            if(action != null)
            {
                _currentBehaviour.OnComplete += () => { action(); };
            }
        }
    }
}