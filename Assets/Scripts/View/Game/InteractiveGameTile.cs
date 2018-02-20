using strange.extensions.signal.impl;
using UnityEngine;

public class InteractiveGameTile : GameTile
{
    public Signal tileClickedAndChanged;
    public Signal tileClickedAndNotChanged;
    public bool gameLocked { get; set; }

    internal void Init()
    {
        tileClickedAndChanged = new Signal();
        tileClickedAndNotChanged = new Signal();
    }
    
    public void Increment()
    {
        if (state != 0)
        {
            if (state == 4)
            {
                state = 1;
            }
            else
            {
                state = state + 1;
            }
            UpdateView();
        }
    }
    
    private void OnMouseUp()
    {
        if (gameLocked)
        {
            return;
        }
        
        if (state == 0)
        {
            tileClickedAndNotChanged.Dispatch();
            state = 1;
            UpdateView();
            foreach (var adjoiningTile in adjoiningTiles)
            {
                if (adjoiningTile)
                {
                    ((InteractiveGameTile) adjoiningTile).Increment();
                }
            }
            tileClickedAndChanged.Dispatch();
        }
    }
}
