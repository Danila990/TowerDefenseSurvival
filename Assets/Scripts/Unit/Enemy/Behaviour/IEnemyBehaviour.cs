using System;

public interface IEnemyBehaviour
{
    public event Action OnComplete;
    public void Enter(EnemyStats enemyStats);
    public void Exit();
    public void Tick();
}