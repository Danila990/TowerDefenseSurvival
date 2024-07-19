using System;
using UnityEngine;
using UnityEngine.AI;

namespace MyCode
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private IEnemyBehaviour _currentBehaviour;
        private IEnemyBehaviour _attackBehaviour;
        private IEnemyBehaviour _moveBehaviour;

        [field: SerializeField] public EnemyStats _stats { get; private set; }

        public bool IsAlive => gameObject.activeInHierarchy;

        private void Update()
        {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Tick();
            }
        }

        public void Init(Tower tower)
        {
            _moveBehaviour = new NavMeshMoveBehaviour(tower.transform.position, transform, GetComponent<NavMeshAgent>());
            _attackBehaviour = new MelleAttackBehaviour(tower);
            SetMoveBehaviour();
        }

        public void Activate()
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