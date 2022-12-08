using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LineBase : MonoBehaviour
{
    public GraphBase Graph { get; set; }
    public NodeBase StartNode { get; set; }
    public NodeBase EndNode { get; set; }
    public List<NodeBase> CrossNodes { get; set; }

    public virtual void OnInit()
    {

    }

    public virtual void OnUpdate()
    {
        
    }
}