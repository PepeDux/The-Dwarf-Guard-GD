using Godot;
using System;
public partial class Spawner : Node2D
{
	Random random = new Random(); //Великий рандом

	private LevelInfo levelInfo;

	private Vector2I coordinate;
	private bool canPut;

	public LevelInfo generateLevelInfo;


	public override void _Ready()
	{
		generateLevelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

	public void Spawn(PackedScene[] scene)
	{
		if (scene.Length > 0)
		{
			//Проверка всех клеток на их статус
			//tileManager.TileGameObjectUpdatePosition();

			//n-ое попыток на спавн объекта
			for (int i = 0; i < 10; i++)
			{
				if (СheckCoordinate() == true)
				{
					//Спавним объект на сцену исходя из случайного выбраного объекта
					//int random = Random.Range(0, objects.Length);

					BaseObject node = (BaseObject)scene[random.Next(0, scene.Length)].Instantiate();
					AddChild(node);

					node.coordinate = new Vector2I(
						random.Next(FieldCoordinate.xStartPoint, FieldCoordinate.xStartPoint + FieldCoordinate.xFieldSize), //Рандомная координта Х
						random.Next(FieldCoordinate.yStartPoint, FieldCoordinate.yStartPoint + FieldCoordinate.yFieldSize)); //Рандомная кооридната Y

					break;
				}
			}
		}
	}

	public bool СheckCoordinate()
	{
		//Случайная координата в пределах игрового поля
		coordinate = new Vector2I(
			random.Next(FieldCoordinate.xStartPoint, FieldCoordinate.xStartPoint + FieldCoordinate.xFieldSize), //Рандомная координта Х
			random.Next(FieldCoordinate.yStartPoint, FieldCoordinate.yStartPoint + FieldCoordinate.yFieldSize)); //Рандомная кооридната Y

		foreach (var cell in TileStorage.occupiedCells)
		{
			//Если объект присутствует в листе, то его спавн запрещается
			if (coordinate == cell)
			{
				return false;
			}
		}

		return true;
	}
}
