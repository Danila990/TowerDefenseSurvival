using System;
using UnityEngine.AddressableAssets;
using UnityEngine;

[Serializable]
public class AssetReferenceScriptableObject : AssetReferenceT<ScriptableObject>
{
    public AssetReferenceScriptableObject(string guid)
        : base(guid)
    {
    }
}