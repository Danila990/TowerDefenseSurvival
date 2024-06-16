using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.TowerDefense
{
    [Serializable]
    public class AssetReferenceScriptableObject : AssetReferenceT<ScriptableObject>
    {
        public AssetReferenceScriptableObject(string guid) : base(guid)
        {
        }
    }
}