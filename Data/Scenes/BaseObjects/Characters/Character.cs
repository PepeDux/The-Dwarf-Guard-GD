using Godot;
using System;
using System.Collections.Generic;

public partial class Character : BaseObject, ITakeDamage
{
	public override Vector2I Coordinate
	{
		get
		{
			return coordinate;
		}
		set
		{
			// Обновляем данные в тайловом хранилище
			TileStorage.RemoveCell(coordinate);
			TileStorage.AddCell(value);

			coordinate = value;

			try
			{
				if (GetNode<AudioController>("AudioStreamPlayer").IsInsideTree())
				{
					// Проигрываем звук перемещения
					GetNode<AudioController>("AudioStreamPlayer").PlaySound("Move", 0.8f, 1f);
				}
			}
			catch
			{

			}

			Events.characterMoved?.Invoke(this);

		}
	}

	[ExportGroup ("Лут после смерти")]
	[Export] public PackedScene[] loot;

	[ExportGroup("Оружие")]
	[Export] public Weapon weapon;

	[ExportGroup("Тип передвиженя")]
	[Export] public bool directMove = true;
	[Export] public bool diagonalMove = false;

	#region Points

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


	#endregion



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
	[Export] private int coins = 0;
	public int Coins
	{
		get
		{
			return coins;
		}
		set
		{
			coins = Math.Clamp(value, 0, 10000);

			if (this is Player) 
			{
				GetTree().Root.GetNode("GameScene").GetNode<PlayerCoinCollection>("PlayerCoinCollection").coins += value;
			}
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

	// Харизма
	[Export] private int charisma = 0;
	public int Charisma
	{
		get
		{
			return charisma;
		}
		set
		{
			charisma = Math.Clamp(value, 0, 20);
		}
	}
	// Модификатор харизмы
	public int charismaModifier = 0;



	[ExportGroup("Вторичные характеристики")]
	// 1 переменная - итоговове значение характеристики
	// 2 переменная - бонус к значению характеристики
	// 3 переменная - максимальное допустимое значение характеристики

	// Опьянение
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

	// Модификатор добавляемый урону и попаданию при атаке
	public int attackCharacteristicModifier;


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


	#endregion


	public override void _Ready()
	{
		base._Ready();

		Events.finishedAllTurn += UpdatePoints;

		UpdateCoordinate();
		UpdatePoints();
		UpdateCharacteristicModifier();
		UpdateWeaponAttackCharacteristicModifier();
		UpdateAC();
		UpdateHP();
		AddCharacterToCharacterStorage();
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
		UpdateWeaponAttackCharacteristicModifier();

	}


	// Обновляет очки персонажа
	public void UpdatePoints()
	{
		movePoints = MaxMovePoints;
		actionPoints = MaxActionPoints;
		beerPoints = MaxBeerPoints;
	}

	// Обновляет здоровье персонажа
	private void UpdateHP()
	{
		MaxHP += constitutionModifier * 3;
		HP = MaxHP;
	}

	// Обновляет КД персонажа
	private void UpdateAC()
	{
		AC += dexterityModifier;
	}

	// Обновляет модификаторы характеристик
	private void UpdateCharacteristicModifier()
	{
		strengthModifier = (Strength - 10) / 2;
		dexterityModifier = (Dexterity - 10) / 2;
		constitutionModifier = (Constitution - 10) / 2;
		inteligenceModifier = (Inteligence - 10) / 2;
		wisdomModifier = (Wisdom - 10) / 2;
		charismaModifier = (Charisma - 10) / 2;
	}

	// Обновляет значения модификатора характеристики оружия
	private void UpdateWeaponAttackCharacteristicModifier()
	{
		if (weapon.attackCharacteristic == Weapon.AttackCharacteristic.STR)
		{
			attackCharacteristicModifier = strengthModifier;
		}
		else if (weapon.attackCharacteristic == Weapon.AttackCharacteristic.DEX)
		{
			attackCharacteristicModifier = dexterityModifier;
		}
		else if (weapon.attackCharacteristic == Weapon.AttackCharacteristic.CON)
		{
			attackCharacteristicModifier = constitutionModifier;
		}
		else if (weapon.attackCharacteristic == Weapon.AttackCharacteristic.INT)
		{
			attackCharacteristicModifier = inteligenceModifier;
		}
		else if (weapon.attackCharacteristic == Weapon.AttackCharacteristic.WIS)
		{
			attackCharacteristicModifier = wisdomModifier;
		}
	}

	// Добавляем персонажа в список персонажей
	private void AddCharacterToCharacterStorage()
	{
		CharacterStorage.characters.Add(this);
	}
}
