using strange.extensions.mediation.impl;
using UnityEngine;

public class LevelsView : View
{
    internal void Init()
    {
        GameObject menu = Instantiate(Resources.Load("Levels/LevelsMenu")) as GameObject;
        menu.name = "LevelsMenuView";
        menu.transform.parent = transform;
        Canvas canvas = menu.GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}