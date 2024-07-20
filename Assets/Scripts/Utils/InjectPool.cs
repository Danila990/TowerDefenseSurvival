using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InjectPool<T> : Pool<T> where T : MonoBehaviour
{
    private readonly IObjectResolver _objectResolver;

    public InjectPool(T prefab, IObjectResolver objectResolver) : base(prefab)
    {
        _objectResolver = objectResolver;
    }

    public override T Create(bool isActive = true)
    {
        T newObject = _objectResolver.Instantiate(Prefab, _parent);
        newObject.gameObject.SetActive(isActive);
        _poolList.Add(newObject);
        return newObject;
    }
}
