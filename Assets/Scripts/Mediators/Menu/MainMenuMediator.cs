using strange.extensions.mediation.impl;
using UnityEngine;

public class MainMenuMediator : Mediator
{
	[Inject]
	public MainMenuView view { get; set; }
	
	[Inject]
	public ShowPlayPanelNewGameSignal showPlayPanelNewGameSignal { get; set; }
	
	[Inject]
	public ShowPlayPanelContinueGameSignal showPlayPanelContinueGameSignal { get; set; }
	
	[Inject]
	public DatabaseController databaseController { get; set; }

	public override void OnRegister()
	{
		databaseController.resetLevelsProgress();
		view.Init();
		showPlayPanelNewGameSignal.AddListener(onShowPlayPanelNewGame);
		showPlayPanelContinueGameSignal.AddListener(onShowPlayPanelContinueGame);
	}

	private void onShowPlayPanelNewGame()
	{
		PlayPanelNewGameView panel = view.canvas.GetComponentInChildren<PlayPanelNewGameView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(true);
		}
	}

	private void onShowPlayPanelContinueGame()
	{
		PlayPanelContinueGameView panel = view.canvas.GetComponentInChildren<PlayPanelContinueGameView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(true);
		}
	}

	public override void OnRemove()
	{
		Debug.Log("OnRemove");
		showPlayPanelNewGameSignal.RemoveListener(onShowPlayPanelNewGame);
		showPlayPanelContinueGameSignal.RemoveListener(onShowPlayPanelContinueGame);
	}
}