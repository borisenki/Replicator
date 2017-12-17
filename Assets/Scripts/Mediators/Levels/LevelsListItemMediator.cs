using strange.extensions.mediation.impl;
using Signals;

public class LevelsListItemMediator : Mediator
{
    [Inject]
    public LevelsListItemView view { get; set; }
    
    [Inject]
    public StartLevelSignal startLevelSignal { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        view.clickSignal.AddListener(onClick);
    }

    private void onClick()
    {
        startLevelSignal.Dispatch(view.level);
    }

    public override void OnRemove()
    {
        view.clickSignal.RemoveListener(onClick);
    }
}