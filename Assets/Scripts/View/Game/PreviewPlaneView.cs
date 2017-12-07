using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class PreviewPlaneView : View
{
	public float cellSize = 0.5f;
	public LevelData levelData;
	public GameObject emptyTile;

	private GameObject board;
	private GameTile[,] tiles;

	internal void Init()
	{
		Debug.Log("Preview Plane Inited");
		ClearBoard();
		FillZeroTiles();
		InitializeTiles();
		board.transform.parent = transform;
		board.transform.localPosition = new Vector3(0, 0, 0);
		board.transform.localScale = new Vector3(1, 1, 1);
		board.SetActive(true);
	}
	
	private void FillZeroTiles()
	{
		for (int i = 0; i < levelData.colums; i++)
		{
			for (int j = 0; j < levelData.rows; j++)
			{
				GameObject instance = Instantiate(emptyTile, new Vector3(i * cellSize, j * cellSize), Quaternion.identity);
				instance.transform.SetParent(board.transform);
				tiles[i, j] = instance.GetComponent<GameTile>();
			}
		}
	}
	
	private void InitializeTiles()
	{
		for (int i = 0; i < levelData.colums; i++)
		{
			for (int j = 0; j < levelData.rows; j++)
			{
				var tile = GetTile(i, j);
				if (tile != null)
				{
					tile.state = levelData.planeData[levelData.colums * i + j];
					tile.UpdateView();
				}
			}
		}
	}

	private GameTile GetTile(int x, int y)
	{
		if (x < 0 || x >= levelData.colums)
		{
			return null;
		}
		if (y < 0 || y >= levelData.rows)
		{
			return null;
		}
		return tiles[x, y];
	}
	
	void ClearBoard()
	{
		if (board != null)
		{
			DestroyImmediate(board);
		}
		board = new GameObject("Board");
		tiles = new GameTile[levelData.colums, levelData.rows];
	}
}
