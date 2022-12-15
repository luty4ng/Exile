using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class SimulatedBody : MonoBehaviour
{
    [Serializable]
    public class Component
    {
        public bool X = true;
        public bool Y = true;
        public bool Z = true;
    }

    [SerializeField] protected float timeStepMultipier = 1;
    public Component components;
    public float radius;
    public float surfaceGravity;
    public Vector3 initialVelocity;
    public string bodyName = "Unnamed";
    public bool enableRelativity = false;
    Transform meshHolder;

    public Vector3 velocity { get; private set; }
    public float RuntimeMass { get; private set; }
    private float m_DefaultMass;
    Rigidbody rb;
    // IObserver internalObserver;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = RuntimeMass = m_DefaultMass;
        velocity = initialVelocity;
        // if (enableRelativity)
        //     internalObserver = FindObjectOfType<IObserver>();
    }

    public virtual void OnUpdateRuntimeMass()
    {
        // rb.mass = RuntimeMass = m_DefaultMass * Universe.current.SimulationConstant;
    }

    public virtual void OnUpdateTimeStepMultipiler()
    {
        // if (enableRelativity)
        // {
        //     if (internalObserver == null)
        //     {
        //         Debug.LogError("The only IObserver is not exist.");
        //         return;
        //     }

        //     float dst = (internalObserver.rb.position - this.rb.position).magnitude;
        //     float sqrDst = (internalObserver.rb.position - this.rb.position).sqrMagnitude;
        //     float schwarzschildRadius = 2 * RuntimeMass * Universe.current.GravitationalConstant * 1000000f * Universe.current.SimulationConstant * Universe.current.SimulationConstant * Universe.current.SimulationConstant / (Universe.current.LightSpeed * Universe.current.LightSpeed);
        //     // Debug.Log(string.Format("史瓦西半径：{0}，径向距离：{1}", schwarzschildRadius, dst));
        //     timeStepMultipier = 11 - Mathf.Clamp(1 / Mathf.Sqrt(Mathf.Clamp01(1 - (schwarzschildRadius / dst))), 0, 10);
        // }
    }

    // public void UpdateVelocity(SimulatedBody[] allBodies, float timeStep)
    // {
    //     foreach (var otherBody in allBodies)
    //     {
    //         if (otherBody != this)
    //         {
    //             float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
    //             Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
    //             Vector3 acceleration = forceDir * Universe.current.GravitationalConstant * otherBody.mass / sqrDst;
    //             velocity += acceleration * timeStep;
    //         }
    //     }
    // }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep * timeStepMultipier;
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep * timeStepMultipier);
    }

    void OnValidate()
    {
        m_DefaultMass = surfaceGravity * radius * radius / Universe.DefaultGravitationalConstant * Universe.DefaultSimulationConstant;
        meshHolder = transform.GetChild(0);
        meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return rb;
        }
    }

    public Vector3 Position
    {
        get
        {
            return rb.position;
        }
    }
}