using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class LevelGenerator : Node2D
{
	[Export] private TileMap tileMap;

	//Стартовый тайл от которого будут строиться последующие
	Vector2I startTile = new Vector2I(23, 24);
	int countTile;



	public override void _Ready()
	{
		// Подписка на событие на окончание выбора карт
		Events.endSelectCard += Generate;
		// Генерация карты при старте
		Generate();
	}
	public override void _ExitTree()
	{
		Events.endSelectCard -= Generate;
	}



	private void Generate()
	{
		// Очищаем тайлмап от тайлов
		tileMap.Clear();
		// Очищаем холдеры
		GetNode<ClearHolder>("HolderCleaner").ClearAll();
		// Очищаем хранилище координат тайлов
		TileStorage.ClearAllCells();

		// Обнуляем счеткич уровней
		GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").CurrentTurn = 0;

		// Лимит тайлов
		countTile = GetTree().Root.GetNode("GameScene").GetNode<LevelSpawnInfo>("LevelSpawnInfo").TileCount;

		// Увеличивает колличество тайлов после генерации уровня для следующей генерации
		GetTree().Root.GetNode("GameScene").GetNode<LevelSpawnInfo>("LevelSpawnInfo").TileCount += 2;

		//Старотовый тайл
		Tile tile = new Tile(startTile, tileMap);

		for (int i = 0; i < countTile; i++)
		{
			switch (new Random().Next(0, 4))
			{
				//Вверх
				case 0:
					SetTile(new Vector2I(0, -1));
					break;

				//Вниз
				case 1:
					SetTile(new Vector2I(0, 1));
					break;

				//Влево
				case 2:
					SetTile(new Vector2I(-1, 0));
					break;

				//Вправо
				case 3:
					SetTile(new Vector2I(1, 0));
					break;
			}
		}

		for (int x = 0; x < 100; x++)
		{
			for (int y = 0; y < 100; y++)
			{
				if (TileStorage.freeCells.Contains(new Vector2I(x, y)) == false)
				{
					TileStorage.impassableCells.Add(new Vector2I(x, y));
				}
			}
		}



		//Вызываем событие на окончание генерации тайлов
		Events.levelGenerated?.Invoke();
	}

	private async void SetTile(Vector2I route)
	{
		for (int i = 0; i < 100; i++)
		{
			Vector2I coordinate = TileStorage.freeCells.ElementAt(new Random().Next(0, TileStorage.freeCells.Count)) + route;

			if (coordinate.X > FieldCoordinate.xStartPoint &&
				coordinate.X < FieldCoordinate.xFieldSize &&
				coordinate.Y > FieldCoordinate.yStartPoint &&
				coordinate.Y < FieldCoordinate.yFieldSize &&
				TileStorage.freeCells.Contains(coordinate) == false)
			{
				Tile tile = new Tile(coordinate, tileMap);

				break;
			}
			else
			{
				continue;
			}
		}
	}

	private class Tile
	{
		Vector2I coordinate; //Координата тайла на тайлмапе
		Vector2I paletteCoordinate; //Координата тайла на тайловой палитре

		public Tile(Vector2I coordinate, TileMap tileMap)
		{
			Random random = new Random();

			// Координаты массива тайловой палитры
			int xPalette = 5;
			int yPalette = 3;

			// Присваиваем координату тайлу
			this.coordinate = coordinate;
			// Выбираем случайны тайлов из палитры тайлов
			this.paletteCoordinate = new Vector2I(random.Next(1, xPalette + 1), random.Next(1, yPalette + 1));

			// Спавним тайл
			tileMap.SetCell(0, this.coordinate, 0, this.paletteCoordinate);

			// Записываем тайл в список свободных тайлов
			TileStorage.freeCells.Add(this.coordinate);
		}
	}
}
