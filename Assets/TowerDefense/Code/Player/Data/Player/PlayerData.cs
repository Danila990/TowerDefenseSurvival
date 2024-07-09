using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "TowerDefense/Player/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private PlayerConfig _config;

        public PlayerConfig Config => _config;
    }
}