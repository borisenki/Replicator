using strange.extensions.mediation.impl;
using UnityEngine;

public class PlayPanelNewGameMediator : Mediator
{
    [Inject]
    public PlayPanelNewGameView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("PlayPanelNewGameMediator - OnRegister");
    }

    public override void OnRemove()
    {
        Debug.Log("PlayPanelNewGameMediator - OnRemove");
    }
}