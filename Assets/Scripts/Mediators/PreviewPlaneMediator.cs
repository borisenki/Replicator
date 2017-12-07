using strange.extensions.mediation.impl;

public class PreviewPlaneMediator : Mediator
{
    [Inject]
    public PreviewPlaneView view { get; set; }
    
    [Inject]
    public DatabaseController databaseController { get; set; }

    public override void OnRegister()
    {
        view.levelData = databaseController.GetLevelData(1);
        view.Init();
    }

    public override void OnRemove()
    {
        //
    }
}