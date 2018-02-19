using strange.extensions.mediation.impl;
using UnityEngine;

public class MainMenuMediator : Mediator
{
	[Inject]
	public MainMenuView view { get; set; }
	
	[Inject]
	public ShowPlayPanelNewGameSignal showPlayPanelNewGameSignal { get; set; }

	public override void OnRegister()
	{
		view.Init();
		showPlayPanelNewGameSignal.AddListener(onShowPlayPanelNewGame);
	}

	private void onShowPlayPanelNewGame()
	{
		PlayPanelNewGameView panel = view.canvas.GetComponentInChildren<PlayPanelNewGameView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(true);
		}
	}

	public override void OnRemove()
	{
		Debug.Log("OnRemove");
		showPlayPanelNewGameSignal.RemoveListener(onShowPlayPanelNewGame);
	}
}