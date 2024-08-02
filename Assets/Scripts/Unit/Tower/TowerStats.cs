using System;

[Serializable]
public class TowerStats : StatsBase
{
    public event Action<int> OnMaxHealth = (maxHealth) => { };
    public event Action<int> OnHealth = (health) => { };

    public override void ReduceHealth(int value)
    {
        base.ReduceHealth(value);

        OnHealth.Invoke(Health);
    }

    public override void AddIncreaseMaxHealth(int value)
    {
        base.AddIncreaseMaxHealth(value);

        OnMaxHealth.Invoke(MaxHealth);
    }
}
