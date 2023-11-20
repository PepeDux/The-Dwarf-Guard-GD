using Godot;
using System;

public partial class CardData : Resource
{
	[ExportGroup("Описание")]
	//Описание карты
	[Export] public string cardDescription { get; set; }



	[ExportGroup("Модификатор")]
	//Модификатор
	[Export] public Resource modifier { get; set; }


	[ExportGroup("Тип карты")]
	//Тип карты
	public Type type;
	public enum Type { positive, negative };

	[ExportGroup("Предзначен для")]
	//Тип карты
	public Accessory accessory;
	public enum Accessory { player, enemy, spawn };
}
