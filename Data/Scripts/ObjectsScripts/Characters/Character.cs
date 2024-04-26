using Godot;
using System;



public partial class Character : BaseObject
{
	public AnimationPlayer anim;

	[ExportGroup ("Лут после смерти")]
	[Export] public PackedScene[] loot;

	[ExportGroup ("Очки перемещения")]
	// Очки перемещения
	[Export] private int movePoints = 0;
	[Export] public int maxMovePoints = 6;
	public int MovePoints
	{ 
		get 
		{ 
			return movePoints; 
		} 
		set 
		{ 
			movePoints = Math.Clamp(value, 0, maxMovePoints);
		} 
	}

	[ExportGroup("Очки действия")]
	// Очки действий
	[Export] private int actionPoints = 0;
	[Export] public int maxActionPoints = 2;
	public int ActionPoints
	{
		get
		{
			return actionPoints;
		}
		set
		{
			actionPoints = Math.Clamp(value, 0, maxActionPoints);
		}
	}


	[ExportGroup("Очки пива")]
	// Очки пива
	[Export] private int beerPoints = 0;
	[Export] public int maxBeerPoints = 6;
	public int BeerPoints
	{
		get
		{
			return beerPoints;
		}
		set
		{
			beerPoints = Math.Clamp(value, 0, maxBeerPoints);
		}
	}



	[ExportGroup("Цена действий")]
	[Export] public int moveCost = 1;
	[Export] public int meleeAttackCost = 1;
	[Export] public int rangeAttackCost = 2;



	[ExportGroup("Тип передвиженя")]
	[Export] public bool horizontalMove = true;
	[Export] public bool diagonalMove = false;



	[ExportGroup("Напрвление атаки")]
	[Export] public bool horizontalAttack = true;
	[Export] public bool diagonalAttack = false;



	[ExportGroup("Тип атаки")]
	[Export] public bool meleeAttack = true; //Ближняя атака
	[Export] public bool rangeAttack = false; //Дальняя атака



	[ExportGroup("Дальность атаки")]
	public int meleeAttackDistance = 1;
	public int rangeAttackDistance; //Дальность дальней атаки
	


	#region Characteristic

	[ExportGroup("Здоровье")]
	// Здоровье
	[Export] private int hP;
	[Export] public int maxHP = 10;
	public int HP
	{
		get
		{
			return hP;
		}
		set
		{
			hP = Math.Clamp(value, 0, maxHP);
		}
	}

	[ExportGroup("КД")]
	// КД
	[Export] public int AC = 5;

	[ExportGroup("Монетки")]
	// Монетки
	[Export] public int money = 0;
	public int Money
	{
		get
		{
			return money;
		}
		set
		{
			money = Math.Clamp(value, 0, 10000);
		}
	}



	[ExportGroup("Уроны")]
	// Урон наносимый объектом
	// 1 переменная - итоговый урон
	// 2 переменная - урон от оружия
	// 3 переменная - бонусный урон, отрицательный или положительный

	// Физический урон
	[Export] public int physicalDamage = 0;

	// Ядовитый урон
	[Export] public int poisonDamage = 0;

	// Огненный урон
	[Export] public int fireDamage = 0;

	// Морозный урон
	[Export] public int frostDamage = 0;



	[ExportGroup("Уровень и опыт")]
	// Опыт
	public int XP = 0;
	public int maxXP;

	// Уровень
	public int level = 0;
	public int maxLevel = 10;
	public int Level
	{
		get 
		{ 
			return level;
		}
		set
		{
			level = Math.Clamp(value, 0, 20);
		}
	}



	[ExportGroup("Первичные характеристики")]
	// Сила
	[Export] private int strength = 0;
	public int Strength
	{
		get
		{
			return strength;
		}
		set
		{
			strength = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор силы
	public int strengthModifier = 0;

	// Телосложение
	[Export] private int constitution = 0;
	public int Constitution
	{
		get
		{
			return constitution;
		}
		set
		{
			constitution = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор телосложения
	public int constitutionModifier = 0;

	// Ловкость
	[Export] private int dexterity = 0;
	public int Dexterity
	{
		get
		{
			return dexterity;
		}
		set
		{
			dexterity = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор ловкости
	public int dexterityModifier = 0;

	// Интеллект
	[Export] private int inteligence = 0;
	public int Inteligence
	{
		get
		{
			return inteligence;
		}
		set
		{
			inteligence = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор интеллект
	public int inteligenceModifier = 0;

	// Мудрость
	[Export] private int wisdom = 0;
	public int Wisdom
	{
		get
		{
			return wisdom;
		}
		set
		{
			wisdom = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор мудрости
	public int wisdomModifier = 0;




	[ExportGroup("Вторичные характеристики")]
	// 1 переменная - итоговове значение характеристики
	// 2 переменная - бонус к значению характеристики
	// 3 переменная - максимальное допустимое значение характеристики

	//Опьянение
	public int drunkenness = 0;
	public int Drunkenness
	{
		get
		{
			return drunkenness;
		}
		set
		{
			drunkenness = Math.Clamp(value, 0, 100);
		}
	}



	[ExportGroup("Сопротивления к урону")]
	// Сопротивление физическому
	public int physicalResist = 0;
	public int PhysicalResist
	{
		get
		{
			return physicalResist;
		}
		set
		{
			physicalResist = Math.Clamp(value, -100, 100);
		}
	}

	// Сопротивление ядам
	public int poisonResist = 0;
	public int PoisonResist
	{
		get
		{
			return poisonResist;
		}
		set
		{
			poisonResist = Math.Clamp(value, -100, 100);
		}
	}

	// Сопротивление огню
	public int fireResist = 0;
	public int FireResist
	{
		get
		{
			return fireResist;
		}
		set
		{
			fireResist = Math.Clamp(value, -100, 100);
		}
	}

	// Сопростивление морозу
	public int frostResist = 0;
	public int FrostResist
	{
		get
		{
			return frostResist;
		}
		set
		{
			frostResist = Math.Clamp(value, -100, 100);
		}
	}

	// Сопротивление АлКоГоЛю
	public int drunkennessResist = 0;
	public int DrunkennessResist
	{
		get
		{
			return drunkennessResist;
		}
		set
		{
			drunkennessResist = Math.Clamp(value, -100, 100);
		}
	}



	#endregion


	public override void _Ready()
	{
		base._Ready();

		UpdateCoordinate();
		UpdatePoints();
		UpdateCharacteristicModifier();
		UpdateAC();
		AddCharacterToCharacterStorage();
		UpdateHP();

		//Добавляем персонажа в хранилище тайлов
		TileStorage.AddCell(this);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		UpdateCharacteristicModifier();
	}



	public void UpdatePoints()
	{
		movePoints = maxMovePoints;
		actionPoints = maxActionPoints;
		beerPoints = maxBeerPoints;
	}

	private void UpdateHP()
	{
		maxHP += constitutionModifier * 3;
		HP = maxHP;
	}

	private void UpdateAC()
	{
		AC += dexterityModifier;
	}

	private void UpdateCharacteristicModifier()
	{
		strengthModifier = (Strength - 10) / 2;
		dexterityModifier = (Dexterity - 10) / 2;
		constitutionModifier = (Constitution - 10) / 2;
		inteligenceModifier = (Inteligence - 10) / 2;
		wisdomModifier = (Wisdom - 10) / 2;
	}

	private void AddCharacterToCharacterStorage()
	{
		CharacterStorage.characters.Add(this);
	}
}
