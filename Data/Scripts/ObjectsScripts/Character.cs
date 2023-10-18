using Godot;
using System;

public partial class Character : BaseObject
{
    //[Header("Очки перемещения")]
    //Очки перемещения
    public int movePoints = 6;
    public int maxMovePoints = 6;

    //[Header("Очки действия")]
    //Очки действий
    public int actionPoints;
    public int maxActionPoints;

    //[Header("Очки пива")]
    //Очки пива
    public int beerPoints;
    public int maxBeerPoints;



    //[Header("Цена действий")]
    public int moveCost = 1;
    public int meleeAttackCost;
    public int rangeAttackCost;



    //[Header("Тип передвиженя")]
    public bool lineMove = true;
    public bool diagonalMove = false;



    //[Header("Напрвление атаки")]
    public bool lineAttack = true;
    public bool diagonalAttack = false;



    //[Header("Тип атаки")]
    public bool melee = false; //Ближняя атака
    public bool range = false; //Дальняя атака



    //[Header("Дальность атаки")]
    public int rangeAttackDistance; //Дальность дальней атаки
    public const int meleeAttackDistance = 1;


    //[Header("Плюшки")]
    public AnimationPlayer anim;

    public static int random;

    #region Characteristic

    private int freeCharacteristicLevel = 0;
    private int CharacteristicLevel = 0;
    private int maxCharacteristicLevel = 10;

    //[Header("Здоровье")]
    //Здоровье
    public int HP;
    public int basicMaxHP = 10;
    public int maxHP;

    //[Header("Броня")]
    //Броня
    public int armor;
    public int maxArmor;

    //[Header("Монетки")]
    //Монетки
    public int money = 0;



    //[Header("Уроны")]
    //Урон наносимый объектом
    //1 переменная - итоговый урон
    //2 переменная - урон от оружия
    //3 переменная - бонусный урон, отрицательный или положительный

    //Физический урон
    public int physicalDamage = 0;
    /*[HideInInspector]*/
    public int physicalDamageBonus = 0;

    //Ядовитый урон
    public int poisonDamage = 0;
    /*[HideInInspector]*/
    public int poisonDamageBonus = 0;

    //Огненный урон
    public int fireDamage = 0;
    /*[HideInInspector]*/
    public int fireDamageBonus = 0;

    //Морозный урон
    public int frostDamage = 0;
    /*[HideInInspector]*/
    public int frostDamageBonus = 0;

    //Алкогольный урон
    public int drunkennessDamage = 0;
    /*[HideInInspector]*/
    public int drunkennessDamageBonus = 0;



    //[Header("Уровень и опыт")]
    //Опыт
    public int XP = 0;
    /*[HideInInspector]*/
    public int maxXP;

    //Уровень
    public int level = 0;
    /*[HideInInspector]*/
    public int maxLevel = 10;



    //[Header("Основнык характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - текущее значение характеристики(в прокачке, независимо от бонусов)
    //3 переменная - максимальное допустимое значение характеристики(в прокачке, независимо от бонусов)
    //4 переменная - бонус к значению характеристики

    //Сила
    public int strength = 0;
    /*[HideInInspector]*/
    private int strengthCharac = 8;
    /*[HideInInspector]*/
    private const int maxStrengthCharac = 20;
    /*[HideInInspector]*/
    public int strengthBonus = 0;

    //Ловкость
    public int dexterity = 0;
    /*[HideInInspector]*/
    private int dexterityCharac = 8;
    /*[HideInInspector]*/
    private const int maxDexterityCharac = 20;
    /*[HideInInspector]*/
    public int dexterityBonus = 0;

    //Интеллект
    public int inteligence = 0;
    /*[HideInInspector]*/
    private int inteligenceCharac = 8;
    /*[HideInInspector]*/
    private const int maxInteligenceCharac = 20;
    /*[HideInInspector]*/
    public int inteligenceBonus = 0;

    //Телосложение
    public int constitution = 0;
    /*[HideInInspector]*/
    private int constitutionCharac = 8;
    /*[HideInInspector]*/
    private const int maxConstitutionCharac = 20;
    /*[HideInInspector]*/
    public int constitutionBonus = 0;

