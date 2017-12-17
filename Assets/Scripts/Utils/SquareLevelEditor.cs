using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

//http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
[CustomEditor(typeof(SquareLevelsDataBase))]
public class SquareLevelEditor : Editor
{
	private SquareLevelsDataBase _db;
	private ReorderableList _list;
	private List<Texture2D> texture2Ds;

	private static int PADDING = 5;
	private static int CELL_SIZE = 20;
	
	private void OnEnable()
	{
		texture2Ds = new List<Texture2D>();
		texture2Ds.Add(Resources.Load("Textures/Tile0") as Texture2D);
		texture2Ds.Add(Resources.Load("Textures/Tile1") as Texture2D);
		texture2Ds.Add(Resources.Load("Textures/Tile2") as Texture2D);
		texture2Ds.Add(Resources.Load("Textures/Tile3") as Texture2D);
		texture2Ds.Add(Resources.Load("Textures/Tile4") as Texture2D);
		
		_db = (SquareLevelsDataBase) target;
		_list = new ReorderableList(serializedObject, serializedObject.FindProperty("LevelDatas"), true, true, false, true);
		_list = CreateList(serializedObject, serializedObject.FindProperty("LevelDatas"));
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		_list.DoLayoutList();
		serializedObject.ApplyModifiedProperties();
	}
	
	ReorderableList CreateList (SerializedObject obj, SerializedProperty prop)
	{
		ReorderableList list = new ReorderableList (obj, prop, true, true, false, true);

		list.drawHeaderCallback = rect => {
			EditorGUI.LabelField (rect, "Square Levels");	
		};

		List<float> heights = new List<float> (prop.arraySize);
		
		Debug.Log(heights.Count);

		list.drawElementCallback = (rect, index, active, focused) => {
			float height = CELL_SIZE * 7 + PADDING * 2;

			try {
				heights [index] = height;
			} catch (ArgumentOutOfRangeException e) {
				Debug.LogWarning (e.Message);
			} finally {
				float[] floats = heights.ToArray ();
				Array.Resize (ref floats, prop.arraySize);
				heights = floats.ToList ();
			}
			
			var columns = _db.LevelDatas[index].colums;
			var rows = _db.LevelDatas[index].rows;
			Rect textureRect;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					textureRect = new Rect(
						rect.x + CELL_SIZE * i + PADDING, 
						rect.y + CELL_SIZE * (rows - j - 1) + PADDING, 
						CELL_SIZE, 
						CELL_SIZE);
					var type = _db.LevelDatas[index].planeData[i * rows + j];
					EditorGUI.DrawPreviewTexture(textureRect, texture2Ds[type]);
				} 
			}
		};

		list.elementHeightCallback = (index) => {
			Repaint ();
			float height = 0;

			try {
				height = heights [index];
			} catch (ArgumentOutOfRangeException e) {
				Debug.LogWarning (e.Message);
			} finally {
				float[] floats = heights.ToArray ();
				Array.Resize (ref floats, prop.arraySize);
				heights = floats.ToList ();
			}

			return height;
		};

		list.drawElementBackgroundCallback = (rect, index, active, focused) => {
			rect.height = heights [index];
			Texture2D tex = new Texture2D (1, 1);
			tex.SetPixel (0, 0, new Color (0.33f, 0.66f, 1f, 0.66f));
			tex.Apply ();
			if (active)
				GUI.DrawTexture (rect, tex as Texture);
		};

		list.onAddDropdownCallback = (rect, li) => {
			var menu = new GenericMenu ();
			menu.AddItem (new GUIContent ("Add Element"), false, () => {
				serializedObject.Update ();
				li.serializedProperty.arraySize++;
				serializedObject.ApplyModifiedProperties ();
			});

			menu.ShowAsContext ();

			float[] floats = heights.ToArray ();
			Array.Resize (ref floats, prop.arraySize);
			heights = floats.ToList ();
		};

		return list;
	}
}