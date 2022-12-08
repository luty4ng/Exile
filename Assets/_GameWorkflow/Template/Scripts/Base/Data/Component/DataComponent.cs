using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using YooAsset;
using Cysharp.Threading.Tasks;
using UnityGameKit.Runtime;

[DisallowMultipleComponent]
[AddComponentMenu("GameKit/Data Component")]
public partial class DataComponent : GameKitComponent
{
    public List<PoolBase_SO> ScriptablePools;
    private Dictionary<Type, PoolBase_SO> m_ScriptablePoolDics;
    private VarString[] m_CachedStringParams;
    private VarInt32[] m_CachedIntParams;
    public Dictionary<Type, PoolBase_SO> Data_So
    {
        get
        {
            if (m_ScriptablePoolDics == null)
            {
                m_ScriptablePoolDics = new Dictionary<Type, PoolBase_SO>();
                for (int i = 0; i < ScriptablePools.Count; i++)
                    m_ScriptablePoolDics.Add(ScriptablePools[i].GetType(), ScriptablePools[i]);
            }
            return m_ScriptablePoolDics;

        }
    }

    protected override void Awake()
    {
        base.Awake();
        m_CachedStringParams = new VarString[1];
        m_CachedIntParams = new VarInt32[1];

        if (m_ScriptablePoolDics == null)
        {
            m_ScriptablePoolDics = new Dictionary<Type, PoolBase_SO>();
            for (int i = 0; i < ScriptablePools.Count; i++)
                m_ScriptablePoolDics.Add(ScriptablePools[i].GetType(), ScriptablePools[i]);
        }
    }

    public T GetDataSO<T>() where T : PoolBase_SO
    {
        if (m_ScriptablePoolDics.ContainsKey(typeof(T)))
            return m_ScriptablePoolDics[typeof(T)] as T;
        return null;
    }
}