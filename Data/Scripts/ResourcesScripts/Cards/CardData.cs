using Godot;
using System;

public partial class CardData : Resource
{
    [ExportGroup("Изображение")]
    // Изображение карты
    [Export] public Texture2D texture { get; set; }

    [ExportGroup("Название")]
	// Название карты
	[Export] public string name { get; set; }

	[ExportGroup("Описание")]
	// Описание карты
	[Export] public string cardDescription { get; set; }



	[ExportGroup("Модификатор")]
	// Модификатор
	[Export] public Resource modifier { get; set; }



	[ExportGroup("Тип карты")]
	// Тип карты
	[Export] public Type type;
	public enum Type { positive, negative };

	[ExportGroup("Предзначен для")]
	// Для кого предназначена карта
	[Export] public Accessory accessory;
	public enum Accessory { player, enemy, spawn };
}
