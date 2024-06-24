using UnityEngine;
using UnityEngine.AI;

namespace TDS
{
    [RequireComponent(typeof(Enemy), typeof(NavMeshAgent))]
    public class MovementEnemy : EnemyBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Transform _moveTransform;
        private Transform _targetTransform;

        public override void Init(PlayerBody playerBody, Enemy enemy, EnemyStat enemyStat)
        {
            base.Init(playerBody, enemy, enemyStat);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _targetTransform = _playerBody.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            _navMeshAgent.speed = _enemyStat.MoveSpeed;
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_targetTransform.position);
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _enemyStat.AttackRange)
            {
                _navMeshAgent.isStopped = true;
                _enemy.SetAttackBehaviour();
            }
        }
    }
}