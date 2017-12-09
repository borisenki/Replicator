using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class SquareGamePlaneView : View
{
	public float cellSize = 0.5f;
	public LevelData levelData;
	public GameObject emptyTile;
	public BoxCollider2D boxCollider;
	
	private GameObject board;
	private GameTile[,] tiles;

	private Signal saveLevelSignal;

	public void Init()
	{
		saveLevelSignal = new Signal();
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
		for (int i = 0; i < levelData.rows; i++)
		{
			for (int j = 0; j < levelData.colums; j++)
			{
				GameObject instance = Instantiate(emptyTile, new Vector3(i * cellSize, j * cellSize), Quaternion.identity);
				instance.transform.SetParent(board.transform);
				tiles[i, j] = instance.GetComponent<GameTile>();
			}
		}
	}

	private void InitializeTiles()
	{
		for (int i = 0; i < levelData.rows; i++)
		{
			for (int j = 0; j < levelData.colums; j++)
			{
				var tile = GetTile(i, j);
				var adjoingTile = GetTile(i - 1, j);
				if (adjoingTile)
				{
					tile.AddAdjoiningTile(adjoingTile);
				}
				adjoingTile = GetTile(i + 1, j);
				if (adjoingTile)
				{
					tile.AddAdjoiningTile(adjoingTile);
				}
				adjoingTile = GetTile(i, j - 1);
				if (adjoingTile)
				{
					tile.AddAdjoiningTile(adjoingTile);
				}
				adjoingTile = GetTile(i, j + 1);
				if (adjoingTile)
				{
					tile.AddAdjoiningTile(adjoingTile);
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

	public LevelData GetLevelDataForSave()
	{
		LevelData ld = new LevelData();
		ld.colums = tiles.GetLength(0);
		ld.rows = tiles.GetLength(1);
		ld.planeData = new int[ld.colums * ld.rows];
		for (int i = 0; i < ld.rows; i++)
		{
			for (int j = 0; j < ld.colums; j++)
			{
				ld.planeData[ld.rows * i + j] = tiles[i, j].state;
			}
		}
		return ld;
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

	public void SaveLevel()
	{
		saveLevelSignal.Dispatch();
	}
	
	public Signal SaveLevelSignal
	{
		get { return saveLevelSignal; }
	}
}