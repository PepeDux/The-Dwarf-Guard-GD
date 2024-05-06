using Godot;
using System;



public partial class Character : BaseObject
{
	public AnimationPlayer anim;

	[ExportGroup ("Лут после смерти")]
	[Export] public PackedScene[] loot;

	[ExportGroup ("Очки перемещения")]
	// Очки перемещения
	[Export] private int maxMovePoints = 6;
	public int MaxMovePoints
	{
		get
		{
			return maxMovePoints;
		}
		set
		{
			maxMovePoints = Math.Clamp(value, 1, 20);
		}
	}

	[Export] private int movePoints = 0;
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
	[Export] private int maxActionPoints = 2;
	public int MaxActionPoints
	{
		get
		{
			return maxActionPoints;
		}
		set
		{
			maxActionPoints = Math.Clamp(value, 1, 50);
		}
	}

	[Export] private int actionPoints = 0;
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
	[Export] private int maxBeerPoints = 6;
	public int MaxBeerPoints
	{
		get
		{
			return maxBeerPoints;
		}
		set
		{
			maxBeerPoints = Math.Clamp(value, 0, 50);
		}
	}

	[Export] private int beerPoints = 0;
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
	// Цена передвижений
	[Export] private int moveCost = 1;
	public int MoveCost
	{
		get
		{
			return moveCost;
		}
		set
		{
			moveCost = Math.Clamp(value, 1, 20);
		}
	}

	// Цена ближней атаки
	[Export] private int meleeAttackCost = 1;
	public int MeleeAttackCost
	{
		get
		{
			return meleeAttackCost;
		}
		set
		{
			meleeAttackCost = Math.Clamp(value, 1, 20);
		}
	}

	// Цена дальней атаки
	[Export] private int rangeAttackCost = 1;
	public int RangeAttackCost
	{
		get
		{
			return rangeAttackCost;
		}
		set
		{
			rangeAttackCost = Math.Clamp(value, 1, 20);
		}
	}



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
	[Export] private int maxHP = 10;
	public int MaxHP
	{
		get
		{
			return maxHP;
		}
		set
		{
			maxHP = Math.Clamp(value, 0, 1000);
		}
	}

	[Export] private int hP;
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
	[Export] private int ac = 5;
	public int AC
	{
		get
		{
			return ac;
		}
		set
		{
			ac = Math.Clamp(value, 0, 20);
		}
	}

	[ExportGroup("Монетки")]
	// Монетки
	[Export] private int money = 0;
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
	[Export] private int physicalDamage = 0;
	public int PhysicalDamage
	{
		get
		{
			return physicalDamage;
		}
		set
		{
			physicalDamage = Math.Clamp(value, 0, 50);
		}
	}

	// Ядовитый урон
	[Export] private int poisonDamage = 0;
	public int PoisonDamage
	{
		get
		{
			return poisonDamage;
		}
		set
		{
			poisonDamage = Math.Clamp(value, 0, 50);
		}
	}

	// Огненный урон
	[Export] private int fireDamage = 0;
	public int FireDamage
	{
		get
		{
			return fireDamage;
		}
		set
		{
			fireDamage = Math.Clamp(value, 0, 50);
		}
	}

	// Морозный урон
	[Export] private int frostDamage = 0;
	public int FrostDamage
	{
		get
		{
			return frostDamage;
		}
		set
		{
			frostDamage = Math.Clamp(value, 0, 50);
		}
	}



	[ExportGroup("Уровень и опыт")]
	// Опыт
	public int XP = 0;
	public int maxXP;

	// Уровень
	private int level = 0;
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
	private int drunkenness = 0;
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
	private int physicalResist = 0;
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
	private int poisonResist = 0;
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
	private int fireResist = 0;
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
	private int frostResist = 0;
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
	private int drunkennessResist = 0;
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

		Events.finishedAllTurn += UpdatePoints;

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

		Events.finishedAllTurn -= UpdatePoints;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		UpdateCharacteristicModifier();
	}



	public void UpdatePoints()
	{
		movePoints = MaxMovePoints;
		actionPoints = MaxActionPoints;
		beerPoints = MaxBeerPoints;
	}

	private void UpdateHP()
	{
		MaxHP += constitutionModifier * 3;
		HP = MaxHP;
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
