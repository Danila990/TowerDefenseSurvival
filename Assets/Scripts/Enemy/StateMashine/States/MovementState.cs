using UnityEngine;
using UnityEngine.AI;

namespace TD
{
    [CreateAssetMenu(fileName = "MovementState", menuName = "EnemyState/MovementState")]
    public class MovementState : EnemyState
    {
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _rangeAtTarget = 2f;

        private NavMeshAgent _navMeshAgent;
        private Transform _target;

        public override void Init(EnemyStateMashine enemyStateMashine, Enemy enemy)
        {
            base.Init(enemyStateMashine, enemy);

            _navMeshAgent = _enemy.GetComponent<NavMeshAgent>();
            _target = _enemy.GetTarget().transform;
            _navMeshAgent.SetDestination(_target.position);
            _navMeshAgent.speed = _moveSpeed;
            _navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if (Vector3.Distance(_enemy.transform.position, _target.position) <= _rangeAtTarget)
            {
                _navMeshAgent.isStopped = true;
                NextState();
            }
        }
    }
}