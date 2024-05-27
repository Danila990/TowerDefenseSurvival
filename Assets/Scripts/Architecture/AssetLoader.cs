using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TD.Architecture
{
    public static class AssetLoader
    {
        public static async Task<T> Load<T>(AssetReference keyAsset)
        {
            return await Load<T>(keyAsset.RuntimeKey.ToString());
        }

        public static async Task<T> Load<T>(string keyAsset)
        {
            var handle = Addressables.LoadAssetAsync<T>(keyAsset);
            T resultLoad = await handle.Task;
            if (handle.Status.Equals(AsyncOperationStatus.Failed))
            {
                throw new NullReferenceException($"Addressables Load Error: {typeof(T)}/{keyAsset} is null");
            }

            return resultLoad;
        }

        public static async Task<T> LoadInstantiate<T>(AssetReferenceGameObject keyAsset)
        {
            return await LoadInstantiate<T>(keyAsset.RuntimeKey.ToString());
        }

        public static async Task<T> LoadInstantiate<T>(string keyAsset)
        {
            var handle = Addressables.InstantiateAsync(keyAsset);
            GameObject spawnObject = await handle.Task;
            if(spawnObject.TryGetComponent(out T loadAsset) == false)
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