using strange.extensions.mediation.impl;

public class MainMenuMediator : Mediator
{
	[Inject]
	public MainMenuView view { get; set; }

	public override void OnRegister()
	{
		view.Init();
	}

	public override void OnRemove()
	{
		base.OnRemove();
	}
}