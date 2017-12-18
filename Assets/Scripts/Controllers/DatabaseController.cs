using System;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController
{
	private SquareLevelsDataBase _squareLevelsDataBase;
	private SquareGameSettings _squareGameSettings;
	
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

	public List<LevelData> GetLevelsDatas()
	{
		return _squareLevelsDataBase.LevelDatas;
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

	public void SetLevelIsCompleted(int level)
	{
		if (_squareLevelsDataBase.LevelDatas.Count >= level)
		{
			_squareLevelsDataBase.LevelDatas[level - 1].completed = true;
		}
	}

	public void CreateGameSettings(int level)
	{
		_squareGameSettings = new SquareGameSettings();
		_squareGameSettings.level = level;
	}

	public SquareGameSettings GetCurrentGameSettings()
	{
		return _squareGameSettings;
	}

	public int GetLevelsCount()
	{
		return _squareLevelsDataBase.LevelDatas.Count;
	}
}