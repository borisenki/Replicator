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

		public override void OnRegister()
		{
			Debug.Log("PlayButtonMediator OnRegister");
			
			view.play.AddOnce(onPlay);
			view.Init();
		}

		private void onPlay()
		{
			_startLevelSignal.Dispatch(1);
		}

		public override void OnRemove()
		{
			Debug.Log("PlayButtonMediator OnRemove");
		}
	}
}