using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickKit
{
    public abstract class ScriptableData : ScriptableObject, IDataSO
    {
        public abstract string Id { get; }
    }
}

