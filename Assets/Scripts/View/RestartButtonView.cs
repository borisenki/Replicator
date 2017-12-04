using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class RestartButtonView : View
{
	public Signal restart = new Signal();
	
	internal void Init()
	{
		Debug.Log("RestartButtonView Init");
	}

	public void onClickRestart()
	{
		restart.Dispatch();
	}
}