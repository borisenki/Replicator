using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameTile))]
public class GameTileEditor : Editor
{
	public override void OnInspectorGUI()
	{
		GameTile gameTile = (GameTile) target;
		
		if (DrawDefaultInspector())
		{
			gameTile.UpdateView();
		}
	}
}