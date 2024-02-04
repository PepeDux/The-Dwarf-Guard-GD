using Godot;
using System;

public partial class PlayerAttack : AttackScript
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("LeftMouseClick") && GetParent<Player>().ActionPoints >= GetParent<Player>().meleeAttackCost)
		{
			foreach (var target in TileStorage.characters)
			{
				if (GetParent().GetNode<PlayerSelectTile>("PlayerSelectTile").cellPosition == target.coordinate && target is Enemy)
				{
					CalculationAttack(target);					
				}
			}
		}	
	}
}
