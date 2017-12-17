using strange.extensions.mediation.impl;

public class BackButtonMediator : Mediator
{
    [Inject]
    public BackButtonView view { get; set; }
    
    [Inject]
    public ShowMenuSignal showMenuSignal { get; set; }
    
    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.click.AddOnce(OnClickBack);
    }

    private void OnClickBack()
    {
        showMenuSignal.Dispatch();
    }

    public override void OnRemove()
    {
        //base.OnRemove();
    }
}