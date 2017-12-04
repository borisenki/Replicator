using UnityEditor;
using UnityEngine;

public class MakeSquareLevelsDatabase
{
	[MenuItem("Assets/Create/Square Levels Database")]
	public static void CreateSquareLevelsDatabaseAsset()
	{
		SquareLevelsDataBase squareLevelsDataBase = ScriptableObject.CreateInstance<SquareLevelsDataBase>();
		AssetDatabase.CreateAsset(squareLevelsDataBase, "Assets/Resources/SquareLevels.asset");
		AssetDatabase.SaveAssets();
	}
}