using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPlaneController : MonoBehaviour
{
	public float cellSize = 0.5f;
	public LevelData LevelData;
	public GameObject emptyTile;

	private GameObject board;

	public void GeneratePreview()
	{
		Debug.Log("Generate preview");
		//
		ClearBoard();
		board = new GameObject("Board");
		DrawEmptyTiles();
		board.transform.parent = transform;
		board.transform.localPosition = new Vector3(0, 0, 0);
		board.transform.localScale = new Vector3(1, 1, 1);
	}

	public void DrawEmptyTiles()
	{
		//Instantiate()
		for (int i = 0; i < LevelData.colums; i++)
		{
			for (int j = 0; j < LevelData.rows; j++)
			{
				GameObject instance = Instantiate(emptyTile, new Vector3(i * cellSize, j * cellSize), Quaternion.identity);
				instance.transform.SetParent(board.transform);
				//instance.transform.SetParent(transform);
			}
		}
	}
	
	void ClearBoard()
	{
		if (board != null)
		{
			DestroyImmediate(board);
		}
	}
}
