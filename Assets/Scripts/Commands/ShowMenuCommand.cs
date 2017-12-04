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
			
			MainMenuView mainMenu = contextView.AddComponent<MainMenuView>();
			mainMenu.transform.parent = contextView.transform;

			//contextView.AddComponent<MainMenuView>();
			//var menuView = contextView.GetComponent<MainMenuView>();
			//menuView.transform.parent = contextView.transform;
			//mainMenu.transform.parent = contextView.transform;
		}
	}
}