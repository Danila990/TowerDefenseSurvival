using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public static class AssetLoader
{
    public static async Task<T> Load<T>(AssetReferenceGameObject reference) where T : MonoBehaviour
    {
        var handle = Addressables.InstantiateAsync(reference);
        GameObject loadObject = await handle.Task;
        if (loadObject.TryGetComponent(out T component) == false)
            throw new NullReferenceException($"Object of type {typeof(T)} is null");

        return component;
    }

    public static async Task<T> Load<T>(AssetReferenceScriptableObject reference) where T : ScriptableObject
    {
        var handle = reference.LoadAssetAsync();
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
            return (T)Object.Instantiate(handle.Result);
        else
            throw new NullReferenceException($"Object of type {typeof(T)} is null");
    }
}