using Godot;
using System;

public partial class BaseObject : Node2D
{
	//[Header("Тайлмап и прочее")]
	[Export] public Vector2I coordinate;
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
		Position = tileMap.MapToLocal(coordinate); //Привязываем координаты объекта на поле к мировым координатам
	}

	public void FindTileMap()
	{
		tileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("TileMap");
	}
}
