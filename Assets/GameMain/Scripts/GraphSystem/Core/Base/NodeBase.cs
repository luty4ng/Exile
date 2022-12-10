using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GraphSystem
{
    public abstract class NodeBase : MonoBehaviour
    {
        public int LocalSerialId { get; set; }
        public string Name { get; set; }
        public GraphBase Graph { get; set; }
        public List<LineBase> IncomeLines { get; set; }
        public List<LineBase> OutcomeLines { get; set; }
        public List<NodeBase> ConnectNodes { get; set; }
        public RectTransform rectTransform;

        protected virtual void Start()
        {
            Debug.Log("UI Node Init.");
            ConnectNodes = new List<NodeBase>();
            IncomeLines = new List<LineBase>();
            OutcomeLines = new List<LineBase>();
        }

        public virtual void ConnectTo(NodeBase otherNode, LineBase line, bool autoPair = true)
        {
            ConnectNodes.Add(otherNode);
            OutcomeLines.Add(line);
            if (autoPair)
                otherNode.ConnectFrom(this, line);
        }

        public virtual void ConnectFrom(NodeBase otherNode, LineBase line, bool autoPair = true)
        {
            ConnectNodes.Add(otherNode);
            IncomeLines.Add(line);
            if (autoPair)
                otherNode.ConnectTo(this, line);
        }

        public virtual void Disconnect(NodeBase otherNode, LineBase line)
        {
            if(ConnectNodes.Contains(otherNode))
                ConnectNodes.Remove(otherNode);
            if(IncomeLines.Contains(line))
                IncomeLines.Remove(line);
            if(OutcomeLines.Contains(line))
                OutcomeLines.Remove(line);
        }


        public void Connect(NodeBase otherNode)
        {

        }

        public virtual void OnConnect()
        {
            Debug.Log(string.Format("Node {0} is connect", Name));
        }

        public virtual void OnInit()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public virtual void OnUpdate()
        {

        }
    }
}