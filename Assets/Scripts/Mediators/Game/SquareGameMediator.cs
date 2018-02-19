using strange.extensions.mediation.impl;
using UnityEngine;

public class SquareGameMediator : Mediator
{
	[Inject]
	public SquareGameView view { get; set; }
	
	[Inject]
	public ShowLevelCompletePanelSignal showLevelCompletePanelSignal { get; set; }
	
	[Inject]
	public ShowLevelPausedPanelSignal showLevelPausedPanelSignal { get; set; }
	
	[Inject]
	public LockGameSignal lockGameSignal { get; set; }
	
	public override void OnRegister()
	{
		view.Init();
		showLevelCompletePanelSignal.AddListener(onShowCompleteLevelPanel);
		showLevelPausedPanelSignal.AddListener(onShowPauseLevelPanel);
	}

	private void onShowPauseLevelPanel(bool show)
	{
		LevelPauseView panel = view.canvas.GetComponentInChildren<LevelPauseView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(show);
		}
		lockGameSignal.Dispatch(show);
	}

	private void onShowCompleteLevelPanel()
	{
		LevelCompletedView panel = view.canvas.GetComponentInChildren<LevelCompletedView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(true);
		}
		lockGameSignal.Dispatch(true);
	}

	public override void OnRemove()
	{
		showLevelCompletePanelSignal.RemoveListener(onShowCompleteLevelPanel);
		showLevelPausedPanelSignal.RemoveListener(onShowPauseLevelPanel);
	}
}