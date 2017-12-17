using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class LevelsButtonView : View
{
    public Signal levels = new Signal();
    
    internal void Init()
    {
        Debug.Log("LevelsButton Init");
    }
    
    public void OnLevelsClick()
    {
        levels.Dispatch();
        //SceneManager.LoadScene("GameScene");
    }
}