﻿using strange.extensions.mediation.impl;
using UnityEngine;

public class PauseButtonMediator : Mediator
{
    [Inject]
    public PauseButtonView view { get; set; }
    
    [Inject]
    public ShowLevelPausedPanelSignal showLevelPausedPanelSignal { get; set; }
	
    public override void OnRegister()
    {
        Debug.Log("PauseButtonMediator OnRegister");
        view.pause.AddListener(onRestart);
        view.Init();
    }

    private void onRestart()
    {
        //_startLevelSignal.Dispatch(1);
        showLevelPausedPanelSignal.Dispatch(true);
    }

    public override void OnRemove()
    {
        Debug.Log("PauseButtonMediator OnRemove");
        view.pause.RemoveListener(onRestart);
    } 
}