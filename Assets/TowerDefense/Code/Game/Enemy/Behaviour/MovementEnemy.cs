using UnityEngine;
using UnityEngine.AI;

namespace Code.TowerDefense
{
    [RequireComponent(typeof(Enemy), typeof(NavMeshAgent))]
    public class MovementEnemy : EnemyBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private float _rangeAttack;
        private Transform _moveTransform;
        private Transform _targetTransform;

        public override void Init(Player player, Enemy enemy)
        {
            base.Init(player, enemy);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _targetTransform = _player.transform;
            _moveTransform = _enemy.transform;
        }

        public override void Enter()
        {
            EnemyStats enemyStats = _enemy._stats;
            _rangeAttack = enemyStats.AttackRange;
            _navMeshAgent.speed = enemyStats.MoveSpeed;
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_targetTransform.position);
        }

        public override void Tick()
        {
            if (Vector3.Distance(_moveTransform.position, _targetTransform.position) <= _rangeAttack)
            {
                _navMeshAgent.isStopped = true;
                _enemy.SetAttackBehaviour();
            }
        }
    }
}