using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class LevelGenerator : Node2D
{
	[Export] private TileMap tileMap;

	Random random = new Random();

	//Стартовый тайл от которого будут строиться последующие
	Vector2I startTile = new Vector2I(24, 24);
	int countTile = 40;



	public override void _Ready()
	{
		// Подписка на событие на окончание выбора карт
		Events.endSelectCard += Generate;
		// Генерация карты при старте
		Generate();
	}



	private void Generate()
	{
		// Очищаем тайлмап от тайлов
		tileMap.Clear();
		// Очищаем холдеры
		GetNode<ClearHolder>("HolderCleaner").ClearAll();
		// Очищаем хранилище координат тайлов
		TileStorage.ClearAllCells();



		//Старотовый тайл
		Tile tile = new Tile(startTile, tileMap);

		for (int i = 0; TileStorage.freeCells.Count < countTile; i++)
		{
			switch (random.Next(0, 4))
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

		for (int x = 0; x < FieldCoordinate.xFieldSize; x++)
		{
			for (int y = 0; y < FieldCoordinate.yFieldSize; y++)
			{
				if (TileStorage.freeCells.Contains(new Vector2I(FieldCoordinate.xStartPoint + x, FieldCoordinate.yStartPoint + y)) == false)
				{
					TileStorage.impassableCells.Add(new Vector2I(FieldCoordinate.xStartPoint + x, FieldCoordinate.yStartPoint + y));
				}
			}
		}



		//Вызываем событие на окончание генерации тайлов
		Events.levelGenerated?.Invoke();
	}

	private void SetTile(Vector2I route)
	{
		Tile tile = new Tile(TileStorage.freeCells.ElementAt(random.Next(0, TileStorage.freeCells.Count)) + route, tileMap);
	}

	private class Tile
	{
		Vector2I coordinate; //Координата тайла на тайлмапе
		Vector2I paletteCoordinate; //Координата тайла на тайловой палитре

		public Tile(Vector2I coordinate, TileMap tileMap)
		{
			if (TileStorage.freeCells.Contains(coordinate) == false)
			{
				Random random = new Random();

				int xPalette = 5;
				int yPalette = 3;

				this.coordinate = coordinate;
				this.paletteCoordinate = new Vector2I(random.Next(1, xPalette + 1), random.Next(1, yPalette + 1));

				tileMap.SetCell(0, this.coordinate, 0, this.paletteCoordinate);

				TileStorage.freeCells.Add(this.coordinate);
			}
		}
	}
}
