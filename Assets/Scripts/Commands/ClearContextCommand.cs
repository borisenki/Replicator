using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class ClearContextCommand : Command
{
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView { get; set; }

	public override void Execute()
	{
		var childs = contextView.transform.childCount;
		for (var i = childs - 1; i >= 0; i--)
		{
			Object.Destroy(contextView.transform.GetChild(i).gameObject);
		}
	}
}