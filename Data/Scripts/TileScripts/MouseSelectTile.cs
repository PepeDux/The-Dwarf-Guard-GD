using Godot;
using System;
using System.Linq;

public partial class MouseSelectTile : Node2D
{
    TileMap tileMap;


    private static Vector2I mouseCellPosition;
	public static Vector2I MouseCellPosition
	{
		get
		{
			return mouseCellPosition;
		}
		set
		{

		}
	}

	public override void _Ready()
	{
		tileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("TileMap");
	}
	public override void _Process(double delta)
	{
        // Переводим мировые координаты в координаты на тайлмапе
        mouseCellPosition = tileMap.LocalToMap((Vector2I)GetGlobalMousePosition());

		DataBank.currentMouseTarget = CharacterStorage.characters.Where(c => c.coordinate == mouseCellPosition).FirstOrDefault();
	}
}
