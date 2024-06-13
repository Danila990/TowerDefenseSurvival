using System;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "Database/TowerData")]
    public class TowerData : ScriptableObject
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        [SerializeField] private float _health = 2000;
        [SerializeField] private float _maxHealth = 2000;

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

            Debug.Log("Update Health: " + _health);
            OnHealth?.Invoke(_health);
        }

        public void ChangeMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            if (_maxHealth < 0)
            {
                _maxHealth = 0;
            }

            Debug.Log("Update Max Health: " + _health);
            OnMaxHealth?.Invoke(_maxHealth);
        }
    }
}