using Godot;
using System;

public partial class LevelInfo : Node
{
    public override void _Ready()
    {
        Events.levelGenerated += AddLevel;
        Events.finishedAllTurn += AddTurn;
    }

    public override void _ExitTree()
    {
        Events.levelGenerated -= AddLevel;
        Events.finishedAllTurn -= AddTurn;
    }

    // Текущий уровень
    private int currentLevel = 0;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = Math.Clamp(value, 0, 1000);
        }
    }

    // Текущий ход
    private int currentTurn = 0;
    public int CurrentTurn
    {
        get
        {
            return currentTurn;
        }
        set
        {
            currentTurn = Math.Clamp(value, 0, 1000);
        }
    }


    [ExportGroup("Юниты на уровне")]
    // Колличество юнитов которые нужно заспавнить при старте уровня
    [Export] private int captainCount; // Капитаны
    public int CaptainCount
    {
        get
        {
            return captainCount;
        }
        set
        {
            captainCount = Math.Clamp(value, 1, 20);
        }
    }
    [Export] private int infantryCount; // Ближники 
    public int InfantryCount
    {
        get
        {
            return infantryCount;
        }
        set
        {
            infantryCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int riflemanCount; // Дальники
    public int RiflemanCount
    {
        get
        {
            return riflemanCount;
        }
        set
        {
            riflemanCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int spellcasterCount; // Колдуны
    public int SpellcasterCount
    {
        get
        {
            return spellcasterCount;
        }
        set
        {
            spellcasterCount = Math.Clamp(value, 0, 20);
        }
    }

    [ExportGroup("Статичные объекты")]
    // Колличество статичных объектов которые нужно заспавнить при старте уровня
    [Export] private int wallCount; // Стены
    public int WallCount
    {
        get
        {
            return wallCount;
        }
        set
        {
            wallCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int pitCount; // Ямы
    public int PitCount
    {
        get
        {
            return pitCount;
        }
        set
        {
            pitCount = Math.Clamp(value, 0, 20);
        }
    }

    [ExportGroup("Функциональные объекты")]
    // Колличество функциональных объектов которые нужно заспавнить при старте уровня
    [Export] private int trapCount; // Ловушки
    public int TrapCount
    {
        get
        {
            return trapCount;
        }
        set
        {
            trapCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int foodCount; // Еда
    public int FoodCount
    {
        get
        {
            return foodCount;
        }
        set
        {
            foodCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int moneyCount; // Монеты
    public int MoneyCount
    {
        get
        {
            return moneyCount;
        }
        set
        {
            moneyCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int crystalCount; // Кристаллы
    public int CrystalCount
    {
        get
        {
            return crystalCount;
        }
        set
        {
            crystalCount = Math.Clamp(value, 0, 20);
        }
    }
    [Export] private int runeCount; // Кристаллы
    public int RuneCount
    {
        get
        {
            return runeCount;
        }
        set
        {
            runeCount = Math.Clamp(value, 0, 20);
        }
    }

    [ExportGroup("Тайлы")]
    // Колличество тайлов которые нужно заспавнить при стрте уровня
    [Export] private int tileCount;
    public int TileCount
    {
        get
        {
            return tileCount;
        }
        set
        {
            tileCount = Math.Clamp(value, 20, 100);
        }
    }


    private void AddLevel()
    {
        CurrentLevel++;
    }
    private void AddTurn()
    {
        CurrentTurn++;
    }
}
