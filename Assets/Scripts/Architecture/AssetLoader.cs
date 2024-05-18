using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TD.Architecture
{
    public static class AssetLoader
    {
        public static async Task<T> Load<T>(string keyAsset)
        {
            var handle = Addressables.LoadAssetAsync<T>(keyAsset);
            T loadAsset = await handle.Task;
            if (loadAsset == null)
            {
                throw new NullReferenceException($"Addressables Load Error: {typeof(T)}/{keyAsset} is null");
            }

            return loadAsset;
        }

        public static async Task<T> LoadInstantiate<T>(string keyAsset)
        {
            var handle = Addressables.InstantiateAsync(keyAsset);
            GameObject newGameObject = await handle.Task;
            if(newGameObject.TryGetComponent(out T loadAsset) == false)
            {
                throw new NullReferenceException($"Addressables Load Instantiate Error: {typeof(T)}/{keyAsset} is null");
            }

            return loadAsset;
        }

        public static void UnloadInstance(GameObject unloadGameObject)
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