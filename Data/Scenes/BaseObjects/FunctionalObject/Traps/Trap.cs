using Godot;
using System;
using System.Threading.Tasks;

public partial class Trap : FunctionalObject
{
	public override void _Ready()
	{
		base._Ready();

		TileStorage.trapCells.Add(this.Coordinate);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
	}

	public override async void CheckWalkerCellAsync(Character target)
	{
		if (this.Coordinate == target.Coordinate)
		{
            ((ITakeDamage)target).TakeDamage(character: target, isCriticalDamage: false, physicalDamage: DiceRoll.Roll(4) + 2);

			// Проигрываем анимацию
			GetNode<AnimationController>("AnimationController").PlayAnimation("Activation");
		}
	}
}
