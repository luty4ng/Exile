using UnityEngine;

namespace GraphSystem
{
    public class Line : LineBase
    {
        private const string assetName = "Line";
        public UI_LineRenderer Renderer;
        public static Line Create(Graph graph, Node nodeFrom)
        {
            Vector2 Start = nodeFrom.rectTransform.localPosition;
            Line lineInstance = null;
            YooAssetUtility.LoadAsset<GameObject>(assetName, successCallback: (GameObject obj) =>
            {
                GameObject objInstance = Instantiate<GameObject>(obj, Vector3.zero, Quaternion.identity, graph.rectTransform);
                lineInstance = objInstance.GetComponent<Line>();
                lineInstance.OnInit();
                lineInstance.StartNode = nodeFrom;
                lineInstance.Renderer.AddPoint(nodeFrom.rectTransform.anchoredPosition);
            });
            
            if(lineInstance == null)
                Debug.Log("Can not create line");
            return lineInstance;
        }

        public override void OnInit()
        {
            base.OnInit();
            Renderer = GetComponent<UI_LineRenderer>();
            Renderer.Points.Clear();
        }
    }
}