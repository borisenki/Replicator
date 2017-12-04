using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Commands
{
	public class StartLevelCommand : Command
	{
		public override void Execute()
		{
			Debug.Log("StartLevelCommand");
			SceneManager.LoadScene("GameScene");
		}
	}
}