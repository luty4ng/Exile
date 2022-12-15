using UnityEngine;
public interface IObserver
{
    public Camera Cam { get; }
    public Rigidbody Rb { get; }
}