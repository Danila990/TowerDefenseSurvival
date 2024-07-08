using System;
using UnityEngine;

namespace TowerDefense
{
    public class Player
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        private PlayerConfig _config;

        public float Health => _config.Health;
        public float MaxHealth => _config.MaxHealth;

        public Player(PlayerConfig config)
        {
            _config = config;
        }

        public void TakeDamage(float damage)
        {
            float currentHealth = _config.Health - damage;
            SetHealth(currentHealth);
        }

        public void SetHealth(float health)
        {
            _config.Health = health;
            if (Health < 0)
            {
                _config.Health = 0;
            }

            Debug.Log("Update Health: " + Health);
            OnHealth?.Invoke(Health);
        }

        public void SetMaxHealth(float maxHealth)
        {
            _config.MaxHealth = maxHealth;
            if (MaxHealth < 0)
            {
                _config.MaxHealth = 0;
            }

            Debug.Log("Update Max Health: " + MaxHealth);
            OnMaxHealth?.Invoke(MaxHealth);
        }
    }
}