using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Data/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
        [field: SerializeField] public float _health { get; private set; } = 25f;
        [field: SerializeField] public float _movementSpeed { get; private set; } = 1f;
        [field: SerializeField] public float _attackSpeed { get; private set; } = 0.5f;
        [field: SerializeField] public float _attackRange { get; private set; } = 2f;
        [field: SerializeField] public float _damage { get; private set; } = 25f;

        public void ChangeHealth(float health)
        {
            if (health < _health)
            {
                return;
            }

            _health = health;
        }

        public EnemyStats Clone()
        {
            return new EnemyStats()
            {
                _health = _health,
                _movementSpeed = _movementSpeed,
                _attackSpeed = _attackSpeed,
                _attackRange = _attackRange,
                _damage = _damage
            };
        }
    }
}