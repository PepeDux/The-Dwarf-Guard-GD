using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class StatusCalculation : Node
{
	public List<StatusModifierData> activeStatuses = new List<StatusModifierData>();


	public override void _Ready()
	{
		// Добавляем статусы в соответствии с родительским классом
		if (GetParent() is Enemy)
		{
			activeStatuses = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier").enemyStatuses;
		}
		else if (GetParent() is Player) 
		{
			activeStatuses = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier").playerStatuses;
		}

		foreach (StatusModifierData status in activeStatuses)
		{
			Сalculation(status, 1);
		}
	}


	public void AddStatus(StatusModifierData status)
	{
		if (status != null)
		{
			if (!activeStatuses.Contains(status))
			{
				Сalculation(status, 1);
				activeStatuses.Add(status);
			}
		}
	}

	public void RemoveStatus(StatusModifierData status)
	{
		if (status != null)
		{
			if (activeStatuses.Contains(status))
			{
				Сalculation(status, -1);
				activeStatuses.Remove(status);
			}
		}
	}



	public void Сalculation(StatusModifierData status, int mod)
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
