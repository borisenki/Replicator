using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class PauseButtonView : View
{
    public Signal pause = new Signal();
	
    internal void Init()
    {
        Debug.Log("PauseButtonView Init");
    }

    private void OnMouseUp()
    {
        pause.Dispatch();
    }
}