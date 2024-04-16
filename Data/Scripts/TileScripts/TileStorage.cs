using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

// Класс для хранения информации о тайлах
public partial class TileStorage : Node2D
{
	// Статические списки для хранения различных типов клеток и персонажей на сцене

	// Все свободные клетки
	public static List<Vector2I> freeCells = new List<Vector2I>();
	// Все занятые клетки
	public static List<Vector2I> occupiedCells = new List<Vector2I>();
	// Клетки на которые нельзя наступить
	public static List<Vector2I> impassableCells = new List<Vector2I>();
	// Функциональные объекты
	public static List<Vector2I> functionalCells = new List<Vector2I>();



	// Метод для очистки всех списков клеток
	public static void ClearAllCells()
	{
		freeCells.Clear();
		impassableCells.Clear();
		functionalCells.Clear();
	}

	// Метод для добавления объекта в хранилище тайлов
	public static void AddCell(BaseObject character)
	{
		occupiedCells.Add(character.coordinate);
		impassableCells.Add(character.coordinate);
	}

	// Метод для удаления объекта из хранилища тайлов
	public static void RemoveCell(BaseObject character)
	{
		occupiedCells.Remove(character.coordinate);
		impassableCells.Remove(character.coordinate);
	}
}
