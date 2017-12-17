using strange.extensions.mediation.impl;
using Signals;

public class LevelsButtonMediator : Mediator
{
    [Inject]
    public LevelsButtonView view { get; set; }
    
    [Inject]
    public ShowLevelsSignal ShowLevelsSignal { get; set; }
    
    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.levels.AddOnce(OnLevelsClick);
    }

    private void OnLevelsClick()
    {
        ShowLevelsSignal.Dispatch();
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }
}