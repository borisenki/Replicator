using strange.extensions.mediation.impl;
using UnityEngine;

public class UndoButtonMediator : Mediator
{
    [Inject]
    public UndoButtonView view { get; set; }
    
    [Inject]
    public RestorePreviousLevelStateSignal restorePreviousLevelStateSignal { get; set; }
	
    public override void OnRegister()
    {
        Debug.Log("UndoButtonMediator OnRegister");
        view.undo.AddListener(OnUndo);
        view.Init();
    }

    private void OnUndo()
    {
        restorePreviousLevelStateSignal.Dispatch();
    }

    public override void OnRemove()
    {
        Debug.Log("UndoButtonMediator OnRemove");
        view.undo.RemoveListener(OnUndo);
    } 
}