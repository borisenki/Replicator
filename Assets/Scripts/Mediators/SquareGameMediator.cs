using strange.extensions.mediation.impl;

public class SquareGameMediator : Mediator
{
	[Inject]
	public SquareGameView view { get; set; }
	
	public override void OnRegister()
	{
		view.Init();
	}

	public override void OnRemove()
	{
		base.OnRemove();
	}
}