using strange.extensions.mediation.impl;
using UnityEngine;

public class SquareGameView : View
{
	internal void Init()
	{
		GameObject menu = Instantiate(Resources.Load("Game/SquareGame")) as GameObject;
		menu.name = "SquareGameView";
		menu.transform.parent = transform;
		Canvas canvas = menu.GetComponentInChildren<Canvas>();
		canvas.worldCamera = Camera.main;
	}
}