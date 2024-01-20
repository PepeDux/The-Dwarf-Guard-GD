using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class TileStorage : Node2D
{
    public static List<Vector2I> freeCells = new List<Vector2I>(); //Все свободные клетки
    public static List<Vector2I> occupiedCells = new List<Vector2I>(); //Все занятые клетки
    public static List<Vector2I> impassableCells = new List<Vector2I>(); //Клетки на которые нельзя наступить
    public static List<Vector2I> functionalCells = new List<Vector2I>(); //Функциональные объекты

    public static List<Character> characters = new List<Character>(); //Список всех персонажей на сцене



    public static void ClearAllCells()
    {
        freeCells.Clear();
        impassableCells.Clear();
        functionalCells.Clear();
        functionalCells.Clear();
    }
    public static void AddCharacter(Character character)
    {
        characters.Add(character);
        occupiedCells.Add(character.coordinate);
        impassableCells.Add(character.coordinate);
        occupiedCells.Add(character.coordinate);
    }

    public static void RemoveCharacter(Character character)
    {
        characters.Remove(character);
        occupiedCells.Remove(character.coordinate);
        impassableCells.Remove(character.coordinate);
        occupiedCells.Remove(character.coordinate);
    }
}
