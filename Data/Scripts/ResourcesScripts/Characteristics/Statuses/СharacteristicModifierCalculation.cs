using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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


    public void AddModifier(CharacteristicModifierData modifier, bool checkContain = true)
    {
        if (modifier != null)
        {
            if (checkContain == true) 
            {
                // При наличии модификатора в списке не добавляет его
                if (!activeCharacteristicModifiers.Contains(modifier))
                {
                    Сalculation(modifier, 1);
                    activeCharacteristicModifiers.Add(modifier);
                }
            }       
            else if (checkContain == false) 
            {
                // Тут он добавит модификатор в люьом случае

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

        BoolCalculation(GetParent<Character>().lineMove, modifier.lineMove);
        BoolCalculation(GetParent<Character>().diagonalMove, modifier.diagonalMove);

        BoolCalculation(GetParent<Character>().lineAttack, modifier.lineAttack);
        BoolCalculation(GetParent<Character>().diagonalAttack, modifier.diagonalAttack);

        BoolCalculation(GetParent<Character>().meleeAttack, modifier.meleeAttack);
        BoolCalculation(GetParent<Character>().rangeAttack, modifier.rangeAttack);

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

    public void BoolCalculation(bool characteristic, CharacteristicModifierData.BoolStatus boolStatus)
    {
        if (boolStatus == CharacteristicModifierData.BoolStatus.Add)
        {
            characteristic = true;
        }
        else if (boolStatus == CharacteristicModifierData.BoolStatus.Remove)
        {
            characteristic = false;
        }
    }
}




