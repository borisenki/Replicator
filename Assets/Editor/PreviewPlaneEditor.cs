using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PreviewPlaneView))]
public class PreviewPlaneEditor : Editor
{
	public override void OnInspectorGUI()
	{
		PreviewPlaneView previewPlaneView = (PreviewPlaneView) target;
		
		if (DrawDefaultInspector())
		{
			//
		}
		
		/*
		if (GUILayout.Button("Generate"))
		{
			previewPlaneView.GeneratePreview();
		}
		*/
	}
}