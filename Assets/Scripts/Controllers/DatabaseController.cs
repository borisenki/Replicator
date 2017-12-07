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

	public void AddLevelData(LevelData levelData)
	{
		_squareLevelsDataBase.LevelDatas.Add(levelData);
		Debug.Log("LevelSaved");
	}

	public LevelData GetLevelData(int level)
	{
		LevelData levelData = null;
		if (_squareLevelsDataBase.LevelDatas.Count >= level)
		{
			levelData = _squareLevelsDataBase.LevelDatas[level - 1];
		}
		if (levelData == null)
		{
			levelData = new LevelData();
			levelData.colums = 7;
			levelData.rows = 7;
			levelData.planeData = new int[49];
		}
		return levelData;
	}
}