using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class ShowSquareGameCommand : Command
{
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView { get; set; }

	[Inject]
	public DatabaseController databaseController { get; set; }
	
	[Inject]
	public int level { get; set; }

	public override void Execute()
	{
		Debug.Log("ShowSquareGameCommand");
		databaseController.CreateGameSettings(level);
		GameObject go = new GameObject();
		go.name = "rooooot";
		go.AddComponent<SquareGameView>();
		go.transform.parent = contextView.transform;
	}
}