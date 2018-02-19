using strange.extensions.mediation.impl;

public class ContinueButtonMediator : Mediator
{
    [Inject]
    public ContinueButtonView view { get; set; }
        
    [Inject]
    public ShowLevelPausedPanelSignal showLevelPausedPanelSignal { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        view.click.AddListener(OnClick);
    }

    private void OnClick()
    {
        showLevelPausedPanelSignal.Dispatch(false);
    }

    public override void OnRemove()
    {
        view.click.RemoveListener(OnClick);
    }
}