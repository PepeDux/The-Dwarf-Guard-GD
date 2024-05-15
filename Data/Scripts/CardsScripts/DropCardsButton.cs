using Godot;
using System;

public partial class DropCardsButton : BaseButton
{
	public override void _Ready()
	{
		base._Ready();

		Events.endSelectCard += Enable;
		Events.rerolledCards += Disable;
	}

	public override void _ExitTree()
	{
		base._ExitTree();

		Events.endSelectCard -= Enable;
		Events.rerolledCards -= Disable;
	}

	public override void Pressed()
	{
		base.Pressed();

		// Игроку дается монетки за отказ от карточек
		GetTree().Root.GetNode("GameScene").GetNode<PlayerCoinCollection>("PlayerCoinCollection").coins += 1;

		Disable();

		Events.dropedCards?.Invoke();
		Events.endSelectCard?.Invoke();
	}
}
