using UnityEngine;

public class InteractiveGameTile : GameTile
{
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
        var x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x; 
        var y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y; 
        Debug.Log("Touch Game Plane [" + x + "," + y + "]");
        if (state == 0)
        {
            state = 1;
            UpdateView();
            foreach (var adjoiningTile in adjoiningTiles)
            {
                if (adjoiningTile)
                {
                    ((InteractiveGameTile) adjoiningTile).Increment();
                }
            }
        }
    }
}
