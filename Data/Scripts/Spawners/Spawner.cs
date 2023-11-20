using Godot;
using System;
using System.Linq;

public partial class Spawner : Node2D
{
	Random random = new Random(); //Великий рандом

	private Vector2I coordinate; //Переменная для дальнейшего присваивания координаты

	public LevelInfo generateLevelInfo; //Вся информация о том, сколько кого спавнить


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


			//Спавним объект на сцену исходя из случайного выбраного объекта
			//int random = Random.Range(0, scene.Length);

			//n-ое колличество попыток на спавн объекта
			for (int i = 0; i < 20; i++)
			{
				if (CheckCoordinate())
				{
					BaseObject node = (BaseObject)scene[random.Next(0, scene.Length)].Instantiate();
					AddChild(node);

					node.coordinate = coordinate;

					break;
				}
			}
		}
	}

	public bool CheckCoordinate()
	{
		//Рандомная координата из свободных клеток
		Vector2I coordinate = TileStorage.freeCells.ElementAt(random.Next(0, TileStorage.freeCells.Count));

		if (TileStorage.freeCells.Contains(coordinate) == true && TileStorage.occupiedCells.Contains(coordinate) == false)
		{
			this.coordinate = coordinate;
			return true;
		}
		else
		{
			return false;
		}
	}
}
