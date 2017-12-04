using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
	[Range(0, 4)]
	public int state = 0;
	public Texture2D[] textures;
	public GameTile[] adjoiningTiles;

	private void Awake()
	{
		adjoiningTiles= new GameTile[4];
		UpdateView();
	}

	public void UpdateView()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		var texture = textures[state];
		spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
		Debug.Log("GameTile Updated");
	}

	public void AddAdjoiningTile(GameTile tile)
	{
		for (int i = 0; i < adjoiningTiles.Length; i++)
		{
			if (adjoiningTiles[i] == null)
			{
				adjoiningTiles[i] = tile;
				return;
			}
		}
	}

	public void Increment()
	{
		if (state != 0)
		{
			if (state == 4)
			{
				state = 1;
			}
			else
			{
				state = state + 1;
			}
			UpdateView();
		}
	}
	
	private void OnMouseUp()
	{
		var x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x; 
		var y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y; 
		Debug.Log("Touch Game Plane [" + x + "," + y + "]");
		if (state == 0)
		{
			state = 1;
			UpdateView();
			foreach (var adjoiningTile in adjoiningTiles)
			{
				if (adjoiningTile)
				{
					adjoiningTile.Increment();
				}
			}
		}
	}
}