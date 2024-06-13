using System.Collections;
using UnityEngine;
using Zenject;

namespace TD
{
    public class Tower : MonoBehaviour, IDamageable
    {
        private TowerData _stats;

        [Inject]
        private void Construct(TowerData towerStats)
        {
            _stats = towerStats;
        }

        public void TakeDamage(float damage)
        {
            _stats.ChangeHealth(_stats.GetHealth() - damage);
        }
    }
}