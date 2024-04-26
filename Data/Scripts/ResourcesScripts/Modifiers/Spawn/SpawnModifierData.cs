using Godot;
using System;

public partial class SpawnModifierData : ModifierData
{
	[ExportGroup("Юниты на уровне")]

	[Export] public int meleeCount { get; set; }

	[Export] public int rangeCount { get; set; }

	[Export] public int captainCount { get; set; }

	[Export] public int wizardCount { get; set; }



	[ExportGroup("Статичные объекты")]

	[Export] public int wallCount { get; set; }

	[Export] public int pitCount { get; set; }



	[ExportGroup("Функциональные объекты")]

	[Export] public int trapCount { get; set; }

	[Export] public int foodCount { get; set; }

	[Export] public int moneyCount { get; set; }

	[Export] public int crystalCount { get; set; }
    [Export] public int runeCount { get; set; }
}
