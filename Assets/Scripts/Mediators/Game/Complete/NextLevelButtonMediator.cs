using strange.extensions.mediation.impl;
using Signals;

public class NextLevelButtonMediator : Mediator
{
    [Inject]
    public NextLevelButtonView view { get; set; }
    
    [Inject]
    public ShowMenuSignal showMenuSignal { get; set; }
    
    [Inject]
    public DatabaseController databaseController { get; set; }
    
    [Inject]
    public StartLevelSignal startLevelSignal { get; set; }
    
    public override void OnRegister()
    {
        view.Init();
        view.click.AddListener(OnClick);
    }

    private void OnClick()
    {
        var currentLevel = databaseController.GetCurrentGameSettings().level;
        if (currentLevel + 1 > databaseController.GetLevelsCount())
        {
            //Пиздуем пока что на главный экран
            showMenuSignal.Dispatch();
        }
        else
        {
            startLevelSignal.Dispatch(currentLevel + 1, true);
        }
    }

    public override void OnRemove()
    {
        view.click.RemoveListener(OnClick);
    }
}