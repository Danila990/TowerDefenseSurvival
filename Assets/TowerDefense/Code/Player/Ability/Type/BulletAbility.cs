using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class BulletAbility : IAbility
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private float _attaclDelay;

        private Pool<Bullet> _bulletPool;

        public async void Init()
        {
            _bulletPool = new Pool<Bullet>(_prefab);
            await Update();
        }

        private async Task Update()
        {
            while (true)
            {
                await Task.Delay((int)_attaclDelay * 1000);
                _bulletPool.Get();
            }
        }
    }
}