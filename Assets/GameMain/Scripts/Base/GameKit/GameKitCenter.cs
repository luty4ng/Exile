using UnityEngine;
using UnityGameKit.Runtime;
using YooAsset;

public partial class GameKitCenter : MonoBehaviour
{
    public static YooAssets.EPlayMode GamePlayMode;
    public static bool EditorResourceMode
    {
        get
        {
            return GamePlayMode == YooAssets.EPlayMode.EditorSimulateMode;
        }
    }
    public YooAssets.EPlayMode PlayMode = YooAssets.EPlayMode.EditorSimulateMode;
    private void Start()
    {
        InitComponents();
        InitCustomComponents();
        InitYooAsset();
    }

    private void InitYooAsset()
    {
        GamePlayMode = PlayMode;
        Debug.Log($"资源系统运行模式：{PlayMode}");

        // 编辑器下的模拟模式
        if (PlayMode == YooAssets.EPlayMode.EditorSimulateMode)
        {
            var createParameters = new YooAssets.EditorSimulateModeParameters();
            createParameters.LocationServices = new AddressLocationServices();
            //createParameters.SimulatePatchManifestPath = GetPatchManifestPath();
            YooAssets.InitializeAsync(createParameters);
        }

        // 单机运行模式
        if (PlayMode == YooAssets.EPlayMode.OfflinePlayMode)
        {
            var createParameters = new YooAssets.OfflinePlayModeParameters();
            createParameters.LocationServices = new AddressLocationServices();
            YooAssets.InitializeAsync(createParameters);
        }

        // 联机运行模式
        if (PlayMode == YooAssets.EPlayMode.HostPlayMode)
        {
            var createParameters = new YooAssets.HostPlayModeParameters();
            createParameters.LocationServices = new AddressLocationServices();
            createParameters.DecryptionServices = null;
            createParameters.ClearCacheWhenDirty = false;
            createParameters.DefaultHostServer = GetHostServerURL();
            createParameters.FallbackHostServer = GetHostServerURL();
            createParameters.VerifyLevel = EVerifyLevel.High;
            YooAssets.InitializeAsync(createParameters);
        }

        // 运行补丁流程
        // PatchUpdater.Run();
    }

    private string GetPatchManifestPath()
    {
        string directory = System.IO.Path.GetDirectoryName(Application.dataPath);
        return $"{directory}/Bundles/StandaloneWindows64/UnityManifest_SimulateBuild/PatchManifest_100.bytes";
    }
    private string GetHostServerURL()
    {
        //string hostServerIP = "http://10.0.2.2"; //安卓模拟器地址
        string hostServerIP = "http://127.0.0.1";
        string gameVersion = "v1.0";

#if UNITY_EDITOR
        if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android)
            return $"{hostServerIP}/CDN/Android/{gameVersion}";
        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS)
            return $"{hostServerIP}/CDN/IPhone/{gameVersion}";
        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL)
            return $"{hostServerIP}/CDN/WebGL/{gameVersion}";
        else
            return $"{hostServerIP}/CDN/PC/{gameVersion}";
#else
		if (Application.platform == RuntimePlatform.Android)
			return $"{hostServerIP}/CDN/Android/{gameVersion}";
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
			return $"{hostServerIP}/CDN/IPhone/{gameVersion}";
		else if (Application.platform == RuntimePlatform.WebGLPlayer)
			return $"{hostServerIP}/CDN/WebGL/{gameVersion}";
		else
			return $"{hostServerIP}/CDN/PC/{gameVersion}";
#endif
    }
}


