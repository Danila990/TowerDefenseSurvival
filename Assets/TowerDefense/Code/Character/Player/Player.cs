using System;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public class Player : IService
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        [SerializeField] private PlayerConfig _config;

        public PlayerConfig Config => _config;

        public void TakeDamage(float damage)
        {
            float currentHealth = _config.Health - damage;
            SetHealth(currentHealth);
        }

        public void SetHealth(float health)
        {
            _config.Health = health;
            if (_config.Health < 0)
            {
                _config.Health = 0;
            }

            OnHealth?.Invoke(_config.Health);
        }

        public void SetMaxHealth(float maxHealth)
        {
            _config.MaxHealth = maxHealth;
            if (_config.MaxHealth < 0)
            {
                _config.MaxHealth = 0;
            }

            OnMaxHealth?.Invoke(_config.MaxHealth);
        }
    }
}