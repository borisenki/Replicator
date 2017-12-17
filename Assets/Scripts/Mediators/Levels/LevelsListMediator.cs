using strange.extensions.mediation.impl;

public class LevelsListMediator : Mediator
{
    [Inject]
    public LevelsListView view { get; set; }
    
    [Inject]
    public DatabaseController databaseController { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        view.AddItems(databaseController.GetLevelsDatas());
    }

    public override void OnRemove()
    {
        //base.OnRemove();
    }
}