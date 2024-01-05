using Godot;
using System;



public partial class Character : BaseObject
{
    public AnimationPlayer anim;

    [ExportGroup ("Очки перемещения")]
    //Очки перемещения
    [Export] private int movePoints;
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
    //Очки действий
    [Export] private int actionPoints;
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
    //Очки пива
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
    [Export] public bool lineMove = true;
    [Export] public bool diagonalMove = false;



    [ExportGroup("Напрвление атаки")]
    [Export] public bool lineAttack = true;
    [Export] public bool diagonalAttack = false;



    [ExportGroup("Тип атаки")]
    [Export] public bool melee = false; //Ближняя атака
    [Export] public bool range = false; //Дальняя атака



    [ExportGroup("Дальность атаки")]
    public int rangeAttackDistance; //Дальность дальней атаки
    public int meleeAttackDistance = 1;




    #region Characteristic

    //private int freeCharacteristicLevel = 0;
    //private int CharacteristicLevel = 0;
    //private int maxCharacteristicLevel = 10;

    [ExportGroup("Здоровье")]
    //Здоровье
    [Export] private int hP;
    [Export] public int maxHP = 20;
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

    [ExportGroup("Броня")]
    //Броня
    [Export] public int armor;
    [Export] public int maxArmor;
    public int Armor
    {
        get
        {
            return armor;
        }
        set
        {
            armor = Math.Clamp(value, 0, maxArmor);
        }
    }

    [ExportGroup("Монетки")]
    //Монетки
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
    //Урон наносимый объектом
    //1 переменная - итоговый урон
    //2 переменная - урон от оружия
    //3 переменная - бонусный урон, отрицательный или положительный

    //Физический урон
    [Export] public int physicalDamage = 0;

    //Ядовитый урон
    [Export] public int poisonDamage = 0;

    //Огненный урон
    [Export] public int fireDamage = 0;

    //Морозный урон
    [Export] public int frostDamage = 0;

    //Алкогольный урон
    [Export] public int drunkennessDamage = 0;



    [ExportGroup("Уровень и опыт")]
    //Опыт
    public int XP = 0;
    public int maxXP;

    //Уровень
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
    //1 переменная - итоговове значение характеристики
    //2 переменная - текущее значение характеристики(в прокачке, независимо от бонусов)
    //3 переменная - максимальное допустимое значение характеристики(в прокачке, независимо от бонусов)
    //4 переменная - бонус к значению характеристики

    //Сила
    public int strength = 0;
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

    //Ловкость
    public int dexterity = 0;
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

    //Интеллект
    public int inteligence = 0;
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

    //Телосложение
    public int constitution = 0;
    public int Constitution
    {
        get
        {
            return level;
        }
        set
        {
            constitution = Math.Clamp(value, 0, 20);
        }
    }

    //Мудрость
    public int wisdom = 0;
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




    [ExportGroup("Вторичные характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - бонус к значению характеристики
    //3 переменная - максимальное допустимое значение характеристики

    //Уклонение
    public int dodge = 0;
    public int Dodge
    {
        get
        {
            return dodge;
        }
        set
        {
            dodge = Math.Clamp(value, 0, 100);
        }
    }

    //Критический урон
    public int criticalDamage = 0;
    public int CriticalDamage
    {
        get
        {
            return criticalDamage;
        }
        set
        {
            criticalDamage = Math.Clamp(value, 0, 200);
        }
    }

    //Шанс критануть
    public int criticalDamageChance = 0;
    public int CriticalDamageChance
    {
        get
        {
            return criticalDamageChance;
        }
        set
        {
            criticalDamageChance = Math.Clamp(value, 0, 100);
        }
    }

    //Точность
    public int precision = 0;
    public int Precision
    {
        get
        {
            return precision;
        }
        set
        {
            precision = Math.Clamp(value, 0, 100);
        }
    }



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
    //Сопротивление физическому
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

    //Сопротивление ядам
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

    //Сопротивление огню
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

    //Сопростивление морозу
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

    //Сопротивление АлКоГоЛю
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


    private void UpdatePoints()
    {
        movePoints = maxMovePoints;
        actionPoints = maxActionPoints;
        beerPoints = maxBeerPoints;
    }

    private void UpdateCharac()
    {
        HP = maxHP;
        armor = maxArmor;
    }

    public override void Updater()
    {
        UpdateCoordinate();
    }

    public void Starter()
    {
        Events.playerTurnFinished += UpdatePoints;

        TileStorage.impassableCells.Add(coordinate);
        TileStorage.occupiedCells.Add(coordinate);

        FindTileMap();
        IdleAnimation();
        UpdatePoints();
        UpdateCharac();

        TileStorage.AddCharacter(this);
    }
}
