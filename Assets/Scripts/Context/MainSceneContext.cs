using System.Collections;
using System.Collections.Generic;
using Commands;
using Mediators;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Signals;
using UnityEngine;

public class MainSceneContext : MVCSContext
{
	public MainSceneContext(MonoBehaviour view) : base(view)
	{
	}

	public MainSceneContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	public MainSceneContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping)
	{
	}
	
	// Override Start so that we can fire the StartSignal 
	public override IContext Start()
	{
		base.Start();
		AppStartSignal startSignal= injectionBinder.GetInstance<AppStartSignal>();
		startSignal.Dispatch();
		return this;
	}

	protected override void addCoreComponents()
	{
		base.addCoreComponents();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}

	protected override void mapBindings()
	{	
		commandBinder.Bind<AppStartSignal>().InSequence()
			.To<AppStartCommand>()
			.To<ShowMenuCommand>()
			.Once();
		
		commandBinder.Bind<StartLevelSignal>().InSequence()
			.To<ClearContextCommand>()
			.To<ShowSquareGameCommand>();

		mediationBinder.BindView<PlayButtonView>().ToMediator<PlayButtonMediator>();
		mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
		mediationBinder.BindView<SquareGameView>().ToMediator<SquareGameMediator>();
		mediationBinder.BindView<SquareGamePlaneView>().ToMediator<SquareGamePlaneMediator>();
		mediationBinder.BindView<PreviewPlaneView>().ToMediator<PreviewPlaneMediator>();

		injectionBinder.Bind<DatabaseController>().ToSingleton();
	}
}