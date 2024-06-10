using System.Collections;
using UnityEngine;
using Zenject;

namespace TD
{
    public class Tower : MonoBehaviour, IDamageable
    {
        private TowerHealth _stats;

        [Inject]
        private void Construct(TowerHealth towerStats)
        {
            _stats = towerStats;
        }

        public void TakeDamage(float damage)
        {
            _stats.ChangeHealth(_stats.GetHealth() - damage);
        }
    }
}