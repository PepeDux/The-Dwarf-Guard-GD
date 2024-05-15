using Godot;
using System;

public partial class Weapon : Resource
{
    [ExportGroup("Название оружия")]
    // Название оружия
    [Export] public string weaponName { get; set; }

    [ExportGroup("Изображение оружия")]
    // Изображение оружия
    [Export] public Texture2D weaponImage { get; set; }

    [ExportGroup("Грань куба")]
    // Колличество граней у куба, например D20, D12...
    [Export] public int diceEdges { get; set; }

    [ExportGroup("Колличество бросков")]
    // Колличество бросков куба, например 2D20
    [Export] public int diceRolls { get; set; }

    [ExportGroup("Модификатор попадания")]
    // Модификатор попадания добавляемый во время атаки по цели
    [Export] public int attackModifier { get; set; }

    [ExportGroup("Модификатор урона")]
    // Модификатор урона добавляемый если атакующий попал по своей цели
    [Export] public int damageModifier { get; set; }

    [ExportGroup("Модификатор требуемой характеристики")]
    // Модификатор урона добавляемый если атакующий попал по своей цели
    [Export] public AttackCharacteristic attackCharacteristic { get; set; }
    public enum AttackCharacteristic
    {
        STR,
        DEX,
        CON,
        INT,
        WIS
    };

    [ExportGroup("Напрвление атаки")]
    [Export] public bool directAttack { get; set; }
    [Export] public bool diagonalAttack { get; set; }

    [ExportGroup("Дальность атаки")]
    [Export] public int attackDistance = 1;

    [ExportGroup("Цена атаки")]
    [Export] public int attackCost = 1;
}
