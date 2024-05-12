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
		GetParent<Character>().MaxHP += NumericCalculation(mod, modifier.maxHP);
		GetParent<Character>().HP += NumericCalculation(mod, modifier.HP);

		GetParent<Character>().MaxMovePoints += NumericCalculation(mod, modifier.maxMovePoints);
		GetParent<Character>().MovePoints += NumericCalculation(mod, modifier.movePoints);

		GetParent<Character>().MaxActionPoints += NumericCalculation(mod, modifier.maxActionPoints);
		GetParent<Character>().ActionPoints += NumericCalculation(mod, modifier.actionPoints);

		GetParent<Character>().MaxBeerPoints += NumericCalculation(mod, modifier.maxBeerPoints);
		GetParent<Character>().BeerPoints += NumericCalculation(mod, modifier.beerPoints);

		GetParent<Character>().MoveCost += NumericCalculation(mod, modifier.moveCost);

		GetParent<Character>().directMove = BoolCalculation(mod, GetParent<Character>().directMove, modifier.horizontalMove);
		GetParent<Character>().diagonalMove = BoolCalculation(mod, GetParent<Character>().diagonalMove, modifier.diagonalMove);

		GetParent<Character>().AC += NumericCalculation(mod, modifier.AC);

		GetParent<Character>().Coins += NumericCalculation(mod, modifier.coins);

		GetParent<Character>().Strength += NumericCalculation(mod, modifier.strength);
		GetParent<Character>().Dexterity += NumericCalculation(mod, modifier.dexterity);
		GetParent<Character>().Inteligence += NumericCalculation(mod, modifier.inteligence);
		GetParent<Character>().Constitution += NumericCalculation(mod, modifier.constitution);
		GetParent<Character>().Wisdom += NumericCalculation(mod, modifier.wisdom);

		GetParent<Character>().Drunkenness += NumericCalculation(mod, modifier.drunkenness);

		GetParent<Character>().PhysicalResist += NumericCalculation(mod, modifier.physicalResist);
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
