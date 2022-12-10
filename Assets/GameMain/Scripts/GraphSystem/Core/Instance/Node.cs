using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GraphSystem
{
    public class Node : NodeBase, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
    {
        public Image NodeImage;
        [SerializeField] private float m_ScaleMultipier = 1.5f;
        [SerializeField] private float m_ScacleTime = 0.2f;
        private UI_Graph m_Graph;
        private Vector3 m_DefaultScale = Vector3.one;
        private Sequence m_TweenSeq;
        private const string assetName = "Node";
        public static Node Create(Graph graph, float x, float y)
        {
            Node nodeInstance = null;
            YooAssetUtility.LoadAsset<GameObject>(assetName, successCallback: (GameObject obj) =>
            {
                GameObject objInstance = Instantiate<GameObject>(obj, Vector3.zero, Quaternion.identity, graph.rectTransform);
                nodeInstance = objInstance.GetComponent<Node>();
                nodeInstance.OnInit();
                nodeInstance.rectTransform.localPosition = new Vector2(x, y);
            });
            if(nodeInstance == null)
                Debug.Log("Node is NULL");
            return nodeInstance;
        }

        protected override void Start()
        {
            base.Start();
            m_TweenSeq = DOTween.Sequence();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_TweenSeq.Kill();
            m_TweenSeq.OnStart(() => { this.transform.localScale = m_DefaultScale / m_ScaleMultipier; }).Append(this.transform.DOScale(m_DefaultScale, m_ScacleTime));
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_TweenSeq.Kill();
            m_TweenSeq.OnStart(() => { this.transform.localScale = m_DefaultScale; }).Append(this.transform.DOScale(m_DefaultScale * m_ScaleMultipier, m_ScacleTime));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerId == -1)
            {
                // Instantiate<>();
            }
            else if (eventData.pointerId == -2)
            {

            }
        }

        public void CreateLine()
        {

        }
    }
}