using strange.extensions.mediation.impl;
using UnityEngine;

public class SquareGamePlaneMediator : Mediator
{
	[Inject]
	public SquareGamePlaneView view { get; set; }

	[Inject]
	public DatabaseController databaseController { get; set; }
	
	[Inject]
	public GamePlaneChangedSignal gamePlaneChangedSignal { get; set; }
	
	[Inject]
	public ShowLevelCompletePanelSignal showLevelCompletePanelSignal { get; set; }

	private int currentLevel;

	public override void OnRegister()
	{
		currentLevel = databaseController.GetCurrentGameSettings().level;
		view.levelData = databaseController.GetLevelData(currentLevel);
		view.Init();
		view.SaveLevelSignal.AddListener(onSaveLevel);
		gamePlaneChangedSignal.AddListener(onPlaneChanged);
	}

	private void onPlaneChanged()
	{
		var levelCompleted = view.CheckGame();
		Debug.Log("Level complete - " + levelCompleted);
		if (levelCompleted)
		{
			// помечаем уровень как пройденный
			databaseController.SetLevelIsCompleted(currentLevel);
			// показываем окошко о пройденом уровне
			showLevelCompletePanelSignal.Dispatch();
		}
		//save curent game plane state
		databaseController.SaveLevelProgress(view.GetLevelDataForSave().planeData);
	}

	private void onSaveLevel()
	{
		databaseController.AddLevelData(view.GetLevelDataForSave());
	}

	public override void OnRemove()
	{
		view.SaveLevelSignal.RemoveListener(onSaveLevel);
		gamePlaneChangedSignal.RemoveListener(onPlaneChanged);
	}
}