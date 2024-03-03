using Godot;
using System;

public partial class CharacteristicModifierData : ModifierData
{
	[ExportGroup("Префаб еффекта")]
	//Сцена еффекта(необязательно)
	[Export] public PackedScene scene { get; set; }



	[ExportGroup("Здоровье")]
	//Здоровье
	[Export(PropertyHint.Range, "-50, 50, 1")] public int HP { get; set; }



	[ExportGroup("Урон наносимый объекту")]
	//Физический урон
	[Export(PropertyHint.Range, "-50, 50, 1")] public int physicalDamage { get; set; }



	[ExportGroup("Очки")]
	//Очки передвижения
	[Export(PropertyHint.Range, "-50, 50, 1")] public int movePoint { get; set; }

	//Очки Действий
	[Export(PropertyHint.Range, "-50, 50, 1")] public int actionPoint { get; set; }

	//Очки пива
	[Export(PropertyHint.Range, "-50, 50, 1")] public int beerPoint { get; set; }



	[ExportGroup("Основнык характеристики")]
	//Сила
	[Export(PropertyHint.Range, "-50, 50, 1")] public int strength { get; set; }

	//Ловкость
	[Export(PropertyHint.Range, "-50, 50, 1")] public int dexterity { get; set; }

	//Интеллект
	[Export(PropertyHint.Range, "-50, 50, 1")] public int intel { get; set; }

	//Телосложение
	[Export(PropertyHint.Range, "-50, 50, 1")] public int constitution { get; set; }

	//Мудрость
	[Export(PropertyHint.Range, "-50, 50, 1")] public int wisdom { get; set; }



	[ExportGroup("Вторичные характеристики")]

	//Переносимый вес
	[Export(PropertyHint.Range, "-50, 50, 1")] public int carryingCapacity { get; set; }

	//Опьянение
	[Export(PropertyHint.Range, "-50, 50, 1")] public int drunkenness { get; set; }



	[ExportGroup("Сопротивления к урону")]
	//Сопротивление колющему📌
	[Export(PropertyHint.Range, "-100, 100, 1")] public int prickResist { get; set; }

	//Сопротивление ядам🍄
	[Export(PropertyHint.Range, "-100, 100, 1")] public int poisonResist { get; set; }

	//Сопротивление огню🔥
	[Export(PropertyHint.Range, "-100, 100, 1")] public int fireResist { get; set; }

	//Сопростивление морозу❄ 
	[Export(PropertyHint.Range, "-100, 100, 1")] public int frostResist { get; set; }

	//Сопротивление АлКоГоЛю🍺
	[Export(PropertyHint.Range, "-100, 100, 1")] public int drunkennessResist { get; set; }
}
