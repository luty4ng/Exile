using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace QuickKit
{
    [CustomPropertyDrawer(typeof(PathAttribute), false)]
    public class PathDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent content)
        {
            Rect btnRect = new Rect(position);
            position.width -= 60;
            btnRect.x += btnRect.width - 60;
            btnRect.width = 60;
            EditorGUI.BeginProperty(position, content, property);
            EditorGUI.LabelField(position, property.name);
            EditorGUI.PropertyField(position, property, true);
            if (GUI.Button(btnRect, "Select"))
            {
                string path = property.stringValue;
                string selectStr = EditorUtility.OpenFolderPanel("选择路径", path, "");
                string relativePath = Path.GetRelativePath(Application.dataPath, selectStr);
                relativePath = relativePath.Length == 1 ? "" : relativePath;
                relativePath = ("Assets/" + relativePath).Replace("\\", "/") + "/";
                property.stringValue = relativePath;
                property.serializedObject.ApplyModifiedProperties();
                GUIUtility.ExitGUI();
            }
            EditorGUI.EndProperty();
        }
    }
}


