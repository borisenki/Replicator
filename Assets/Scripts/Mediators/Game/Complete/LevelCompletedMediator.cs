using strange.extensions.mediation.impl;

public class LevelCompletedMediator : Mediator
{
    [Inject]
    public LevelCompletedView view { get; set; }
    
    [Inject]
    public ShowLevelCompletePanelSignal showLevelCompletePanelSignal { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        showLevelCompletePanelSignal.AddListener(onShowPanel);
    }

    private void onShowPanel()
    {
        view.ShowPanel();
    }

    public override void OnRemove()
    {
        showLevelCompletePanelSignal.RemoveListener(onShowPanel);
    }
}