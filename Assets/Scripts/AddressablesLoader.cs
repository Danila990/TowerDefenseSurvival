using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TD
{
    public static class AddressablesLoader
    {
        public static async Task<T> Load<T>(AssetReference keyAsset)
        {
            var handle =  keyAsset.LoadAssetAsync<T>();
            await handle.Task;
            if (handle.Status.Equals(AsyncOperationStatus.Failed))
            {
                throw new NullReferenceException($"Addressables Load Error: {typeof(T)}/{keyAsset} is null");
            }

            return handle.Task.Result;
        }

        public static async Task<T> LoadInstantiate<T>(AssetReferenceGameObject keyAsset)
        {
            var handle = keyAsset.InstantiateAsync();
            await handle.Task;
            if (handle.Result.TryGetComponent(out T loadAsset) == false)
            {
                throw new NullReferenceException($"Addressables Load Instantiate Error: {typeof(T)}/{keyAsset} is null");
            }

            return loadAsset;
        }

        public static void UnloadGameobject(GameObject unloadGameObject)
        {
            if(unloadGameObject == null)
            {
                throw new NullReferenceException($"Addressables Unload Instance Error: {unloadGameObject.name} is null");
            }

            unloadGameObject.SetActive(false);
            Addressables.ReleaseInstance(unloadGameObject);
            unloadGameObject = null;
        }
    }
}