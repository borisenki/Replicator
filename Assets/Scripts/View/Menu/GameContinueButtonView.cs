using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class GameContinueButtonView : View
{
    public Signal click = new Signal();
	
    internal void Init()
    {
        Debug.Log("GameContinueButton Init");
    }
	
    public void OnPlayClick()
    {
        click.Dispatch();
        //SceneManager.LoadScene("GameScene");
    }
}