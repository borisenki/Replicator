using strange.extensions.mediation.impl;
using UnityEngine;

public class SquareGameView : ScreenView
{
	public GameObject gameScreen;
	public Canvas canvas;
	
	internal void Init()
	{
		gameScreen = Instantiate(Resources.Load("Game/SquareGame")) as GameObject;
		gameScreen.name = "SquareGameView";
		gameScreen.transform.parent = transform;
		canvas = gameScreen.GetComponentInChildren<Canvas>();
		canvas.worldCamera = Camera.main;
		canvas.planeDistance = 1;
	}
}