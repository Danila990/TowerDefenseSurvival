using System;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "TowerStats", menuName = "Data/TowerStats")]
    public class TowerStats : ScriptableObject
    {
        public event Action<float> OnTowerHealth;
        public event Action<float> OnTowerMaxHealth;

        [field: SerializeField] public float _health { get; private set; } = 2000;

        public float _maxHealth { get; private set; }

        private void OnValidate()
        {
            _maxHealth = _health;
        }

        public void ChangeHealth(float health)
        {
            _health = health;
            if(_health < 0)
            {
                _health = 0;
            }

            OnTowerHealth?.Invoke(_health);
        }

        public void ChangeMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            if (_maxHealth < 0)
            {
                _maxHealth = 0;
            }

            OnTowerMaxHealth?.Invoke(_maxHealth);
        }
    }
}