using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class Player : MonoBehaviour
    {
        private PlayerData _playerData;

        [Inject]
        private void Construct(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void TakeDamage(float damage)
        {
            _playerData.ChangeHealth(damage);
        }
    }
}