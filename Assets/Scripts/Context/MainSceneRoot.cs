using strange.extensions.context.impl;

public class MainSceneRoot : ContextView
{
	public bool isGame = true;
	
	private void Awake()
	{
		if (isGame)
		{
			context = new MainSceneContext(this);
		}
		//context = new MainSceneContext(this);
		//context.Start();
	}
}