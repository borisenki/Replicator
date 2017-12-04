using strange.extensions.mediation.impl;

public class SquareGamePlaneMediator : Mediator
{
	[Inject]
	public SquareGamePlaneView view { get; set; }

	[Inject]
	public DatabaseController databaseController { get; set; }

	public override void OnRegister()
	{
		view.levelData = databaseController.GetLevelData(1);
		view.Init();
	}

	public override void OnRemove()
	{
		base.OnRemove();
	}
}