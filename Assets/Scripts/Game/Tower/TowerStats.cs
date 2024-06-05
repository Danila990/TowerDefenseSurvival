using System;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "TowerStats", menuName = "Data/TowerStats")]
    public class TowerStats : ScriptableObject
    {
        public event Action<float> OnHealth;
        public event Action<float> OnMaxHealth;

        [SerializeField] private float health = 2000;

        private float maxHealth;

#if UNITY_EDITOR
        private void OnValidate()
        {
            maxHealth = health;
        }
#endif
        public float GetHealth()
        {
            return health;
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public void ChangeHealth(float health)
        {
            this.health = health;
            if(this.health < 0)
            {
                this.health = 0;
            }

            OnHealth?.Invoke(this.health);
        }

        public void ChangeMaxHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
            if (this.maxHealth < 0)
            {
                this.maxHealth = 0;
            }

            OnMaxHealth?.Invoke(this.maxHealth);
        }
    }
}