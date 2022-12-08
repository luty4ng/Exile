using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NodeBase : MonoBehaviour
{
    public GraphBase Graph { get; set; }
    public List<LineBase> IncomeLine { get; set; }
    public List<LineBase> OutcomeLine { get; set; }

    public virtual void Connect(NodeBase otherNode, LineBase line)
    {
        
    }

    public virtual void Disconnect(NodeBase otherNode)
    {
        
    }

    public virtual void OnConnect()
    {

    }

    public virtual void OnInit()
    {

    }

    public virtual void OnUpdate()
    {
        
    }
}