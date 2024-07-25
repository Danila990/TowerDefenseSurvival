using UnityEngine;
using Zenject;

public class InjectPool<T> : Pool<T> where T : MonoBehaviour
{
    private readonly DiContainer _diContainer;

    public InjectPool(T prefab, DiContainer diContainer) : base(prefab)
    {
        _diContainer = diContainer;
    }

    public override T Create(bool isActive = true)
    {
        T newObject = _diContainer.InstantiatePrefabForComponent<T>(Prefab, _parent);
        newObject.gameObject.SetActive(isActive);
        _poolList.Add(newObject);
        return newObject;
    }
}
