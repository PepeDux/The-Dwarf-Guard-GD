using Godot;
using System;
using System.Threading.Tasks;

public partial class Trap : FunctionalObject
{
	private bool isActivate;

	public override void _Ready()
	{
		base._Ready();
		Events.finishedAllTurn += Activation;

		TileStorage.trapCells.Add(this.coordinate);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		Events.finishedAllTurn -= Activation;
	}

	public override async void CheckWalkerCellAsync(Character character)
	{
		if (this.coordinate == character.coordinate && isActivate == false)
		{
			isActivate = true;

			// Проигрываем анимацию
			GetNode<AnimationController>("AnimationController").PlayAnimation("Activation");
			// Проигрываем звук
			GetNode<AudioController>("AudioStreamPlayer").PlaySound("Hurt", 0.9f, 1.3f);
			// Немного ждем, для того чтобы звук точно проигрался
			await Task.Delay(10);

			character.GetNode<TakeDamage>("TakeDamage").Take(physicalDamage: DiceRoll.Roll(6));
		}
	}

	private void Activation()
	{
		isActivate = false;
	}
}
