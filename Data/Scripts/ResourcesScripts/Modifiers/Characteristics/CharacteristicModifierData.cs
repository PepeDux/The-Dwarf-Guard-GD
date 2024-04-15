using Godot;
using System;

public partial class CharacteristicModifierData : ModifierData
{
	[ExportGroup("Здоровье")]
	// Здоровье
	[Export] public int HP { get; set; }
	[Export] public int maxHP { get; set; }



	[ExportGroup("Урон наносимый объекту")]
	// Физический урон
	[Export] public int physicalDamage { get; set; }

	// Ядовитый урон
	[Export] public int poisonDamage { get; set; }

	// Огненный урон
	[Export] public int fireDamage { get; set; }

	// Морозный урон
	[Export] public int frostDamage { get; set; }

	// Алкогольный урон
	[Export] public int drunkennessDamage { get; set; }



	[ExportGroup("Очки перемещения")]
	[Export] public int movePoints { get; set; }
	[Export] public int maxMovePoints { get; set; }



	[ExportGroup("Очки действия")]
	[Export] public int actionPoints { get; set; }
	[Export] public int maxActionPoints { get; set; }



	[ExportGroup("Очки пива")]
	[Export] public int beerPoints { get; set; }
	[Export] public int maxBeerPoints { get; set; }



	[ExportGroup("Цена действий")]
	[Export] public int moveCost { get; set; }
	[Export] public int meleeAttackCost { get; set; }
	[Export] public int rangeAttackCost { get; set; }


	public enum BoolStatus 
	{	
		Nothing,
		Add,
		Remove
	};



	[ExportGroup("Тип передвиженя")]
	[Export] public BoolStatus lineMove { get; set; }
	[Export] public BoolStatus diagonalMove { get; set; }



	[ExportGroup("Напрвление атаки")]
	[Export] public BoolStatus lineAttack { get; set; }
	[Export] public BoolStatus diagonalAttack { get; set; }



	[ExportGroup("Тип атаки")]
	[Export] public BoolStatus meleeAttack { get; set; }
	[Export] public BoolStatus rangeAttack { get; set; }



	[ExportGroup("Дальность атаки")]
	[Export] public int rangeAttackDistance { get; set; }
	[Export] public int meleeAttackDistance { get; set; }



	[ExportGroup("Броня")]
	[Export] public int AC { get; set; }



	[ExportGroup("Монетки")]
	[Export] public int money { get; set; }



	[ExportGroup("Основные характеристики")]
	[Export] public int strength { get; set; }

	[Export] public int dexterity { get; set; }

	[Export] public int intel { get; set; }

	[Export] public int constitution { get; set; }

	[Export] public int wisdom { get; set; }



	[ExportGroup("Вторичные характеристики")]
	[Export] public int drunkenness { get; set; }



	[ExportGroup("Сопротивления к урону")]
	// Сопротивление колющему📌
	[Export] public int physicalResist { get; set; }

	// Сопротивление ядам🍄
	[Export] public int poisonResist { get; set; }

	// Сопротивление огню🔥
	[Export] public int fireResist { get; set; }

	// Сопростивление морозу❄ 
	[Export] public int frostResist { get; set; }

	// Сопротивление АлКоГоЛю🍺
	[Export] public int drunkennessResist { get; set; }
}


