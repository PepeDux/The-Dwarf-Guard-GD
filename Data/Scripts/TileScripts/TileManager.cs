using Godot;
using System;
using System.Collections.Generic;

public partial class TileManager : Node2D
{
	//public Transform parentEnemy; //Родительский объект врагов объектов
	//public Transform parentStaticObject; //Родительский объект статичных объектов
	//public Transform parentFunctionalObject; //Родительский объект функциональных объектов

	[Export] private Player player; //Игрок

	[Export] private TileMap tileMap; //Тайлмап

	

	public static int xStartPoint = 20; //Стартовая координата по X
	public static int yStartPoint = 20; //Стартовая координата по Y

	public static int xField = 8; //Размер ширины игрового поля, начало отсчета с 0
	public static int yField = 8; //Размер высоты игрового поля, начало отсчета с 0

	//Максимальные координаты всех направлений игрового поля
	public static int maxTop = yStartPoint;
	public static int maxDown = yField;
	public static int maxLeft = xStartPoint;
	public static int maxRight = xField;



	public override void _Ready()
	{
		EdgeCalculation();
	}
	public override void _Process(double delta)
	{
		//TileGameObjectUpdatePosition();
	}

	//public void TileGameObjectUpdatePosition()
	//{
	//	//Очищаем все листы от старых данных чтобы их обновить
	//	occupiedCells.Clear();
	//	impassableCells.Clear();
	//	functionalCells.Clear();
	//	enemyCells.Clear();
	//	enemyList.Clear();
	//	allСharacters.Clear();



	//	//Позиция игрока на игровом поле
	//	if (player != null)
	//	{
	//		playerPosition = player.coordinate;
	//	}

	//	//Записываем грани игрового поля в список непроходимых клеток
	//	impassableCells.AddRange(edgeCells);

	//	//Записываем позицию игрока в список непроходимых и занятых клеток
	//	impassableCells.Add(playerPosition);
	//	occupiedCells.Add(playerPosition);

	//	//Перебираем все дочерние объекты из родительского объекта врагов для записи координат в лист
	//	foreach (var node in GetTree().Root.GetNode("GameScene").GetNode<EnemySpawner>("Enemies").GetChildren())
	//	{
	//		if (node != null)
	//		{
	//			impassableCells.Add(node.GetOwner<Enemy>().coordinate);
	//			occupiedCells.Add(node.GetOwner<Enemy>().coordinate);
	//			enemyCells.Add(node.GetOwner<Enemy>().coordinate);
	//			enemyList.Add(node.GetOwner<Enemy>());
	//		}
	//	}

	//	GD.Print(enemyList);

	//	////Перебираем все дочерние объекты из родительского объекта статичных объектов для записи координат в лист
	//	//foreach (Transform node in parentStaticObject.transform)
	//	//{
	//	//	if (node != null)
	//	//	{
	//	//		occupiedCells.Add(node.GetComponent<BaseObject>().coordinate);
	//	//		impassableCells.Add(node.GetComponent<BaseObject>().coordinate);
	//	//	}
	//	//}

	//	////Перебираем все дочерние объекты из родительского объекта ловушек для записи координат в лист
	//	//foreach (Transform node in parentFunctionalObject.transform)
	//	//{
	//	//	if (node != null)
	//	//	{
	//	//		occupiedCells.Add(node.GetComponent<BaseObject>().coordinate);
	//	//	}
	//	//}




	//	allСharacters.AddRange(enemyList);
	//	allСharacters.Add(player);
	//}

	public void EdgeCalculation()
	{
		//Вычисляет границы карты исходя из заданных значений и записывает их в список

		for (int i = xStartPoint; i <= xStartPoint + xField; i++)
		{
			TileStorage.edgeCells.Add(new Vector2I(i, yStartPoint - 1)); //Левая граница
			TileStorage.edgeCells.Add(new Vector2I(i, yStartPoint + yField + 1)); //Правая граница
		}
		for (int j = yStartPoint; j <= yStartPoint + yField; j++)
		{
			TileStorage.edgeCells.Add(new Vector2I(xStartPoint - 1, j)); //Верхняя граница
			TileStorage.edgeCells.Add(new Vector2I(xStartPoint + xField + 1, j)); //Нижняя граница
		}
	}
}
