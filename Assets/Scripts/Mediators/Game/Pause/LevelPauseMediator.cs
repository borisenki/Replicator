using strange.extensions.mediation.impl;
using UnityEngine;

public class LevelPauseMediator : Mediator
{
    [Inject]
    public LevelPauseView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("OnRegister LevelPauseMediator");
    }

    public override void OnRemove()
    {
        Debug.Log("OnRemove LevelPauseMediator");
    }
}