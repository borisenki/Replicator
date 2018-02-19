using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace Mediators
{
	public class PlayButtonMediator : Mediator
	{
		[Inject]
		public PlayButtonView view { get; set; }

		[Inject]
		public StartLevelSignal _startLevelSignal { get; set; }
		
		[Inject]
		public ShowPlayPanelNewGameSignal showPlayPanelNewGameSignal { get; set; }

		public override void OnRegister()
		{
			Debug.Log("PlayButtonMediator OnRegister");
			
			view.play.AddListener(onPlay);
			view.Init();
		}

		private void onPlay()
		{
			showPlayPanelNewGameSignal.Dispatch();
		}

		public override void OnRemove()
		{
			view.play.RemoveListener(onPlay);
			Debug.Log("PlayButtonMediator OnRemove");
		}
	}
}