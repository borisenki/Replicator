using strange.extensions.mediation.impl;
using UnityEngine;

public class SquareGameMediator : Mediator
{
	[Inject]
	public SquareGameView view { get; set; }
	
	[Inject]
	public ShowLevelCompletePanelSignal showLevelCompletePanelSignal { get; set; }
	
	public override void OnRegister()
	{
		view.Init();
		showLevelCompletePanelSignal.AddListener(onShowPanel);
	}

	private void onShowPanel()
	{
		LevelCompletedView panel = view.canvas.GetComponentInChildren<LevelCompletedView>(true);
		if (panel)
		{
			panel.gameObject.SetActive(true);
		}
	}

	public override void OnRemove()
	{
		showLevelCompletePanelSignal.RemoveListener(onShowPanel);
	}
}