using Godot;
using System;

public partial class LevelInfo : Node
{
	[ExportGroup("Юниты на уровне")]
	// Колличество юнитов которые нужно заспавнить при старте уровня
	[Export] public int meleeCount; // Ближники 
	[Export] public int rangeCount; // Дальники
	[Export] public int captainCount; // Капитаны
	[Export] public int wizardCount; // Колдуны

	[ExportGroup("Статичные объекты")]
	// Колличество статичных объектов которые нужно заспавнить при старте уровня
	[Export] public int wallCount; // Стены
	[Export] public int pitCount; // Ямы

	[ExportGroup("Функциональные объекты")]
	// Колличество функциональных объектов которые нужно заспавнить при старте уровня
	[Export] public int trapCount; // Ловушки
	[Export] public int foodCount; // Еда
	[Export] public int moneyCount; // Монеты
	[Export] public int crystalCount; // Кристаллы
    [Export] public int runeCount; // Кристаллы

    [ExportGroup("Тайлы")]
	// Колличество тайлов которые нужно заспавнить при стрте уровня
    [Export] public int tileCount;
}
