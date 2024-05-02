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

		if (attacker.meleeAttack == true)
		{
			FindTarget(attacker.meleeAttackDistance, target, attacker.MeleeAttackCost);
		}

		if (attacker.rangeAttack == true)
		{
			FindTarget(FieldCoordinate.xFieldSize, target, attacker.RangeAttackCost);
		}
	}

	public void FindTarget(int distanceAttack, Character target, int attackCost)
	{
		Vector2I attackCell = new Vector2I();

		if (attacker.horizontalAttack == true)
		{
			//Напрво от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y);

				Attack(attackCell, target, "HorizontalAttack", attackCost);
			}

			//Налево от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y);

				Attack(attackCell, target, "HorizontalAttack", attackCost);
			}

			//Вниз от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X, attacker.coordinate.Y + i);

				Attack(attackCell, target, "DownAttack", attackCost);
			}

			//Вверх от атакующего
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X, attacker.coordinate.Y - i);

				Attack(attackCell, target, "UpAttack", attackCost);
			}
		}

		if (attacker.diagonalAttack == true)
		{
			//Вверх-налево
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y + i);

				Attack(attackCell, target, "DownDiagonalAttack", attackCost);
			}

			//Вверх-направо
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y + i);

				Attack(attackCell, target, "DownDiagonalAttack", attackCost);
			}

			//Вниз-налево
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X - i, attacker.coordinate.Y - i);

				Attack(attackCell, target, "UpDiagonalAttack", attackCost);
			}

			//Вниз-направо
			for (int i = 0; i <= distanceAttack; i++)
			{
				attackCell = new Vector2I(attacker.coordinate.X + i, attacker.coordinate.Y - i);

				Attack(attackCell, target, "UpDiagonalAttack", attackCost);
			}
		}
	}

	public void Attack(Vector2I attackCell, Character target, string sideAttack, int attackCost)
	{
		// Переменная отвечает за то, является ли атака критической
		bool isCriticalDamage = false;

		if (attackCell == target.coordinate && target != null && attacker.ActionPoints > 0)
		{
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
			else if (sideAttack == "UpDiagonalAttack")
			{
				GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("UpDiagonalAttack");
			}
			else if (sideAttack == "DownDiagonalAttack")
			{
				GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("DownDiagonalAttack");
			}



			// Кидаем 1D20 на попадание
			int D20AttackDiceRoll = DiceRoll.Roll(20, 1);

			if (D20AttackDiceRoll == 20)
			{
				// При выпадании критической 20 урон становится критическим и увеличивает в 2 раза
				isCriticalDamage = true;
				GiveDamage(isCriticalDamage);
			}
			else if (D20AttackDiceRoll + attacker.strengthModifier >= target.AC) 
			{
				GiveDamage(isCriticalDamage);
			}
			else
			{
				// Перекрашиваем label в белый цвет
				GetParent().GetNode<SubViewport>("SubViewport").GetNode<Label>("Label").Modulate = new Color(0.96f, 0.96f, 0.98f);
				// Проигрываем звук промаха
				GetParent().GetNode<AudioController>("AudioStreamPlayer").PlaySound("Miss", 0.5f, 1f);
				// Текст лабела партикли
				target.GetNode<SubViewport>("SubViewport").GetNode<Label>("Label").Text = "MISS";
				// Вызываем партикли
				target.GetNode<CpuParticles2D>("MessageParticles").Emitting = true;
			}

			// Отнимаем у атакуещго цену атаки
			attacker.ActionPoints -= attackCost;
		}
	}



	private void GiveDamage(bool isCriticalDamage)
	{
		target.GetNode<TakeDamage>("TakeDamage").Take(
		isCriticalDamage: isCriticalDamage,
		physicalDamage: DiceRoll.Roll(4, 1) + attacker.PhysicalDamage + attacker.strengthModifier,
		poisonDamage: attacker.PoisonDamage,
		fireDamage: attacker.FireDamage,
		frostDamage: attacker.FrostDamage
		);
	}
}