    //Мудрость
    public int wisdom = 0;
    /*[HideInInspector]*/
    private int wisdomCharac = 8;
    /*[HideInInspector]*/
    private const int maxWisdomCharac = 20;
    /*[HideInInspector]*/
    public int wisdomBonus = 0;




    //[Header("Вторичные характеристики")]
    //1 переменная - итоговове значение характеристики
    //2 переменная - бонус к значению характеристики
    //3 переменная - максимальное допустимое значение характеристики

    //Уклонение
    public int dodge = 0;
    /*[HideInInspector]*/
    public int dodgeBonus = 0;
    private const int maxDodge = 100;

    //Критический урон
    public int criticalDamage = 0;
    /*[HideInInspector]*/
    public int criticalDamageBonus = 0;
    private const int maxCriticalDamage = 200;

    //Шанс критануть
    public int criticalDamageChance = 0;
    /*[HideInInspector]*/
    public int criticalDamageChanceBonus = 0;
    private const int minCriticalChanceDamage = -100;
    private const int maxCriticalChanceDamage = 100;

    //Точность
    public int precision = 0;
    /*[HideInInspector]*/
    public int precisionBonus = 0;
    private const int maxPrecision = 100;



    //Опьянение
    public int drunkenness = 0;
    /*[HideInInspector]*/
    public int drunkennessBonus = 0;
    private const int maxDrunkenness = 100;



    //[Header("Сопротивления к урону")]
    //Сопротивление физическому
    public int physicalResist = 0;
    /*[HideInInspector]*/
    public int physicalResistBonus = 20;
    private const int maxPhysicalResist = 100;
    private const int minPhysicalResist = -100;

    //Сопротивление ядам
    public int poisonResist = 0;
    /*[HideInInspector]*/
    public int poisonResistBonus = 0;
    private const int maxPoisonResist = 100;
    private const int minPoisonResist = -100;

    //Сопротивление огню
    public int fireResist = 0;
    /*[HideInInspector]*/
    public int fireResistBonus = 0;
    private const int maxFireResist = 100;
    private const int minFireResist = -100;

    //Сопростивление морозу
    public int frostResist = 0;
    /*[HideInInspector]*/
    public int frostResistBonus = 0;
    private const int maxFrostResist = 100;
    private const int minFrostResist = -100;

    //Сопротивление АлКоГоЛю
    public int drunkennessResist = 0;
    /*[HideInInspector]*/
    public int drunkennessResistBonus = 0;
    private const int maxDrunkennessResist = 100;
    private const int minDrunkennessResist = -100;



