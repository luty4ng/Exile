using UnityEngine;
using GameKit;

[System.Serializable]
public class NodeConnectCommand : CommandBase<NodeConnectCommand>
{
    public LineBase Line;
    public NodeBase StartNode;
    public NodeBase EndNode;
    public override void Excute()
    {
        StartNode.Connect(EndNode, Line);
        EndNode.Connect(StartNode, Line);
    }

    public override void Revoke()
    {

    }
}