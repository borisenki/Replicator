using strange.extensions.mediation.impl;

public class LevelsMediator : Mediator
{
    [Inject]
    public LevelsView view { get; set; }
    
    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }
}