    public void CheckCharac()
    {
        //Хепешки
        if (HP >= maxHP)
        {
            HP = maxHP;
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
        else if (armor < 0)
        {
            armor = 0;
        }

        //Сила
        if (strengthCharac >= maxStrengthCharac)
        {
            strengthCharac = maxStrengthCharac;
        }
        else if (strengthCharac <= 0)
        {
            strengthCharac = 0;
        }

        //Ловкость
        if (dexterityCharac >= maxDexterityCharac)
        {
            dexterityCharac = maxDexterityCharac;
        }
        else if (dexterityCharac <= 0)
        {
            dexterityCharac = 0;
        }

        //Интеллект
        if (inteligenceCharac >= maxInteligenceCharac)
        {
            inteligenceCharac = maxInteligenceCharac;
        }
        else if (inteligenceCharac <= 0)
        {
            inteligenceCharac = 0;
        }

        //Телосложение
        if (constitutionCharac >= maxConstitutionCharac)
        {
            constitutionCharac = maxConstitutionCharac;
        }
        else if (constitutionCharac <= 0)
        {
            constitutionCharac = 0;
        }

        //Мудрость
        if (wisdomCharac >= maxWisdomCharac)
        {
            wisdomCharac = maxWisdomCharac;
        }
        else if (wisdomCharac <= 0)
        {
            wisdomCharac = 0;
        }

        //Уклонение
        if (dodge >= maxDodge)
        {
            dodge = maxDodge;
        }
        else if (dodge <= 0)
        {
            dodge = 0;
        }

        //Крит урон
        if (criticalDamage >= maxCriticalDamage)
        {
            criticalDamage = maxCriticalDamage;
        }
        else if (criticalDamage <= 0)
        {
            criticalDamage = 0;
        }

        //Шанс критануть
        if (criticalDamageChance >= maxCriticalChanceDamage)
        {
            criticalDamageChance = maxCriticalChanceDamage;
        }
        else if (criticalDamageChance <= 0)
        {
            criticalDamageChance = 0;
        }

        //Точность
        if (precision >= maxPrecision)
        {
            precision = maxPrecision;
        }
        else if (precision <= 0)
        {
            precision = 0;
        }

        //Опьянение
        if (drunkenness >= maxDrunkenness)
        {
            drunkenness = maxDrunkenness;
        }
        else if (drunkenness <= 0)
        {
            drunkenness = 0;
        }

        //Сопротивление Физическому урону
        if (physicalResist >= maxPhysicalResist)
        {
            physicalResist = maxPhysicalResist;
        }
        else if (physicalResist <= minPhysicalResist)
        {
            physicalResist = minPhysicalResist;
        }

        //Сопротивление ядам
        if (poisonResist >= maxPoisonResist)
        {
            poisonResist = maxPoisonResist;
        }
        else if (poisonResist <= minPoisonResist)
        {
            poisonResist = minPoisonResist;
        }

        //Сопротивление огню
        if (fireResist >= maxFireResist)
        {
            fireResist = maxFireResist;
        }
        else if (fireResist <= minFireResist)
        {
            fireResist = minFireResist;
        }

        //Сопротивление морозу
        if (frostResist >= maxFrostResist)
        {
            frostResist = maxFrostResist;
        }
        else if (frostResist <= minFrostResist)
        {
            frostResist = minFrostResist;
        }

        //Сопротивление опьянению
        if (drunkennessResist >= maxDrunkennessResist)
        {
            drunkennessResist = maxDrunkennessResist;
        }
        else if (drunkennessResist <= minDrunkennessResist)
        {
            drunkenness = minDrunkennessResist;
        }

    }//Проверяет переменные на то чтобы они совпадали своему диапазону

    public void UpdateCharac()
    {
        maxHP = constitution * 5 + basicMaxHP;


        //Первичные характеристики
        strength = strengthCharac * 1 + strengthBonus;
        dexterity = dexterityCharac * 1 + dexterityBonus;
        constitution = constitutionCharac * 1 + constitutionBonus;
        inteligence = inteligenceCharac * 1 + inteligenceBonus;
        wisdom = wisdomCharac * 1 + wisdomBonus;

        ///Дамаги
        //Физический урон
        physicalDamage = strength * 5 + physicalDamageBonus;

        //Ядовитый урон
        poisonDamage = poisonDamageBonus;

        //Огненный урон
        fireDamage = fireDamageBonus;

        //Морозный урон
        frostDamage = frostDamageBonus;

        //Алкогольный урон
        drunkennessDamage = drunkennessBonus;




        //Сопротивляшки
        physicalResist = (constitution * 1) + physicalResistBonus;

        poisonResist = (wisdom * 1) + poisonResistBonus;
        fireResist = (wisdom * 1) + fireResistBonus;
        frostResist = (wisdom * 1) + frostResistBonus;



        //Вторичные характеристики
        dodge = dexterity * 2 + dodgeBonus;
        criticalDamage = dexterity * 1 + criticalDamageBonus;
        precision = dexterity * 1 + precisionBonus;



    }//Обновляет характеристики исходя из других переменных и бонусов к ним


    #endregion


    private void UpdatePoints()
    {
        movePoints = maxMovePoints;
        actionPoints = maxActionPoints;
        beerPoints = maxBeerPoints;
    }

    public override void Updater()
    {
        UpdateCharac();
        CheckCharac();
        UpdateCoordinate();
    }

    public void Starter()
    {
        Events.playerTurnFinished += UpdatePoints;

        FindTileMap();
        IdleAnimation();
        UpdatePoints();

        TileStorage.AddCharacter(this);



        HP = maxHP;
        armor = maxArmor;
    }
}
