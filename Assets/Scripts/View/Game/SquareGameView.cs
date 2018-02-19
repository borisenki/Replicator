using UnityEngine;

public class SquareGameView : ScreenView
{
    internal void Init()
    {
        screen = Instantiate(Resources.Load("Game/SquareGame")) as GameObject;
        screen.name = "SquareGameView";
        screen.transform.parent = transform;
        canvas = screen.GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 1;
    }
}