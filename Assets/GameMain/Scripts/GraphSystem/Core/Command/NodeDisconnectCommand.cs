using UnityEngine;
using QuickKit;

namespace GraphSystem
{
    [System.Serializable]
    public class NodeDisconnectCommand : CommandBase<NodeConnectCommand>
    {
        public LineBase Line;
        public NodeBase StartNode;
        public NodeBase EndNode;
        public override void Excute()
        {
            // StartNode.Connect(EndNode, Line);
            // EndNode.Connect(StartNode, Line);
        }

        public override void Revoke()
        {

        }
    }
}