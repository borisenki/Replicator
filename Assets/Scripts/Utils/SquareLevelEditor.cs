using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SquareLevelsDataBase))]
public class SquareLevelEditor : Editor
{
	private SquareLevelsDataBase _db;

	private void OnEnable()
	{
		_db = (SquareLevelsDataBase) target;
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Label("Total Elements: " + _db.LevelDatas.Count);

		for (int i = 0; i < _db.LevelDatas.Count; i++)
		{
			GUILayout.BeginHorizontal();
			
			_db.LevelDatas[i].colums = Int32.Parse(GUILayout.TextField(_db.LevelDatas[i].colums.ToString()));
			_db.LevelDatas[i].rows = Int32.Parse(GUILayout.TextField(_db.LevelDatas[i].rows.ToString()));
			if (GUILayout.Button("X"))
			{
				Debug.Log("Remove level");
				RemoveLevel(i);
			}
			
			GUILayout.EndHorizontal();
		}
		
		//base.OnInspectorGUI();
	}

	private void RemoveLevel(int index)
	{
		_db.LevelDatas.RemoveAt(index);
	}
}