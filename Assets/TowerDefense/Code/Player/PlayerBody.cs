using UnityEngine;
using Zenject;

namespace TowerDefense
{
    public class PlayerBody : MonoBehaviour
    {
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public void TakeDamage(float damage)
        {
            _player.TakeDamage(damage);
        }
    }
}