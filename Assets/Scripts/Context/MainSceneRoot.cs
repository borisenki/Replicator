using strange.extensions.context.impl;

public class MainSceneRoot : ContextView
{
	private void Awake()
	{
		context = new MainSceneContext(this);
		//context.Start();
	}
}