using Godot;
using System;
using System.Linq;

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
        // Переводим мировые координаты в координаты на тайлмапе
        cellPosition = tileMap.LocalToMap((Vector2I)GetGlobalMousePosition());


		DataBank.currentMouseTarget = CharacterStorage.characters.Where(c => c.coordinate == cellPosition).FirstOrDefault();
	}
}
