using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SquareGamePlaneView))]
public class SaveSquareLevel : Editor
{
	public override void OnInspectorGUI()
	{
		SquareGamePlaneView planeView = target as SquareGamePlaneView;
		base.OnInspectorGUI();
		
		if (GUILayout.Button("Save Level"))
		{
			planeView.SaveLevel();
		}
	}
}