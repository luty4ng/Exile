using UnityEngine;
using QuickKit;

public class ProbeGunMuzzle : MonoBehaviour
{
    private Quaternion m_DefaultDirection;
    void Start()
    {
        m_DefaultDirection = this.transform.localRotation;
    }
    void Update()
    {

    }

    public void Correction(Vector3 lookAt)
    {
        this.transform.LookAt(lookAt);
    }
    public void ResetCorrection()
    {
        Debug.Log("Reset");
        this.transform.localRotation = m_DefaultDirection;
    }

    void OnDrawGizmos()
    {

    }
}