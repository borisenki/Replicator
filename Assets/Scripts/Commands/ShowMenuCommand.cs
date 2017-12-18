using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Commands
{
	public class ShowMenuCommand : Command
	{
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		public override void Execute()
		{
			Debug.Log("ShowMenuCommand");
			
			GameObject go = new GameObject();
			go.name = "rooooot";
			go.AddComponent<MainMenuView>();
			go.transform.parent = contextView.transform;
		}
	}
}