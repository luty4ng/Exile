
using UnityEngine;
using UnityEditor;

namespace QuickKit
{
    [CustomEditor(typeof(ScriptablePool))]
    public abstract class PoolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ScriptablePool pool = (ScriptablePool)target;
            if (GUILayout.Button("加载数据"))
                pool.Load();

            if (GUILayout.Button("清空数据"))
                pool.Clear();
        }
    }
}
