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

		foreach (CharacteristicModifierData status in activeCharacteristicModifiers)
		{
			Сalculation(status, 1);
		}
	}


	public void AddStatus(CharacteristicModifierData status)
	{
		if (status != null)
		{
			if (!activeCharacteristicModifiers.Contains(status))
			{
				Сalculation(status, 1);
				activeCharacteristicModifiers.Add(status);
			}
		}
	}

	public void RemoveStatus(CharacteristicModifierData status)
	{
		if (status != null)
		{
			if (activeCharacteristicModifiers.Contains(status))
			{
				Сalculation(status, -1);
				activeCharacteristicModifiers.Remove(status);
			}
		}
	}



	public void Сalculation(CharacteristicModifierData status, int mod)
	{
		GetParent<Character>().maxHP += mod * status.HP;

		GetParent<Character>().MovePoints += mod * status.movePoint;
		GetParent<Character>().ActionPoints += mod * status.actionPoint;
		GetParent<Character>().BeerPoints += mod * status.beerPoint;

		GetParent<Character>().strength += mod * status.strength;
		GetParent<Character>().dexterity += mod * status.dexterity;
		GetParent<Character>().inteligence += mod * status.intel;
		GetParent<Character>().constitution += mod * status.constitution;
		GetParent<Character>().wisdom += mod * status.wisdom;

		GetParent<Character>().drunkenness += mod * status.drunkenness;

		GetParent<Character>().poisonResist += mod * status.poisonResist;
		GetParent<Character>().fireResist += mod * status.fireResist;
		GetParent<Character>().frostResist += mod * status.frostResist;
		GetParent<Character>().drunkennessResist += mod * status.drunkennessResist;
	}
}
