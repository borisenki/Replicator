using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BackButtonView : View
{
    public Signal click = new Signal();
    
    internal void Init()
    {
        //
    }

    public void OnClick()
    {
        click.Dispatch();
    }
}