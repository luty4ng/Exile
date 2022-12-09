using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GraphSystem
{
    public abstract class LineBase : MonoBehaviour
    {
        public GraphBase Graph { get; set; }
        public NodeBase StartNode { get; set; }
        public NodeBase EndNode { get; set; }
        public List<NodeBase> CrossNodes { get; set; }
        public RectTransform rectTransform;
        public virtual void OnInit()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public virtual void OnUpdate()
        {

        }
    }
}