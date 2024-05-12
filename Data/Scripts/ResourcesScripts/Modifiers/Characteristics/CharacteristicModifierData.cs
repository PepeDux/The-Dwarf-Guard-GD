using Godot;
using System;

public partial class CharacteristicModifierData : ModifierData
{
	[ExportGroup("Перманентность")]
	// Данная переменная отвечает за то, будет ли эффект модификатора распространяться на все этажи или
	// же будет распространяться только на 1 этаж (ПОКА ЧТО АКТАЛЬНО ТОЛЬКО ДЛЯ ПОДИБРАЕМЫХ ОБЪЕКТОВ ПОДОБРАННЫХ ИГРОКОМ)
	[Export] public bool permanent { get; set; }



	[ExportGroup("Здоровье")]
	[Export] public int maxHP { get; set; }
	[Export] public int HP { get; set; }



	[ExportGroup("Очки перемещения")]
	[Export] public int maxMovePoints { get; set; }
	[Export] public int movePoints { get; set; }



	[ExportGroup("Очки действия")]
	[Export] public int maxActionPoints { get; set; }
	[Export] public int actionPoints { get; set; }



	[ExportGroup("Очки пива")]
	[Export] public int maxBeerPoints { get; set; }
	[Export] public int beerPoints { get; set; }



	[ExportGroup("Цена действий")]
	[Export] public int moveCost { get; set; }


	public enum BoolStatus 
	{	
		Nothing,
		Add,
		Remove
	};



	[ExportGroup("Тип передвиженя")]
	[Export] public BoolStatus horizontalMove { get; set; }
	[Export] public BoolStatus diagonalMove { get; set; }



	[ExportGroup("Броня")]
	[Export] public int AC { get; set; }



	[ExportGroup("Монетки")]
	[Export] public int coins { get; set; }



	[ExportGroup("Основные характеристики")]
	[Export] public int strength { get; set; }

	[Export] public int dexterity { get; set; }

	[Export] public int inteligence { get; set; }

	[Export] public int constitution { get; set; }

	[Export] public int wisdom { get; set; }



	[ExportGroup("Вторичные характеристики")]
	[Export] public int drunkenness { get; set; }



	[ExportGroup("Сопротивления к урону")]
	// Сопротивление физическому урону
	[Export] public int physicalResist { get; set; }
}


