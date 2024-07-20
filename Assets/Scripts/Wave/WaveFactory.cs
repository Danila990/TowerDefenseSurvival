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

        private int _increaseDamage = 0;
        private int _increaseArmor = 0;
        private int _increaseMaxHealth = 0;
        private float _increaseMoveSpeed = 0;

        public WaveFactory(Pool<Enemy> pool, WaveConfig waveConfig)
        {
            _pool = pool;
            _waveConfig = waveConfig;
            Observable.Timer(TimeSpan.FromSeconds(_waveConfig.StartAwaitTime)).Subscribe(_ =>
            {
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

        private void StartSpawn()
        {
            Observable.Timer(TimeSpan.FromSeconds(_waveConfig.SpawnDelay)).Repeat().Subscribe(_ =>
            {
                CreateEnemy();
            }).AddTo(_disposable);
        }

        private void CreateEnemy()
        {
            Enemy enemy = _pool.Get();
            enemy._stats.AddIncreaseArmor(_increaseArmor);
            enemy._stats.AddIncreaseDamage(_increaseDamage);
            enemy._stats.AddIncreaseMoveSpeed(_increaseMoveSpeed);
            enemy._stats.AddIncreaseMaxHealth(_increaseMaxHealth);
            OnCreateEnemy.Invoke(enemy);
        }
    }
}