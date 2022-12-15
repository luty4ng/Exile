using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ProbeGun : MonoBehaviour, INeedleMaster
{
    public ProbeGunMuzzle Muzzle;

    [Header("Params")]
    public int MarkerCapacity = 3;
    public int TriggerCapacity = 3;
    public int InjectorCapacity = 3;

    [Space]
    private string[] NeedleTypes = new string[] { "MarkerNeedle", "PhaserNeedle", "InjectorNeedle", "TriggerNeedle" };
    private List<NeedleBase> m_Needles = new List<NeedleBase>();
    private List<NeedleBase> m_OccupiedNeedles = new List<NeedleBase>();
    private List<INeedle> m_DeployedNeedles = new List<INeedle>();
    private Dictionary<string, Queue<NeedleBase>> m_IdleNeedles = new Dictionary<string, Queue<NeedleBase>>();
    private Type CurrentNeedleType = typeof(MarkerNeedle);
    public NeedleBase CurrentIdleNeedle
    {
        get
        {
            return m_IdleNeedles[CurrentNeedleType.Name].Peek();
        }
    }

    public List<INeedle> SlaveNeedles
    {
        get
        {
            return m_DeployedNeedles;
        }
        set
        {
            m_DeployedNeedles = value;
        }
    }

    public NeedleBase CurrentActiveNeedle;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CurrentActiveNeedle != null)
            {
                CurrentActiveNeedle.OnRecycle();
                return;
            }
            // Debug.Log(typeof(MarkerNeedle).Name);
            CurrentActiveNeedle = NeedleFactory.current.CreateMarker(Muzzle.transform.position, Muzzle.transform.rotation.eulerAngles, this);
            CurrentActiveNeedle.OnInit();
        }

        for (int i = 0; i < m_DeployedNeedles.Count; i++)
        {
            m_DeployedNeedles[i].OnUpdate();
        }
    }

    void CreateMarker()
    {

    }

    void TestStartUp()
    {
        // m_Needles.Add();
    }
}