using strange.extensions.mediation.impl;
using UnityEngine;

public class PlayPanelContinueGameMediator : Mediator
{
    [Inject]
    public PlayPanelContinueGameView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("PlayPanelContinueGameView - OnRegister");
    }

    public override void OnRemove()
    {
        Debug.Log("PlayPanelContinueGameView - OnRemove");
    }
}