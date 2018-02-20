using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class GameTile : View
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
//		Debug.Log("GameTile Updated");
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

	public void ApplyState(int state)
	{
		this.state = state;
		UpdateView();
	}
}