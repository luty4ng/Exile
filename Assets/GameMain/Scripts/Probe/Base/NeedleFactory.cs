using UnityEngine;

public abstract class NeedleFactory
{
    public abstract MarkerNeedle CreateMarker();
    public abstract PhaserNeedle CreatePhaser();
    public abstract InjectorNeedle CreateInjector();
    public abstract TriggerNeedle CreateTrigger();

}