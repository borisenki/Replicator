using UnityEngine;

public class MainMenuView : ScreenView
{
	internal void Init()
	{
		screen = Instantiate(Resources.Load("Menu/MainMenu")) as GameObject;
		screen.name = "MainMenuView";
		screen.transform.parent = transform;
		canvas = screen.GetComponentInChildren<Canvas>();
		canvas.worldCamera = Camera.main;
	}

	internal void SetupCamera(Camera c)
	{
		//
	}
}