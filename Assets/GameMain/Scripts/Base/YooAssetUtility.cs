using System.ComponentModel;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using YooAsset;
using System;
using UnityEngine.Events;

public static class YooAssetUtility
{
    private static async UniTask InternalLoadAsset<T>(string assetName, UnityAction<T> successCallback) where T : UnityEngine.Object
    {
        AssetOperationHandle handle = YooAssets.LoadAssetAsync<T>(assetName);
        UniTask uniTask = handle.ToUniTask();
        await uniTask;
        if (handle.Status == EOperationStatus.Succeed)
        {
            successCallback.Invoke(handle.AssetObject as T);
        }
    }

    public static async void LoadAsset<T>(string assetName, UnityAction<T> successCallback) where T : UnityEngine.Object
    {
        await InternalLoadAsset(assetName, successCallback);
    }

    public static void ForceUnloadAllAssets()
    {
        YooAsset.YooAssets.ForceUnloadAllAssets();
    }
}






