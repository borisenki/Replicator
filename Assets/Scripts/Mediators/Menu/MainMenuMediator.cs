using strange.extensions.mediation.impl;
using UnityEngine;

public class MainMenuMediator : Mediator
{
	[Inject]
	public MainMenuView view { get; set; }

	public override void OnRegister()
	{
		view.Init();
	}

	public override void OnRemove()
	{
		Debug.Log("OnRemove");
	}
}