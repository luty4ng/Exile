using UnityEngine;
using QuickKit;
using UnityGameKit.Runtime;

public class NeedleFactory : MonoSingletonBase<NeedleFactory>
{
    public MarkerNeedle MarkerPrototype;
    public Transform NeedleParent;
    public MarkerNeedle CreateMarker(Vector3 position, Vector3 direction, INeedleMaster master)
    {
        MarkerNeedle needle = Instantiate<MarkerNeedle>(MarkerPrototype, position, direction.ToQuaternion(), NeedleParent);
        needle.Master = master;
        needle.OnInstantiate();
        return needle;
    }
}