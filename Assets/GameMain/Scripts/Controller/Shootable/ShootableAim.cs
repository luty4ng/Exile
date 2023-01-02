using UnityEngine;

public class ShootableAim : MonoBehaviour
{
    private RectTransform m_RectTransform;
    public RectTransform RectTransform
    {
        get
        {
            if(m_RectTransform == null)
                m_RectTransform = GetComponent<RectTransform>();
            return m_RectTransform;
        }
    }
}