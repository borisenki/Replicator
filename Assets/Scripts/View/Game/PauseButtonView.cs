using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class PauseButtonView : View
{
    public Signal restart = new Signal();
	
    internal void Init()
    {
        Debug.Log("PauseButtonView Init");
    }

    private void OnMouseUp()
    {
        restart.Dispatch();
    }
}