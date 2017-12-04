using System;
using UnityEngine;

public class DatabaseController
{
	private SquareLevelsDataBase _squareLevelsDataBase;
	
	[PostConstruct]
	public void Init()
	{
		_squareLevelsDataBase = Resources.Load<SquareLevelsDataBase>("SquareLevels");
		if (_squareLevelsDataBase)
		{
			Debug.Log("SquareLevels - loaded");
		}
	}

	public LevelData GetLevelData(int level)
	{
		var levelData = _squareLevelsDataBase.LevelDatas[level - 1];
		return levelData;
	}
}