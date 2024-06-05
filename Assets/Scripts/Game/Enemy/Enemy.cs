using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject.SpaceFighter;
using Zenject;

namespace TD
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private EnemyStats _stats;
        private Tower _tower;

        public EnemyMovement Movement { get; private set; }

        [Inject]
        private void Construct(Tower tower)
        {
            _tower = tower;
            Movement = new EnemyMovement(GetComponent<NavMeshAgent>(), _tower.transform);
            Movement.OnStartMovement += () => StartCoroutine(Attack());
        }


        public void SetupStats(EnemyStats stats)
        {
            _stats = stats.Clone();
            Movement.MoveSpeed(_stats._movementSpeed);
        }

        public void TakeDamage(float damage)
        {

        }

        private IEnumerator Attack()
        {
            yield return new WaitUntil(() => Vector3.Distance(transform.position, _tower.transform.position) <= _stats._attackRange);
            Movement.Stop();

            while (true)
            {
                _tower.TakeDamage((int)_stats._damage);
                yield return new WaitForSeconds(_stats._attackSpeed);
            }
        }
    }
}