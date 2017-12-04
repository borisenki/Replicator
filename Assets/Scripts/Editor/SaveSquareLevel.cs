using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SquareGamePlaneView))]
public class SaveSquareLevel : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		if (GUILayout.Button("Save Level"))
		{
			Debug.Log("Level Saved");
		}
	}
}