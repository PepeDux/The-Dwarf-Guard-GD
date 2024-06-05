using Godot;
using System;
using System.Threading.Tasks;

public partial class Trap : FunctionalObject
{
	public override void _Ready()
	{
		base._Ready();
		//Events.finishedAllTurn += Activation;

		TileStorage.trapCells.Add(this.Coordinate);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		//Events.finishedAllTurn -= Activation;
	}

	public override async void CheckWalkerCellAsync(Character character)
	{
		if (this.Coordinate == character.Coordinate)
		{
			character.GetNode<TakeDamage>("TakeDamage").Take(physicalDamage: DiceRoll.Roll(4) + 2);

			// Проигрываем анимацию
			GetNode<AnimationController>("AnimationController").PlayAnimation("Activation");
		}
	}
}
