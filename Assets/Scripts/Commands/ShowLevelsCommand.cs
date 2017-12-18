using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class ShowLevelsCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }
    
    public override void Execute()
    {
        Debug.Log("ShowLevelsCommand");
        GameObject go = new GameObject();
        go.name = "rooooot";
        go.AddComponent<LevelsView>();
        go.transform.parent = contextView.transform;
    }
}