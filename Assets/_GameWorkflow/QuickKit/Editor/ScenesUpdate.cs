using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public static class ScenesUpdate
{
    [MenuItem("QuickKit/ScenesUpdate-All")]
    public static void UpdateScenesAll()
    {
        string scenesMenuPath = Path.Combine(Settings.PathSetting.SCRIPT_PATH + "/ScenesList.cs");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("using UnityEditor;");
        stringBuilder.AppendLine("using UnityEditor.SceneManagement;");
        stringBuilder.AppendLine("public static class ScenesList");
        stringBuilder.AppendLine("{");

        foreach (string sceneGuid in AssetDatabase.FindAssets("t:Scene", new string[] { Settings.PathSetting.ROOT_PATH }))
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            string methodName = scenePath.Replace('/', '_').Replace('\\', '_').Replace('.', '_').Replace('-', '_').Replace(' ', '_');
            stringBuilder.AppendLine(string.Format("        [MenuItem(\"Scenes/{0}\")]", sceneName));
            stringBuilder.AppendLine(string.Format("        public static void {0}() {{ ScenesUpdate.OpenScene(\"{1}\"); }}", methodName, scenePath));
        }
        stringBuilder.AppendLine("}");
        Directory.CreateDirectory(Path.GetDirectoryName(Settings.PathSetting.ROOT_PATH + Settings.PathSetting.SCRIPT_PATH + "/ScenesList.cs"));
        File.WriteAllText(scenesMenuPath, stringBuilder.ToString());
        AssetDatabase.Refresh();
    }

    [MenuItem("QuickKit/ScenesUpdate-Main")]
    public static void UpdateScenesMain()
    {
        string scenesMenuPath = Path.Combine(Settings.PathSetting.SCRIPT_PATH + "/ScenesList.cs");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("using UnityEditor;");
        stringBuilder.AppendLine("using UnityEditor.SceneManagement;");
        stringBuilder.AppendLine("public static class ScenesList");
        stringBuilder.AppendLine("{");

        foreach (string sceneGuid in AssetDatabase.FindAssets("t:Scene", new string[] { Settings.PathSetting.MAIN_SCENES_PATH }))
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            string methodName = scenePath.Replace('/', '_').Replace('\\', '_').Replace('.', '_').Replace('-', '_').Replace(' ', '_');
            if (sceneName.Equals(Settings.PathSetting.LAUNCHER_NAME))
                stringBuilder.AppendLine(string.Format("        [MenuItem(\"Scenes/{0}\", false, 0)]", sceneName));
            else
                stringBuilder.AppendLine(string.Format("        [MenuItem(\"Scenes/{0}\")]", sceneName));
            stringBuilder.AppendLine(string.Format("        public static void {0}() {{ ScenesUpdate.OpenScene(\"{1}\"); }}", methodName, scenePath));
        }
        stringBuilder.AppendLine("}");
        Directory.CreateDirectory(Path.GetDirectoryName(Settings.PathSetting.ROOT_PATH + Settings.PathSetting.SCRIPT_PATH + "/ScenesList.cs"));
        File.WriteAllText(scenesMenuPath, stringBuilder.ToString());
        AssetDatabase.Refresh();
    }

    public static void OpenScene(string filename)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            Debug.Log("Open Scene: " + filename);
            if (EditorSceneManager.sceneCount > 0)
            {
                for (int i = 0; i < EditorSceneManager.sceneCount; i++)
                {
                    EditorSceneManager.UnloadSceneAsync(EditorSceneManager.GetSceneAt(i));
                }
            }
            EditorSceneManager.OpenScene(Settings.PathSetting.LAUNCHER_PATH + Settings.PathSetting.LAUNCHER_NAME + ".unity", OpenSceneMode.Single);
            EditorSceneManager.OpenScene(filename, OpenSceneMode.Additive);
        }

    }
}
