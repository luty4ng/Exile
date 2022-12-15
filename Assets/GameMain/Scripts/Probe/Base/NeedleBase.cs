using UnityEngine;
public abstract class NeedleBase : MonoBehaviour, INeedle
{
    // private NeedleLogic m_NeedleLogic;
    public INeedleMaster Master { get; set; }
    public virtual void OnInstantiate()
    {

    }

    public virtual void OnInit()
    {
        // m_NeedleLogic = GetComponent<NeedleLogic>();
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnRecycle()
    {

    }
    
    public virtual void OnActivate()
    {

    }
}