using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    protected readonly List<T> _poolList = new List<T>();
    protected readonly Transform _parent;

    public readonly T Prefab;
    public IReadOnlyList<T> PoolList => _poolList;

    public Pool(T prefab)
    {
        Prefab = prefab;
        _parent = new GameObject("Pool: " + prefab.name).transform;
    }

    public T Get(bool isActive = true)
    {
        foreach (T poolObject in _poolList)
        {
            if (poolObject.gameObject.activeInHierarchy == false)
            {
                poolObject.gameObject.SetActive(isActive);
                return poolObject;
            }
        }

        return Create();
    }

    public virtual T Create(bool isActive = true)
    {
        T newObject = Object.Instantiate(Prefab, _parent);
        newObject.gameObject.SetActive(isActive);
        _poolList.Add(newObject);
        return newObject;
    }
}