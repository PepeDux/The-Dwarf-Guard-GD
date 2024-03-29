using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class СharacteristicModifierCalculation : Node
{
    public List<CharacteristicModifierData> activeCharacteristicModifiers = new List<CharacteristicModifierData>();


    public override void _Ready()
    {
        // Добавляем статусы в соответствии с родительским классом
        if (GetParent() is Enemy)
        {
            activeCharacteristicModifiers = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier").enemyModifiers;
        }
        else if (GetParent() is Player)
        {
            activeCharacteristicModifiers = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier").playerModifiers;
        }

        foreach (CharacteristicModifierData modifier in activeCharacteristicModifiers)
        {
            Сalculation(modifier, 1);
        }
    }


    public void AddModifier(CharacteristicModifierData modifier)
    {
        if (modifier != null)
        {
            if (!activeCharacteristicModifiers.Contains(modifier))
            {
                Сalculation(modifier, 1);
                activeCharacteristicModifiers.Add(modifier);
            }
        }
    }

    public void RemoveModifier(CharacteristicModifierData modifier)
    {
        if (modifier != null)
        {
            if (activeCharacteristicModifiers.Contains(modifier))
            {
                Сalculation(modifier, -1);
                activeCharacteristicModifiers.Remove(modifier);
            }
        }
    }



    private void Сalculation(CharacteristicModifierData modifier, int mod)
    {
        GetParent<Character>().HP += mod * modifier.HP;
        GetParent<Character>().maxHP += mod * modifier.maxHP;

        GetParent<Character>().MovePoints += mod * modifier.movePoints;
        GetParent<Character>().maxMovePoints += mod * modifier.maxMovePoints;

        GetParent<Character>().ActionPoints += mod * modifier.actionPoints;
        GetParent<Character>().maxActionPoints += mod * modifier.maxActionPoints;

        GetParent<Character>().BeerPoints += mod * modifier.beerPoints;
        GetParent<Character>().maxBeerPoints += mod * modifier.maxBeerPoints;

        GetParent<Character>().moveCost += mod * modifier.moveCost;
        GetParent<Character>().meleeAttackCost += mod * modifier.meleeAttackCost;
        GetParent<Character>().rangeAttackCost += mod * modifier.rangeAttackCost;

        //GetParent<Character>().lineMove = modifier.lineMove;
        //GetParent<Character>().diagonalMove = modifier.diagonalMove;

        //GetParent<Character>().lineAttack = modifier.lineAttack;
        //GetParent<Character>().diagonalAttack = modifier.diagonalAttack;

        //GetParent<Character>().melee = modifier.melee;
        //GetParent<Character>().range = modifier.range;

        GetParent<Character>().rangeAttackDistance += mod * modifier.rangeAttackDistance;
        GetParent<Character>().meleeAttackDistance += mod * modifier.meleeAttackDistance;

        GetParent<Character>().AC += mod * modifier.AC;
        GetParent<Character>().money += mod * modifier.money;

        GetParent<Character>().strength += mod * modifier.strength;
        GetParent<Character>().dexterity += mod * modifier.dexterity;
        GetParent<Character>().inteligence += mod * modifier.intel;
        GetParent<Character>().constitution += mod * modifier.constitution;
        GetParent<Character>().wisdom += mod * modifier.wisdom;

        GetParent<Character>().drunkenness += mod * modifier.drunkenness;

        GetParent<Character>().physicalResist += mod * modifier.physicalResist;
        GetParent<Character>().poisonResist += mod * modifier.poisonResist;
        GetParent<Character>().fireResist += mod * modifier.fireResist;
        GetParent<Character>().frostResist += mod * modifier.frostResist;
        GetParent<Character>().drunkennessResist += mod * modifier.drunkennessResist;
    }
}




