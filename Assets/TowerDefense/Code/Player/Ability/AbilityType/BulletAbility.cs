using System.Collections;

using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "BulletAbility", menuName = "TowerDefense/Player/Ability/Bullet")]
    public class BulletAbility : Ability
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private BulletAbilityConfig _config;

        private Pool<Bullet> _bulletPool;

        public override void Init(PlayerAbility ability, EnemyLocator enemyLocator)
        {
            base.Init(ability, enemyLocator);

            _bulletPool = new Pool<Bullet>(_prefab);
            Coroutines.StartRountine(Tick());
        }

        public override void Upgrade()
        {
            
        }

        public override IEnumerator Tick()
        {
            while (true)
            {
                yield return new WaitForSeconds(_config.AttackDelay);
                if(_enemyLocator.TryGetClosestEnemy(out Enemy closestEnemy))
                {
                    if (!closestEnemy.gameObject.activeInHierarchy)
                    {
                        continue;
                    }

                    Bullet bullet = _bulletPool.Get();
                    bullet.transform.position = _playerAbility.transform.position;
                    bullet.Init(_config.Damage, _config.BulletSpeed, closestEnemy);
                }
            }
        }
    }
}