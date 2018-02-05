using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

public class RestartButtonMediator : Mediator
{
	[Inject]
	public RestartButtonView view { get; set; }
	
	[Inject]
	public StartLevelSignal _startLevelSignal { get; set; }
	
	public override void OnRegister()
	{
		Debug.Log("RestartButtonMediator OnRegister");
		view.restart.AddOnce(onRestart);
		view.Init();
	}

	private void onRestart()
	{
		_startLevelSignal.Dispatch(1);
	}

	public override void OnRemove()
	{
		Debug.Log("RestartButtonMediator OnRemove");
		view.restart.RemoveListener(onRestart);
	}
}