using UnityEngine;
using UnityEngine.AI;

namespace MyCode
{
    [RequireComponent(typeof(Enemy), typeof(NavMeshAgent))]
    public class MovementEnemy : EnemyBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Transform _moveTransform;
        private Transform _targetTransform;

        public override void Init(PlayerBody playerBody, Enemy enemy)
        {
            base.Init(playerBody, enemy);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _targetTransform = _playerBody.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            _navMeshAgent.speed = _config.MoveSpeed;
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_targetTransform.position);
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _config.AttackRange)
            {
                _navMeshAgent.isStopped = true;
                _enemy.SetAttackBehaviour();
            }
        }
    }
}