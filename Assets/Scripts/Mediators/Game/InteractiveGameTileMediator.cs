using strange.extensions.mediation.impl;

public class InteractiveGameTileMediator : Mediator
{
    [Inject]
    public InteractiveGameTile view { get; set; }
    
    [Inject]
    public GamePlaneChangedSignal gamePlaneChangedSignal { get; set; }

    public override void OnRegister()
    {
        view.Init();
        view.tileClickedAndChanged.AddListener(onTileChanged);
    }

    private void onTileChanged()
    {
        gamePlaneChangedSignal.Dispatch();
    }

    public override void OnRemove()
    {
        view.tileClickedAndChanged.RemoveListener(onTileChanged);
    }
}