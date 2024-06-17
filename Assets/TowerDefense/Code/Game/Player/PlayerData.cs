using System;
using UnityEngine;

namespace Code.TowerDefense
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "TowerDefense/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _health = 2000;
        [SerializeField] private float _maxHealth = 2000;

        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        public float GetHealth()
        {
            return _health; 
        }

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

        public void ChangeHealth(float amount)
        {
            float currentHealth = _health - amount;
            SetHealth(currentHealth);
        }

        public void SetHealth(float health)
        {
            _health = health;
            if (_health < 0)
            {
                _health = 0;
            }

            Debug.Log("Update Health: " + _health);
            OnHealth?.Invoke(_health);
        }

        public void SetMaxHealth(float maxHealth)
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