using System.Collections;
using UnityEngine;
using Zenject;

namespace TD
{
    public class Tower : MonoBehaviour
    {
        private TowerStats _stats;

        [Inject]
        private void Construct(TowerStats towerStats)
        {
            _stats = towerStats;
        }

        public void TakeDamage(float damage)
        {
            _stats.ChangeHealth(_stats._health - damage);
        }
    }
}