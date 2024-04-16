using Godot;
using System;

public partial class BaseObject : Node2D
{
	//[Header("Тайлмап и прочее")]
	[Export] public Vector2I coordinate;
	private TileMap tileMap;

	public override void _Ready()
	{

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

	public void IdleAnimation()
	{
		//GetNode<Sprite2D>("Sprite2D").Play("Idle");
	}
}
