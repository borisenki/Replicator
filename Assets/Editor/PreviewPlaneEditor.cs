using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PreviewPlaneController))]
public class PreviewPlaneEditor : Editor
{
	public override void OnInspectorGUI()
	{
		PreviewPlaneController previewPlaneController = (PreviewPlaneController) target;
		
		if (DrawDefaultInspector())
		{
			//
		}
		
		if (GUILayout.Button("Generate"))
		{
			previewPlaneController.GeneratePreview();
		}
	}
}