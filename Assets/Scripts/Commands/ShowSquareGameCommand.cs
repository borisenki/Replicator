using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class ShowSquareGameCommand : Command
{
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView { get; set; }

	public override void Execute()
	{
		Debug.Log("ShowSquareGameCommand");
		contextView.AddComponent<SquareGameView>();
	}
}