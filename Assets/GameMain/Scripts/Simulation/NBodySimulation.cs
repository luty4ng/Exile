using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    SimulatedBody[] bodies;
    static NBodySimulation instance;
    static float DefaultTimeStep;
    void Awake()
    {
        bodies = FindObjectsOfType<SimulatedBody>();
        Time.fixedDeltaTime = Universe.current.PhysicsTimeStep;
        Debug.Log("Setting Fixed DeltaTime To: " + Universe.current.PhysicsTimeStep);
        DefaultTimeStep = Universe.current.PhysicsTimeStep;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].OnUpdateRuntimeMass();
            bodies[i].OnUpdateTimeStepMultipiler();
            Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
            bodies[i].UpdateVelocity(acceleration, DefaultTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(DefaultTimeStep);
        }
    }

    public static Vector3 CalculateAcceleration(Vector3 point, SimulatedBody ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body != ignoreBody)
            {
                float sqrDst = (body.Position - point).sqrMagnitude;
                Vector3 forceDir = (body.Position - point).normalized;
                // Debug.Log(Universe.current.GravitationalConstant );
                acceleration += forceDir * Universe.current.GravitationalConstant * body.RuntimeMass / sqrDst;
            }
        }
        
        return acceleration;
    }

    public static SimulatedBody[] Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static NBodySimulation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NBodySimulation>();
            }
            return instance;
        }
    }
}