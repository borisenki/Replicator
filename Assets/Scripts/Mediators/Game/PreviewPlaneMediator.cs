using strange.extensions.mediation.impl;

public class PreviewPlaneMediator : Mediator
{
    [Inject]
    public PreviewPlaneView view { get; set; }
    
    [Inject]
    public DatabaseController databaseController { get; set; }

    public override void OnRegister()
    {
        var currentLevel = databaseController.GetCurrentGameSettings().level;
        view.levelData = databaseController.GetLevelData(currentLevel);
        view.Init();
    }

    public override void OnRemove()
    {
        //
    }
}