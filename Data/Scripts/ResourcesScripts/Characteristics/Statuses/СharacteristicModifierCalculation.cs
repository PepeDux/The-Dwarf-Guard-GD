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
                // Тут он добавит модификатор в любом случае
                Сalculation(modifier, 1);



                // РАССКОМЕНТИТЬ ЭТУ СТРОЧКУ ЕСЛИ БУДЕТ НАЙДЕН БОЛЕЕ ЛУЧШИЙ СПОСОБ
                // НЕ ПЕРЕНОСИТЬ МОДИФИКАТОРЫ ФУНКЦИОНАЛЬНЫХ ОБЪЕКТОВ НА СЛЕДУЮЩИЙ УРВОВЕНТ🐈
                //activeCharacteristicModifiers.Add(modifier);
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
        GetParent<Character>().HP += NumericCalculation(mod, modifier.HP);
        GetParent<Character>().maxHP += NumericCalculation(mod, modifier.maxHP);

        GetParent<Character>().MovePoints += NumericCalculation(mod, modifier.movePoints);
        GetParent<Character>().maxMovePoints += NumericCalculation(mod, modifier.maxMovePoints);

        GetParent<Character>().ActionPoints += NumericCalculation(mod, modifier.actionPoints);
        GetParent<Character>().maxActionPoints += NumericCalculation(mod, modifier.maxActionPoints);

        GetParent<Character>().BeerPoints += NumericCalculation(mod, modifier.beerPoints);
        GetParent<Character>().maxBeerPoints += NumericCalculation(mod, modifier.maxBeerPoints);

        GetParent<Character>().moveCost += NumericCalculation(mod, modifier.moveCost);
        GetParent<Character>().meleeAttackCost += NumericCalculation(mod, modifier.meleeAttackCost);
        GetParent<Character>().rangeAttackCost += NumericCalculation(mod, modifier.rangeAttackCost);

        GetParent<Character>().lineMove = BoolCalculation(mod, GetParent<Character>().lineMove, modifier.lineMove);
        GetParent<Character>().diagonalMove = BoolCalculation(mod, GetParent<Character>().diagonalMove, modifier.diagonalMove);

        GetParent<Character>().lineAttack = BoolCalculation(mod, GetParent<Character>().lineAttack, modifier.lineAttack);
        GetParent<Character>().diagonalAttack = BoolCalculation(mod, GetParent<Character>().diagonalAttack, modifier.diagonalAttack);

        GetParent<Character>().meleeAttack = BoolCalculation(mod, GetParent<Character>().meleeAttack, modifier.meleeAttack);
        GetParent<Character>().rangeAttack = BoolCalculation(mod, GetParent<Character>().rangeAttack, modifier.rangeAttack);

        GetParent<Character>().rangeAttackDistance += NumericCalculation(mod, modifier.rangeAttackDistance);
        GetParent<Character>().meleeAttackDistance += NumericCalculation(mod, modifier.meleeAttackDistance);

        GetParent<Character>().AC += NumericCalculation(mod, modifier.AC);
        GetParent<Character>().money += NumericCalculation(mod, modifier.money);

        GetParent<Character>().Strength += NumericCalculation(mod, modifier.strength);
        GetParent<Character>().Dexterity += NumericCalculation(mod, modifier.dexterity);
        GetParent<Character>().Inteligence += NumericCalculation(mod, modifier.intel);
        GetParent<Character>().Constitution += NumericCalculation(mod, modifier.constitution);
        GetParent<Character>().Wisdom += NumericCalculation(mod, modifier.wisdom);

        GetParent<Character>().drunkenness += NumericCalculation(mod, modifier.drunkenness);

        GetParent<Character>().physicalResist += NumericCalculation(mod, modifier.physicalResist);
        GetParent<Character>().poisonResist += NumericCalculation(mod, modifier.poisonResist);
        GetParent<Character>().fireResist += NumericCalculation(mod, modifier.fireResist);
        GetParent<Character>().frostResist += NumericCalculation(mod, modifier.frostResist);
        GetParent<Character>().drunkennessResist += NumericCalculation(mod, modifier.drunkennessResist);
    }

    public bool BoolCalculation(int mod, bool characteristic, CharacteristicModifierData.BoolStatus boolStatus)
    {
        bool b = characteristic;

        if (boolStatus == CharacteristicModifierData.BoolStatus.Add)
        {
            b = true;
        }
        else if (boolStatus == CharacteristicModifierData.BoolStatus.Remove)
        {
            b = false;
        }

        if (mod == -1 && boolStatus != CharacteristicModifierData.BoolStatus.Nothing) 
        {
            b = !characteristic;
        }

        return b;
    }

    public int NumericCalculation(int mod, int numericStatus)
    {
        return mod * numericStatus;
    }
}




