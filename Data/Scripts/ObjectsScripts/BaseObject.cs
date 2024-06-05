using Godot;
using System;

public partial class BaseObject : Node2D
{
	private Vector2I coordinate;
	public Vector2I Coordinate
	{
		get
		{
			return coordinate;
		}
		set
		{
			coordinate = value;

		}
	}

	private TileMap tileMap;

	public override void _Ready()
	{
		Events.levelEnded += QueueFree;

		FindTileMap();
	}

	public override void _ExitTree()
	{
		Events.levelEnded -= QueueFree;
	}


	public override void _Process(double delta)
	{
		UpdateCoordinate();
	}


	public void UpdateCoordinate()
	{
		// Привязываем координаты объекта на поле к мировым координатам
		Position = tileMap.MapToLocal(Coordinate); 
	}

	public void FindTileMap()
	{
		tileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("TileMap");
	}
}
