using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickKit
{
    public abstract class ScriptablePool : ScriptableObject, IPoolSO
    {
        [Path] public string DataPath = "Assets";
        public abstract T GetData<T>(string name) where T : ScriptableObject;
        public abstract T GetData<T>(int id) where T : ScriptableObject;
#if UNITY_EDITOR
        public abstract void Load();
        public abstract void Clear();
#endif
    }
}
