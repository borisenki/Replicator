﻿using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BackButtonView : View
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