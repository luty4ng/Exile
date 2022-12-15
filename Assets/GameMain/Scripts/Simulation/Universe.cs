using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickKit;

public class Universe : MonoSingletonBase<Universe>
{
    public const float DefaultSimulationConstant = 1f;
    public const float DefaultGravitationalConstant = 0.000000000067f;
    public const float DefaultPhysicsTimeStep = 0.01f;
    public const long DefaultLightSpeed = 300000000;
    [Range(1, 1000)] public float SimulationConstant = DefaultSimulationConstant;
    public float GravitationalConstant = DefaultGravitationalConstant;
    public float PhysicsTimeStep = DefaultPhysicsTimeStep;
    public long LightSpeed = DefaultLightSpeed;

}