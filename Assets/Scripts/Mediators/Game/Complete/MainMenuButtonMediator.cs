using strange.extensions.mediation.impl;

public class MainMenuButtonMediator : Mediator
{
    [Inject]
    public MainMenuButtonView view { get; set; }
    
    [Inject]
    public ShowMenuSignal showMenuSignal { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        view.click.AddListener(OnClick);
    }

    private void OnClick()
    {
        showMenuSignal.Dispatch();
    }

    public override void OnRemove()
    {
        view.click.RemoveListener(OnClick);
    }
}