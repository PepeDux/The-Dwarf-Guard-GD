using Godot;
using System;

public partial class StatusData : Resource
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
	[Export(PropertyHint.Range, "-50, 50, 1")] public int agility { get; set; }

	//Интеллект
	[Export(PropertyHint.Range, "-50, 50, 1")] public int intel { get; set; }

	//Телосложение
	[Export(PropertyHint.Range, "-50, 50, 1")] public int constitution { get; set; }

	//Мудрость
	[Export(PropertyHint.Range, "-50, 50, 1")] public int wisdom { get; set; }





	[ExportGroup("Вторичные характеристики")]
	//Уклонение
	[Export(PropertyHint.Range, "-50, 50, 1")] public int dodge { get; set; }

	//Переносимый вес
	[Export(PropertyHint.Range, "-50, 50, 1")] public int carryingCapacity { get; set; }

	//Скорость
	[Export(PropertyHint.Range, "-50, 50, 1")] public int speed { get; set; }

	//Скорость атаки
	[Export(PropertyHint.Range, "-50, 50, 1")] public int attackSpeed { get; set; }

	//Критический урон
	[Export(PropertyHint.Range, "-50, 50, 1")] public int criticalDamage { get; set; }

	//Шанс критануть
	[Export(PropertyHint.Range, "-50, 50, 1")] public int criticalDamageChance { get; set; }

	//Точность
	[Export(PropertyHint.Range, "-50, 50, 1")] public int precision { get; set; }

	//Опьянение
	[Export(PropertyHint.Range, "-50, 50, 1")] public int drunkenness { get; set; }





	[ExportGroup("Сопротивления к урону")]
	//Сопротивление колющему📌
	[Export(PropertyHint.Range, "-50, 50, 1")] public int prickResist { get; set; }

	//Сопротивление режущему🔪
	[Export(PropertyHint.Range, "-50, 50, 1")] public int slashResist { get; set; }

	//Сопротивление дробящему🔨
	[Export(PropertyHint.Range, "-50, 50, 1")] public int crushResist { get; set; }

	//Сопротивление ядам🍄
	[Export(PropertyHint.Range, "-50, 50, 1")] public int poisonResist { get; set; }

	//Сопротивление огню🔥
	[Export(PropertyHint.Range, "-50, 50, 1")] public int fireResist { get; set; }

	//Сопростивление морозу❄ 
	[Export(PropertyHint.Range, "-50, 50, 1")] public int frostResist { get; set; }

	//Сопротивление проклятию☠
	[Export(PropertyHint.Range, "-50, 50, 1")] public int curseResist { get; set; }

	//Сопротивление электричеству⛈
	[Export(PropertyHint.Range, "-50, 50, 1")] public int electricalResist { get; set; }

	//Сопротивление АлКоГоЛю🍺
	[Export(PropertyHint.Range, "-50, 50, 1")] public int drunkennessResist { get; set; }
}
