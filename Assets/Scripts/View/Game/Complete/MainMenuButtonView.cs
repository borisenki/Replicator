using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class MainMenuButtonView : View
{
    public Signal click;
    
    internal void Init()
    {
        click = new Signal();
    }

    public void OnClick()
    {
        click.Dispatch();
    }
}