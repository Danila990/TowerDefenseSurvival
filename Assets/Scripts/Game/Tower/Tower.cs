using System.Collections;
using UnityEngine;
using Zenject;

namespace TD
{
    public class Tower : MonoBehaviour
    {
        private TowerStats stats;

        [Inject]
        private void Construct(TowerStats towerStats)
        {
            stats = towerStats;
        }

        public void TakeDamage(float damage)
        {
            stats.ChangeHealth(stats.GetHealth() - damage);
        }
    }
}