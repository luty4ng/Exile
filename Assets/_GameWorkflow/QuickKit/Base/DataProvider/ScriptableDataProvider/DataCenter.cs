using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using QuickKit;

[DisallowMultipleComponent]
[AddComponentMenu("QuickKit/DataCenter")]
public partial class DataCenter : MonoSingletonBase<DataCenter>
{
    public List<ScriptablePool> ScriptablePools;
    private Dictionary<Type, ScriptablePool> m_ScriptablePoolDics;
    public Dictionary<Type, ScriptablePool> Data
    {
        get
        {
            if (m_ScriptablePoolDics == null)
            {
                m_ScriptablePoolDics = new Dictionary<Type, ScriptablePool>();
                for (int i = 0; i < ScriptablePools.Count; i++)
                    m_ScriptablePoolDics.Add(ScriptablePools[i].GetType(), ScriptablePools[i]);
            }
            return m_ScriptablePoolDics;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if (m_ScriptablePoolDics == null)
        {
            m_ScriptablePoolDics = new Dictionary<Type, ScriptablePool>();
            for (int i = 0; i < ScriptablePools.Count; i++)
                m_ScriptablePoolDics.Add(ScriptablePools[i].GetType(), ScriptablePools[i]);
        }
    }

    public ScriptableData GetData<T>(string dataId) where T : ScriptablePool
    {
        if (m_ScriptablePoolDics.ContainsKey(typeof(T)))
        {
            T pool = m_ScriptablePoolDics[typeof(T)] as T;
            return pool.GetData<ScriptableData>(dataId);
        }
        return null;
    }

    public T GetDataPool<T>() where T : ScriptablePool
    {
        if (m_ScriptablePoolDics.ContainsKey(typeof(T)))
            return m_ScriptablePoolDics[typeof(T)] as T;
        return null;
    }
}