using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class LevelsListItemView : View
{
    public Signal clickSignal;
    public int level;
    
    internal void Init()
    {
        clickSignal = new Signal();
    }

    public void OnCLickItem()
    {
        clickSignal.Dispatch();
    }
}