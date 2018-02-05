﻿using strange.extensions.mediation.impl;
using UnityEngine;

public class PauseButtonMediator : Mediator
{
    [Inject]
    public PauseButtonView view { get; set; }
	
    public override void OnRegister()
    {
        Debug.Log("PauseButtonMediator OnRegister");
        view.restart.AddOnce(onRestart);
        view.Init();
    }

    private void onRestart()
    {
        //_startLevelSignal.Dispatch(1);
    }

    public override void OnRemove()
    {
        Debug.Log("PauseButtonMediator OnRemove");
        view.restart.RemoveListener(onRestart);
    } 
}