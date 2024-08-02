using System;
using UniRx;

namespace MyCode
{
    public class WaveFactory : IDisposable
    {
        public event Action<Enemy> OnCreateEnemy = (enemy) => { };

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly Pool<Enemy> _pool;
        private readonly WaveConfig _waveConfig;
        private readonly UpgradeWave[] _upgradeWaveItems;

        private int _increaseDamage = 0;
        private int _increaseArmor = 0;
        private int _increaseMaxHealth = 0;
        private float _increaseCountSpawn = 1;

        public WaveFactory(Pool<Enemy> pool, WaveConfig waveConfig, UpgradeWave[] upgradeWaveItems)
        {
            _pool = pool;
            _waveConfig = waveConfig;
            _upgradeWaveItems = upgradeWaveItems;
            Observable.Timer(TimeSpan.FromSeconds(_waveConfig.StartAwaitTime)).Subscribe(_ =>
            {
                UpdateStats();
                StartSpawn();
            }).AddTo(_disposable);
        }

        public void Dispose()
        {
            if(_disposable != null)
            {
                _disposable.Dispose();
            }
        }

        private void UpdateStats()
        {
            foreach (var upgradeWave in _upgradeWaveItems)
            {
                Observable.Interval(TimeSpan.FromSeconds(upgradeWave.UpdateDelay)).Subscribe(x =>
                {
                    foreach (UpgradeItem upgradeItem in upgradeWave.UpgradeItem)
                    {
                        switch (upgradeItem.UpgradeType)
                        {
                            case UpgradeWaveType.DamagePercent:
                                _increaseDamage += upgradeItem.Count;
                                break;
                            case UpgradeWaveType.HealthPercent:
                                _increaseMaxHealth += upgradeItem.Count;
                                break;
                            case UpgradeWaveType.EnemyCount:
                                _increaseCountSpawn += upgradeItem.Count;
                                break;
                            case UpgradeWaveType.Armor:
                                _increaseArmor += upgradeItem.Count;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }).AddTo(_disposable);
            }
        }

        private void StartSpawn()
        {
            Observable.Timer(TimeSpan.FromSeconds(_waveConfig.SpawnDelay)).Repeat().Subscribe(_ =>
            {
                for (int i = 0; i < _increaseCountSpawn; i++)
                {
                    CreateEnemy();
                }
            }).AddTo(_disposable);
        }

        private void CreateEnemy()
        {
            Enemy enemy = _pool.Get();
            enemy._stats.ResetStats();
            enemy._stats.AddIncreaseArmor(_increaseArmor);
            enemy._stats.AddIncreaseDamage(_increaseDamage);
            enemy._stats.AddIncreaseMaxHealth(_increaseMaxHealth);
            OnCreateEnemy.Invoke(enemy);
        }
    }
}