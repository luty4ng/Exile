using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GraphSystem
{
    public abstract class GraphBase : MonoBehaviour
    {
        public List<NodeBase> Nodes { get; set; }
        public List<LineBase> Lines { get; set; }

        public virtual void OnInit()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}

