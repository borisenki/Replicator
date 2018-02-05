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
		injectionBinder.Bind<GamePlaneChangedSignal>().ToSingleton();
		injectionBinder.Bind<ShowLevelCompletePanelSignal>().ToSingleton();
		
		commandBinder.Bind<AppStartSignal>().InSequence()
			.To<AppStartCommand>()
			.To<ShowMenuCommand>()
			.Once();
		
		commandBinder.Bind<StartLevelSignal>().InSequence()
			.To<ClearContextCommand>()
			.To<ShowSquareGameCommand>();

		commandBinder.Bind<ShowLevelsSignal>().InSequence()
			.To<ClearContextCommand>()
			.To<ShowLevelsCommand>();

		commandBinder.Bind<ShowMenuSignal>().InSequence()
			.To<ClearContextCommand>()
			.To<ShowMenuCommand>();

		mediationBinder.BindView<PlayButtonView>().ToMediator<PlayButtonMediator>();
		mediationBinder.BindView<LevelsButtonView>().ToMediator<LevelsButtonMediator>();
		mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
		
		mediationBinder.BindView<LevelsView>().ToMediator<LevelsMediator>();
		mediationBinder.BindView<LevelsListView>().ToMediator<LevelsListMediator>();
		mediationBinder.BindView<LevelsListItemView>().ToMediator<LevelsListItemMediator>();
		mediationBinder.BindView<BackButtonView>().ToMediator<BackButtonMediator>();
		
		mediationBinder.BindView<SquareGameView>().ToMediator<SquareGameMediator>();
		mediationBinder.BindView<InteractiveGameTile>().ToMediator<InteractiveGameTileMediator>();
		mediationBinder.BindView<SquareGamePlaneView>().ToMediator<SquareGamePlaneMediator>();
		mediationBinder.BindView<PreviewPlaneView>().ToMediator<PreviewPlaneMediator>();
		mediationBinder.BindView<LevelCompletedView>().ToMediator<LevelCompletedMediator>();
		mediationBinder.BindView<NextLevelButtonView>().ToMediator<NextLevelButtonMediator>();
		mediationBinder.BindView<MainMenuButtonView>().ToMediator<MainMenuButtonMediator>();
		mediationBinder.BindView<RestartButtonView>().ToMediator<RestartButtonMediator>();
		mediationBinder.BindView<PauseButtonView>().ToMediator<PauseButtonMediator>();

		injectionBinder.Bind<DatabaseController>().ToSingleton();
	}
}