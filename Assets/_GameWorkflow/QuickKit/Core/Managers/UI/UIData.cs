using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using QuickKit;

namespace QuickKit
{
    public class UIData : UIBehaviour
    {
        [HideInInspector] public RectTransform rectTransform;
        protected override void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        protected override void Start()
        {

        }
        public virtual void OnTick() { }
    }
}

