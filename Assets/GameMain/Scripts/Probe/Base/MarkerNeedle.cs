using UnityEngine;
using UnityGameKit.Runtime;
public class MarkerNeedle : NeedleBase
{
    public ScannerController scannerController;
    [Header("Param")]
    public float initSpeed = 20f;
    public float detectSpeed = 10f;
    [Range(1, 10)] public float detectRange = 5f;
    private Rigidbody rb;
    private Collider coll;
    [SerializeField] private bool EnableDetect = false;
    public override void OnInstantiate()
    {
        base.OnInstantiate();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        this.gameObject.SetActive(true);
        scannerController.ResetScannerDistance();
        // Debug.Log(this.gameObject.activeInHierarchy);
        rb.velocity += transform.forward * Time.deltaTime * initSpeed;
        Master.SlaveNeedles.Add(this);
        EnableDetect = false;
    }

    public override void OnRecycle()
    {
        base.OnRecycle();
        Debug.Log("标记探针把需要的数据返回，并且回到了探枪中");
        Master.SlaveNeedles.Remove(this);
        EnableDetect = false;
        scannerController.ResetScanner();
        Destroy(this.gameObject);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (EnableDetect)
        {
            scannerController.ScanDistance += Time.deltaTime * detectSpeed;
            scannerController.ScanDistance = Mathf.Clamp(scannerController.ScanDistance, 0, detectRange);
        }
    }

    public override void OnActivate()
    {
        base.OnActivate();
        EnableDetect = true;
        Destroy(rb);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log(other.gameObject.layer);
        // Debug.Log("wtf: " + LayerMask.NameToLayer("AttachWall"));
        // Debug.Log(other.gameObject.layer == (1 << LayerMask.NameToLayer("AttachWall")));
        if (other.gameObject.layer == LayerMask.NameToLayer("AttachWall"))
        {
            Vector3 contactPos = other.contacts[0].point;
            Vector3 faceDir = -other.contacts[0].normal;
            this.transform.LookAt(this.transform.position + faceDir);
            OnActivate();
            // Debug.Log(faceDir);
        }
    }
}