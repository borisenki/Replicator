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
	public GamePlaneStartChangeSignal gamePlaneStartChangeSignal { get; set; }
	
	[Inject]
	public ShowLevelCompletePanelSignal showLevelCompletePanelSignal { get; set; }
	
	[Inject]
	public RestorePreviousLevelStateSignal restorePreviousLevelStateSignal { get; set; }

	private int currentLevel;

	public override void OnRegister()
	{
		currentLevel = databaseController.GetCurrentGameSettings().level;
		view.levelData = databaseController.GetLevelData(currentLevel);
		view.Init();
		view.SaveLevelSignal.AddListener(onSaveLevel);
		gamePlaneChangedSignal.AddListener(onPlaneChanged);
		gamePlaneStartChangeSignal.AddListener(onStartChange);
		restorePreviousLevelStateSignal.AddListener(OnRestorePlane);

		if (!databaseController.GetCurrentGameSettings().newGame)
		{
			view.applyStates(databaseController.GetCurrentGameSettings().savedState);
		}
	}

	private void onStartChange()
	{
		//save curent game plane state
		databaseController.SaveLevelProgress(view.GetLevelDataForSave().planeData);
	}

	private void OnRestorePlane()
	{
		Debug.Log("OnRestorePlane");
		view.applyStates(databaseController.GetCurrentGameSettings().savedState);
		databaseController.GetCurrentGameSettings().undoUsed = true;
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
	}

	private void onSaveLevel()
	{
		databaseController.AddLevelData(view.GetLevelDataForSave());
	}

	public override void OnRemove()
	{
		view.SaveLevelSignal.RemoveListener(onSaveLevel);
		gamePlaneChangedSignal.RemoveListener(onPlaneChanged);
		gamePlaneStartChangeSignal.RemoveListener(onStartChange);
		restorePreviousLevelStateSignal.RemoveListener(OnRestorePlane);
	}
}