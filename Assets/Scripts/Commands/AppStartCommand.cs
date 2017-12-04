using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
	public class AppStartCommand : Command
	{
		public override void Execute()
		{
			Debug.Log("AppStartCommand");
		}
	}
}