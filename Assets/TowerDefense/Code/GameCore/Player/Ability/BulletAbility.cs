using System.Collections;
using UnityEngine;

namespace MyCode
{
    [CreateAssetMenu(fileName = "BulletAbility", menuName = "MyCode/Player/Abiliet/BulletAbility")]
    public class BulletAbility : TargetAbility
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private BulletAbilityConfig _config;

        private Pool<Bullet> _bulletPool;
        private PlayerBody _playerBody;

        public void Construct(PlayerBody playerBody)
        {
            _bulletPool = new Pool<Bullet>(_prefab);
            _playerBody = playerBody;
        }

        public override void Add()
        {
            _count++;
            Timer newTimer = new Timer(_config.AttackDelay);
            _timers.Add(newTimer);
        }

        public override IEnumerator Tick()
        {
            while (true)
            {
                Enemy enemy = _enemyLocator.GetEnemy(_config.AttackRange, _config.Priority);
                if (enemy != null)
                {
                    if (enemy.gameObject.activeInHierarchy)
                    {
                        foreach (Timer timer in _timers)
                        {
                            if (timer.IsTimerEnd)
                            {
                                timer.Start();
                                Bullet bullet = _bulletPool.Get();
                                bullet.transform.position = _playerBody.transform.position;
                                bullet.Init(_config.Damage, _config.BulletSpeed, enemy);
                                yield return new WaitForSeconds(_config.AbilityDelay);
                            }
                        }
                    }
                }

                yield return null;
            }
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}