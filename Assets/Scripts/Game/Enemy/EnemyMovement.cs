using System;
using UnityEngine;
using UnityEngine.AI;

namespace TD
{
    public class EnemyMovement
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly Transform _target;

        public event Action OnStartMovement;

        public EnemyMovement(NavMeshAgent navMeshAgent, Transform target)
        {
            _navMeshAgent = navMeshAgent;
            _target = target;
        }

        public void MoveSpeed(float speed) => _navMeshAgent.speed = speed;

        public void Start()
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _navMeshAgent.isStopped = false;
            OnStartMovement?.Invoke();
        }

        public void Stop() => _navMeshAgent.isStopped = true;
    }
}