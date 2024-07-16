using UnityEngine;

namespace MyCode
{
    public class PlayerBody : MonoBehaviour, IService
    {
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        public void TakeDamage(float damage)
        {
            _player.TakeDamage(damage);
        }
    }
}