using UnityEngine;
using UnityEngine.AI;

namespace TD
{
    public class MovementState : IState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly Enemy _enemy;
        private bool _isMoving;

        public bool IsComplete => !_isMoving;

        public MovementState(NavMeshAgent navMeshAgent, Enemy enemy)
        {
            _navMeshAgent = navMeshAgent;
            _enemy = enemy;
        }

        public void Enter()
        {
            _isMoving = true;
            _navMeshAgent.SetDestination(_enemy.transform.position);
            _navMeshAgent.isStopped = false;
        }

        public void UpdateState()
        {
            if(Vector3.Distance(_enemy.transform.position, _enemy.transform.position) <= _enemy._stats.GetAttackRange()) 
            {
                _isMoving = true;
            }
        }
    }
}