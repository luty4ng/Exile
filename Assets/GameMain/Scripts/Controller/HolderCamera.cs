using UnityEngine;

public class HolderCamera : MonoBehaviour
{
    public Camera fpsCam;
    void Update()
    {
        if (fpsCam == null)
            return;
        Debug.Log(fpsCam.transform.rotation.eulerAngles);
        this.transform.localPosition = fpsCam.transform.localPosition;
        this.transform.localRotation = fpsCam.transform.localRotation;
    }
}