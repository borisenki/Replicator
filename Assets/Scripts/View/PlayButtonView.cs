
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonView : View
{
	public Signal play = new Signal();
	
	internal void Init()
	{
		Debug.Log("PlayButton Init");
	}
	
	public void OnPlayClick()
	{
		play.Dispatch();
		//SceneManager.LoadScene("GameScene");
	}
}