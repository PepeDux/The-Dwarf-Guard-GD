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

    // Список всех персонажей на сцене
    public static List<Character> characters = new List<Character>();

    // Метод для очистки всех списков клеток
    public static void ClearAllCells()
    {
        freeCells.Clear();
        impassableCells.Clear();
        functionalCells.Clear();
    }

    // Метод для добавления персонажа в хранилище
    public static void AddCharacter(Character character)
    {
        characters.Add(character);
        occupiedCells.Add(character.coordinate);
        impassableCells.Add(character.coordinate);
    }

    // Метод для удаления персонажа из хранилища
    public static void RemoveCharacter(Character character)
    {
        characters.Remove(character);
        occupiedCells.Remove(character.coordinate);
        impassableCells.Remove(character.coordinate);
    }
}
