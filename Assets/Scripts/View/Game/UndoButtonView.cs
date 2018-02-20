using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class UndoButtonView : View
{
    public Signal undo = new Signal();
	
    internal void Init()
    {
        Debug.Log("UndoButtonView Init");
    }

    private void OnMouseUp()
    {
        undo.Dispatch();
    }
}