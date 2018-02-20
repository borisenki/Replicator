using strange.extensions.mediation.impl;

public class InteractiveGameTileMediator : Mediator
{
    [Inject]
    public InteractiveGameTile view { get; set; }
    
    [Inject]
    public GamePlaneChangedSignal gamePlaneChangedSignal { get; set; }
    
    [Inject]
    public GamePlaneStartChangeSignal gamePlaneStartChangeSignal { get; set; }
    
    [Inject]
    public LockGameSignal lockGameSignal { get; set; }

    public override void OnRegister()
    {
        view.Init();
        lockGameSignal.AddListener(onGameLock);
        view.tileClickedAndChanged.AddListener(onTileChanged);
        view.tileClickedAndNotChanged.AddListener(onTileStartChange);
    }

    private void onTileStartChange()
    {
        gamePlaneStartChangeSignal.Dispatch();
    }

    private void onGameLock(bool gameLocked)
    {
        view.gameLocked = gameLocked;
    }

    private void onTileChanged()
    {
        gamePlaneChangedSignal.Dispatch();
    }

    public override void OnRemove()
    {
        lockGameSignal.RemoveListener(onGameLock);
        view.tileClickedAndChanged.RemoveListener(onTileChanged);
        view.tileClickedAndNotChanged.RemoveListener(onTileStartChange);
    }
}