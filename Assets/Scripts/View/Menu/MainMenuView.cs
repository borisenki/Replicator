using UnityEngine;

public class MainMenuView : ScreenView
{
	internal void Init()
	{
		GameObject menu = Instantiate(Resources.Load("Menu/MainMenu")) as GameObject;
		menu.name = "MainMenuView";
		menu.transform.parent = transform;
		Canvas canvas = menu.GetComponentInChildren<Canvas>();
		canvas.worldCamera = Camera.main;
	}

	internal void SetupCamera(Camera c)
	{
		//
	}
}