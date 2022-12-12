using UnityEngine;
public interface IPoolSO
{
    T GetData<T>(string name) where T : ScriptableObject;
    T GetData<T>(int id) where T : ScriptableObject;
}