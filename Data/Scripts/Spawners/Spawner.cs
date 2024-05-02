using Godot;
using System;

public partial class Spawner : Node2D
{
	// Random объект для генерации случайных чисел
	private Random random = new Random();

	// Координата спауна
	private Vector2I spawnCoordinate;

	// Информация о уровне
	public LevelInfo levelInfo;

	// Вызывается при готовности узла
	public override void _Ready()
	{
		// Получаем информацию об уровне при готовности
		levelInfo = GetLevelInfo();
	}

	// Метод для спауна объектов
	public void Spawn(PackedScene[] spawnableScenes, Vector2I spawnCoordinate)
	{
		// Если позиция спауна не указана, спауним на случайной координате
		if (spawnCoordinate == Vector2I.Zero)
		{
			TrySpawnWithRandomCoordinate(spawnableScenes);
		}
		else
		{
			// Иначе спауним на указанной позиции
			this.spawnCoordinate = spawnCoordinate;
			SpawnAtCoordinate(spawnableScenes, spawnCoordinate);			
		}
	}

	// Попытка спауна на случайной координате
	private void TrySpawnWithRandomCoordinate(PackedScene[] spawnableScenes)
	{
		// Пробуем спаунить 100 раз
		for (int i = 0; i < 100; i++)
		{
			if (TryGetRandomCoordinate())
			{
				// Если удалось получить координату, спауним объект на ней
				SpawnObject(spawnableScenes[random.Next(0, spawnableScenes.Length)]);
				break;
			}
		}
	}

	// Получение случайной свободной координаты
	private bool TryGetRandomCoordinate()
	{
		if (TileStorage.freeCells.Count > 0)
		{
			spawnCoordinate = GetRandomFreeCoordinate();
			return IsCoordinateAvailable(spawnCoordinate);
		}
		else
		{
			GD.PrintErr("TileStorage не инициализирован или не содержит свободных ячеек.");
			return false;
		}
	}

	// Попытка спауна на указанной позиции
	private void SpawnAtCoordinate(PackedScene[] spawnableScenes, Vector2I spawnCoordinate)
	{
		SpawnObject(spawnableScenes[random.Next(0, spawnableScenes.Length)]);
	}

	// Получение случайной свободной координаты
	private Vector2I GetRandomFreeCoordinate()
	{
		return TileStorage.freeCells[random.Next(0, TileStorage.freeCells.Count)];
	}

	// Проверка доступности координаты для спауна
	private bool IsCoordinateAvailable(Vector2I coordinate)
	{
		return TileStorage.freeCells.Contains(coordinate) && !TileStorage.occupiedCells.Contains(coordinate);
	}

	// Спаун объекта
	private void SpawnObject(PackedScene scene)
	{
		// Инстанциируем сцену и добавляем объект на сцену
		BaseObject node = (BaseObject)scene.Instantiate();
		node.coordinate = spawnCoordinate;
		AddChild(node);
	}

	// Получение информации об уровне
	private LevelInfo GetLevelInfo()
	{
		// Получаем информацию об уровне из корневого узла сцены
		return GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}
}
