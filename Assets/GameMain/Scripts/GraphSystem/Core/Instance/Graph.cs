using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GraphSystem.Utils;

namespace GraphSystem
{
    public sealed class Graph : GraphBase
    {
        public Vector2Int GridSize = new Vector2Int(40, 30);
        public Vector2 UnitGridSize = new Vector2(1, 1);
        public Vector2 pivot;
        public RectTransform rectTransform;
        public NodeBase GraphCursor;
        private Grid<int> m_GridGraph;
        public override void OnInit()
        {
            base.OnInit();
            // GraphCursor = CursorNode.Create(this);
            m_GridGraph = new Grid<int>(GridSize, UnitGridSize, pivot);
        }

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            Nodes = new List<NodeBase>();
            Lines = new List<LineBase>();
            OnInit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                GenerateRandNode();
            }


            if(Input.GetKey(KeyCode.Space))
            if (GraphCursor != null)
            {
                // Vector3 pos = CursorRay.current.GetHitPosition(1 << LayerMask.NameToLayer("UI"));
                // Debug.Log();
            }
        }

        private void GenerateRandNode()
        {
            float randX = Random.Range(-rectTransform.rect.width / 2, rectTransform.rect.width / 2);
            float randY = Random.Range(-rectTransform.rect.height / 2, rectTransform.rect.height / 2);
            Debug.Log(new Vector2(randX, randY));
            Node nodeInstance = Node.Create(this, randX, randY);
            Nodes.Add(nodeInstance);
        }
    }
}