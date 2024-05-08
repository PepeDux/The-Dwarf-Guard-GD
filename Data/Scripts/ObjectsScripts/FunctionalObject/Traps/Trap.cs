using Godot;
using System;
using System.Threading.Tasks;

public partial class Trap : FunctionalObject
{
	public override void _Ready()
	{
		base._Ready();
		//Events.finishedAllTurn += Activation;

		TileStorage.trapCells.Add(this.coordinate);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		//Events.finishedAllTurn -= Activation;
	}

	public override async void CheckWalkerCellAsync(Character character)
	{
		if (this.coordinate == character.coordinate)
		{
			character.GetNode<TakeDamage>("TakeDamage").Take(physicalDamage: DiceRoll.Roll(6));

			// Проигрываем анимацию
			GetNode<AnimationController>("AnimationController").PlayAnimation("Activation");
		}
	}
}
