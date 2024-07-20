using MyCode;
using System;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoveBehaviour : IEnemyBehaviour
{
    public event Action OnComplete;

    private readonly Vector3 _targetPosition;
    private readonly Transform _moveObject;
    private readonly NavMeshAgent _agent;

    public NavMeshMoveBehaviour(Vector3 targetPoint, Transform moveObject, NavMeshAgent navMeshAgent)
    {
        _agent = navMeshAgent;
        _targetPosition = targetPoint;
        _moveObject = moveObject;
    }

    public void Enter(EnemyStats enemyStats)
    {
        _agent.stoppingDistance = enemyStats.AttackRange;
        _agent.speed = enemyStats.MoveSpeed;
        _agent.isStopped = false;
        _agent.SetDestination(_targetPosition);
    }

    public void Tick()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                OnComplete?.Invoke();
            }
        }
    }

    public void Exit()
    {
        _agent.isStopped = true;
    }
}
