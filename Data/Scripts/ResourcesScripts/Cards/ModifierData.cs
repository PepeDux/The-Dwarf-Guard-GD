using Godot;
using System;
using System.ComponentModel;

public partial class ModifierData : Resource
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

    [ExportGroup("Cила карты (1-5)")]
    // Сила карты
    [Export] public int cardStrength;

	[ExportGroup("Тип карты")]
	// Тип карты
	[Export] public Type type;
	public enum Type { positive, negative };

	[ExportGroup("Предзначен для")]
	// Для кого предназначена карта
	[Export] public Accessory accessory;
	public enum Accessory { player, enemy, spawn };
}
