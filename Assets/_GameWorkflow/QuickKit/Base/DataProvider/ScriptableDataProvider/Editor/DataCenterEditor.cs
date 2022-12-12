
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataCenter))]
public class DataCenterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DataCenter dataCenter = (DataCenter)target;
        // if (GUILayout.Button("加载数据"))
        // {

        // }

        // if (GUILayout.Button("清空数据"))
        // {
            
        // }
    }

}