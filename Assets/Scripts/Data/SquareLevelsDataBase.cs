using System;
using System.Collections.Generic;
using UnityEngine;

public class SquareLevelsDataBase : ScriptableObject
{
	public List<LevelData> LevelDatas;
}

[Serializable]
public class LevelData
{
	public int rows;
	public int colums;
	public int[] planeData;
}