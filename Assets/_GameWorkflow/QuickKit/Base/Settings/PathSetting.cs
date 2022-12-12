using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using QuickKit;
[CreateAssetMenu(menuName = "GameMain/ScenesSetting", fileName = "ScenesSetting", order = 0)]
public class PathSetting : ScriptableObject
{
    [Path] public string ROOT_PATH = "Assets/";
    [Path] public string MAIN_SCENES_PATH = "Assets/GameMain/Scenes/";
    [Path] public string LAUNCHER_PATH = "Assets/_GameWorkflow/GameKit/";
    [Path] public string SCRIPT_PATH = "Assets/_GameWorkflow/QuickKit/Editor/";
    public string LAUNCHER_NAME = "GameLauncher";
}

public static class Settings
{
    public const string ScenesSettingPath = "Assets/_GameWorkflow/QuickKit/";
    private static PathSetting m_PathSetting;
    public static PathSetting PathSetting
    {
        get
        {
            if (m_PathSetting == null)
            {
                string[] files = AssetDatabase.FindAssets("t:PathSetting", new string[] { ScenesSettingPath });
                string assetPath = AssetDatabase.GUIDToAssetPath(files.First());
                if (files.Length >= 1)
                    m_PathSetting = AssetDatabase.LoadAssetAtPath<PathSetting>(assetPath);
                else
                    Debug.LogError("Can not find scenes setting.");
            }
            return m_PathSetting;
        }
    }
}