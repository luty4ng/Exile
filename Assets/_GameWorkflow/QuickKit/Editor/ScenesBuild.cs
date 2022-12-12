using UnityEngine;
using System.IO;
using UnityEditor;


[CustomEditor(typeof(ScenesBuild))]
public class ScenesBuild : UnityEditor.Editor
{

    [MenuItem("QuickKit/ScenesBuild-All")]
    static void BuildAllScene()
    {
        string[] files = AssetDatabase.FindAssets("t:Scene", new string[] { Settings.PathSetting.ROOT_PATH });
        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[files.Length];
        for (int i = 0; i < files.Length; ++i)
        {
            files[i] = AssetDatabase.GUIDToAssetPath(files[i]);
            scenes[i] = new EditorBuildSettingsScene(files[i], true);
            if (i > 0 && Path.GetFileNameWithoutExtension(files[i]) == Settings.PathSetting.LAUNCHER_NAME)
            {
                var temp = scenes[0];
                scenes[0] = scenes[i];
                scenes[i] = temp;
            }
        }
        EditorBuildSettings.scenes = scenes;
    }

    [MenuItem("QuickKit/ScenesBuild-Main")]
    static void BuildMainScene()
    {
        string[] files = AssetDatabase.FindAssets("t:Scene", new string[] { Settings.PathSetting.MAIN_SCENES_PATH });
        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[files.Length];
        for (int i = 0; i < files.Length; ++i)
        {
            files[i] = AssetDatabase.GUIDToAssetPath(files[i]);
            scenes[i] = new EditorBuildSettingsScene(files[i], true);
            if (i > 0 && Path.GetFileNameWithoutExtension(files[i]) == Settings.PathSetting.LAUNCHER_NAME)
            {
                var temp = scenes[0];
                scenes[0] = scenes[i];
                scenes[i] = temp;
            }
        }
        EditorBuildSettings.scenes = scenes;
    }
}
