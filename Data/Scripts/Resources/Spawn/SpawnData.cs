using Godot;
using System;

public partial class SpawnData : Resource
{
	[ExportGroup("Юниты на уровне")]

	[Export] public int melee { get; set; }

	[Export] public int range { get; set; }

	[Export] public int captain { get; set; }

	[Export] public int wizard { get; set; }



	[ExportGroup("Статичные объекты")]

	[Export] public int wall { get; set; }

	[Export] public int pit { get; set; }



	[ExportGroup("Функциональные объекты")]

	[Export] public int trap { get; set; }

	[Export] public int food { get; set; }

	[Export] public int money { get; set; }

	[Export] public int crystal { get; set; }

}
