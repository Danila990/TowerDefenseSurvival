using UnityEngine;

public class Tower : MonoBehaviour, IDamageable
{
    [field: SerializeField] public TowerStats _stats { get; private set; }

    public bool IsAlive => gameObject.activeInHierarchy;

    public void TakeDamage(int damage)
    {
        _stats.ReduceHealth(damage);
    }
}
