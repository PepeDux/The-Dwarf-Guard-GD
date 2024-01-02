using Godot;
using System;

public partial class EnemyAttack : AttackScript
{
	public override void _Process(double delta)
	{
		//Надо доработать
		if (GetParent<Enemy>().ActionPoints >= GetParent<Enemy>().meleeAttackCost)
		{
			foreach (var target in TileStorage.characters)
			{
				if (target is Player)
				{
					CalculationAttack(target);
				}
			}
		}
	}
}
