using Godot;
using System;

public partial class AttackScript : Node
{
	private Vector2I attackCell;
	private Character target;
	private int attackCost;

	private Character attacker;

	public override void _Ready()
	{
		attacker = GetParent<Character>();
	}



	public void CalculationAttack(Character target)
	{
		this.target = target;

		if (attacker.melee == true)
		{
			FindTarget(attacker.meleeAttackDistance, target);
		}

		if (attacker.range == true)
		{
			FindTarget(FieldCoordinate.xFieldSize, target);
		}
	}

	public void FindTarget(int distanceAttack, Character target)
	{
		Vector2I attackCell = new Vector2I();

		if (attacker.lineAttack == true)
		{
			//Напрво от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y);

				Attack(attackCell, target, "HorizontalAttack");
			}

			//Налево от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y);

				Attack(attackCell, target, "HorizontalAttack");
			}

			//Вниз от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X, attacker.coordinate.Y + i);

				Attack(attackCell, target, "DownAttack");
			}

			//Вверх от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X, attacker.coordinate.Y - i);

				Attack(attackCell, target, "UpAttack");
			}
		}

		//if (attacker.diagonalAttack == true)
		//{
		//	//Вверх-налево
		//	for (int i = 0; i <= distanceAttack; i++)
		//	{
		//		attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y + i);

		//		//Attack(attackCell, target, attackCost);
		//	}

		//	//Вверх-направо
		//	for (int i = 0; i <= distanceAttack; i++)
		//	{
		//		attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y + i);

		//		//Attack(attackCell, target, attackCost);
		//	}

		//	//Вниз-налево
		//	for (int i = 0; i <= distanceAttack; i++)
		//	{
		//		attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y - i);

		//		//Attack(attackCell, target, attackCost);
		//	}

		//	//Вниз-направо
		//	for (int i = 0; i <= distanceAttack; i++)
		//	{
		//		attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y - i);

		//		//Attack(attackCell, target, attackCost);
		//	}
		//}
	}

	public void Attack(Vector2I attackCell, Character target, string sideAttack)
	{
		if (attackCell == target.coordinate && target != null && attacker.ActionPoints > 0)
		{
			GD.Print(GetParent().Name);

			if (sideAttack == "HorizontalAttack")
			{
				GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("HorizontalAttack");
			}
			else if (sideAttack == "UpAttack")
			{
				GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("UpAttack");
			}
			else if (sideAttack == "DownAttack")
			{
				GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("DownAttack");
			}

			if (DiceRoll.Roll(20, 1) + attacker.strengthModifier >= target.AC)
			{
				GiveDamage();
			}

			attacker.ActionPoints -= 1;
		}
	}



	private void GiveDamage()
	{

		target.GetNode<TakeDamage>("TakeDamage").Take(
		physicalDamage: attacker.physicalDamage,
		poisonDamage: attacker.poisonDamage,
		fireDamage: attacker.fireDamage,
		frostDamage: attacker.frostDamage,
		drunkennessDamage: attacker.drunkennessDamage
		);


		attacker.ActionPoints -= attackCost;
	}
}
