using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
        [MenuItem("Scenes/Default")]
        public static void Assets_GameMain_Scenes_Default_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Default.unity"); }
        [MenuItem("Scenes/Exp_Link")]
        public static void Assets_GameMain_Scenes_Exp_Link_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Exp_Link.unity"); }
}
