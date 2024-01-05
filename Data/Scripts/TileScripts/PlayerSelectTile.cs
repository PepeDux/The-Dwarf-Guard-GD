﻿using Godot;
using System;

public partial class PlayerSelectTile : Node2D
{
    public Vector2I cellPosition;

	TileMap tileMap;

    public override void _Ready()
    {
		tileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("TileMap");
    }
    public override void _Process(double delta)
	{
		cellPosition = tileMap.LocalToMap((Vector2I)GetGlobalMousePosition()); //Переводим мировые координаты в координаты на тайлмапе
        foreach(var target in TileStorage.characters)
        {
            if (cellPosition == target.coordinate && target is Enemy)
            {
                DataBank.currentMouseTarget = target;
            }
            else
            {
                DataBank.currentMouseTarget = null;
            }
        }
	}
}
