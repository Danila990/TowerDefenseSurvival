using System;
using UnityEngine;

namespace Code.TowerDefense
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "TowerDefense/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        [field: SerializeField] public float _health { get; private set; } = 2000;
        [field: SerializeField] public float _maxHealth { get; private set; } = 2000;

        public void ChangeHealth(float health)
        {
            _health = health;
            if (_health < 0)
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