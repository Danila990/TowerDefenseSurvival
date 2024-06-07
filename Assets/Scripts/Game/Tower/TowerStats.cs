using System;
using UnityEngine;

namespace TD
{
    public class TowerStats : ScriptableObject
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        [SerializeField] private float _health = 2000;

        private float _maxHealth;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _maxHealth = _health;
        }
#endif
        public float GetHealth()
        {
            return _health;
        }

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

        public void ChangeHealth(float health)
        {
            _health = health;
            if(_health < 0)
            {
                _health = 0;
            }

            OnHealth?.Invoke(_health);
        }

        public void ChangeMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            if (_maxHealth < 0)
            {
                _maxHealth = 0;
            }

            OnMaxHealth?.Invoke(_maxHealth);
        }
    }
}