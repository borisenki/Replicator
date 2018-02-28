using strange.extensions.mediation.impl;
using Signals;

public class GameContinueButtonMediator : Mediator
{
    [Inject]
    public GameContinueButtonView view { get; set; }

    [Inject]
    public StartLevelSignal _startLevelSignal { get; set; }
    
    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.click.AddOnce(OnClick);
    }

    private void OnClick()
    {
        _startLevelSignal.Dispatch(0, false);
    }
}