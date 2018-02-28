using System;
using System.Collections.Generic;
using UnityEngine;

public class SquareLevelsDataBase : ScriptableObject
{
	public List<LevelData> LevelDatas;
	public SquareGameSettings CurrentGameSettings;
}

[Serializable]
public class LevelData
{
	public int rows;
	public int colums;
	public int[] planeData;
	public bool completed;
}

[Serializable]
public class SquareGameSettings
{
	public int level;
	public int[] savedState;
	public bool undoUsed;
	public bool newGame;
}