using Godot;
using System;

public partial class BaseObject : Node2D
{
	//[Header("Тайлмап и прочее")]
	[Export] public Vector2I coordinate;
	private TileMap tileMap;


	//private void OnEnable()
	//{
	//    //Подписываемся на событие конца хода игрока 
	//    //LevelManager.levelEnded += Destroy;
	//}

	//private void OnDisable()
	//{
	//    //Отписываемся на событие конца хода игрока 
	//    //LevelManager.levelEnded -= Destroy;
	//}


	public void UpdateCoordinate()
	{
		Position = tileMap.MapToLocal(coordinate); //Привязываем координаты объекта на поле к мировым координатам

		//Если координата объекта оказываектся за пределами границ поля,
		//то его телепортирует на максимально возможное в пределах поля значение координаты по одной из осей
		//-----------------------------------------
		//if (coordinate.Y > TileManager.maxTop)
		//{
		//	coordinate.Y = TileManager.maxTop;
		//}

		//if (coordinate.Y < TileManager.maxDown)
		//{
		//	coordinate.Y = TileManager.maxDown;
		//}

		//if (coordinate.X > TileManager.maxRight)
		//{
		//	coordinate.X = TileManager.maxRight;
		//}

		//if (coordinate.X < TileManager.maxLeft)
		//{
		//	coordinate.X = TileManager.maxLeft;
		//}
		//-----------------------------------------
	}

	public void Destroy()
	{
		//Удаляет объект со сцены
		QueueFree();
	}

	public virtual void Updater()
	{
		UpdateCoordinate();
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
