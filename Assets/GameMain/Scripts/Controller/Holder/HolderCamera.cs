using UnityEngine;

[RequireComponent(typeof(Camera))]
public class HolderCamera : MonoBehaviour
{
    public Camera fpsCam;
    public ShootableAim fpsAim;
    [Range(50f, 200f)] public float MaxDetectRange = 50f;

    private ProbeGunMuzzle tmpMuzzle;
    private GameObject m_CastGameObject;
    private Ray m_Ray;
    private RaycastHit m_RayCastHit;

    [Space]
    [SerializeField] private Vector3 m_OrginPos;
    [SerializeField] private Vector3 m_Direction;
    [SerializeField] private Vector3 previewHitPos;


    private void Start()
    {
        fpsCam = fpsCam == null ? FindObjectOfType<FPSController>().fpsCam : fpsCam;
        tmpMuzzle = tmpMuzzle == null ? FindObjectOfType<ProbeGunMuzzle>() : tmpMuzzle;
    }

    void Update()
    {
        // RaycastHit hitInfo = Physics.Raycast();
        UpdateRay();
        // UpdatePos();
    }

    void UpdateRay()
    {
        m_OrginPos = fpsCam.ScreenToWorldPoint(new Vector3(fpsAim.RectTransform.position.x, fpsAim.RectTransform.position.y, 0));
        m_Direction = fpsCam.transform.forward;
        m_Ray = new Ray(m_OrginPos, m_Direction);
        if (Physics.Raycast(m_Ray, out RaycastHit tmpHitInfo, MaxDetectRange))
        {
            m_CastGameObject = tmpHitInfo.transform.gameObject;
            m_RayCastHit = tmpHitInfo;
            tmpMuzzle.Correction(m_RayCastHit.point);
            // Debug.Log(m_CastGameObject.name);
        }
        else
        {
            m_CastGameObject = null;
            tmpMuzzle.ResetCorrection();
        }
        previewHitPos = m_RayCastHit.point;
    }

    void UpdatePos()
    {
        if (fpsCam == null)
            return;
        this.transform.position = fpsCam.transform.position;
        this.transform.rotation = fpsCam.transform.rotation;
    }

    void OnValidate()
    {
        fpsCam = FindObjectOfType<FPSController>().fpsCam;
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(m_OrginPos, m_OrginPos + m_Direction * MaxDetectRange);

            if (m_CastGameObject != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(m_OrginPos, m_RayCastHit.point);
            }
        }
    }
}