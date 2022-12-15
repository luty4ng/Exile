using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeFactory : NeedleFactory
{
    public override MarkerNeedle CreateMarker()
    {
        return null;
    }

    public override PhaserNeedle CreatePhaser()
    {
        return null;
    }

    public override InjectorNeedle CreateInjector()
    {
        return null;
    }

    public override TriggerNeedle CreateTrigger()
    {
        return null;
    }
}
