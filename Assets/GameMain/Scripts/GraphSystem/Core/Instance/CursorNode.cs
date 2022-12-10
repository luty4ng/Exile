using UnityEngine;
namespace GraphSystem
{
    public sealed class CursorNode : NodeBase
    {
        private const string assetName = "CursorNode";
        public static CursorNode Create(Graph graph)
        {
            CursorNode nodeInstance = null;
            YooAssetUtility.LoadAsset<GameObject>(assetName, successCallback: (GameObject obj) =>
            {
                GameObject objInstance = Instantiate<GameObject>(obj, Vector3.zero, Quaternion.identity, graph.rectTransform);
                nodeInstance = objInstance.GetComponent<CursorNode>();
                nodeInstance.OnInit();
            });
            return nodeInstance;
        }

        public override void OnInit()
        {
            base.OnInit();
        }
    }
}

