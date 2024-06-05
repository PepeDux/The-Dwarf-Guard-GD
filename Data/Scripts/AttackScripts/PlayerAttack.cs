using Godot;
using System;
using System.Linq;

public partial class PlayerAttack : AttackScript
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("RightMouseClick") && GetParent<Player>().ActionPoints >= 0 && GetParent<Player>().canPerformAction == true)
		{
			foreach (var target in CharacterStorage.characters)
			{
				if (MouseSelectTile.MouseCellPosition == target.coordinate && target is Enemy)
				{
					CalculationAttack(target);
				}
			}

			GetParent<Player>().canPerformAction = false;
			Events.finishedPlayerAction?.Invoke();
		}		
	}
}
